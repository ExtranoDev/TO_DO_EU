using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoEU.Models.Domain;
using ToDoEU.Models.DTO;

namespace ToDoEU.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ToDoDbContext _db;
        private readonly string? _userId;
        public AdminController(ToDoDbContext db)
        {
            _db = db;
            _userId = Environment.UserName;
        }
        public IActionResult Display()
        {
            if (_userId == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<ToDoItemModel> toDoList = _db.ToDoItems.ToList();
                if (toDoList == null)
                {
                    return NotFound();
                }
                return View(toDoList);
            }
        }
        public IActionResult DisplayAdmin()
        {

            if (_userId == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<ToDoItemModel> toDoList = _db.ToDoItems.ToList();
                if (toDoList == null)
                    return NotFound();
                return View(toDoList);
            }
        }
        //GET
        public IActionResult Delete(int? itemId)
        {
            if (!itemId.HasValue)
            {
                return NotFound();
            }
            var toDoFromDb = _db.ToDoItems.Find(itemId.Value);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (toDoFromDb == null)
            {
                return NotFound();
            }
            return View(toDoFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteToDo(int? itemId)
        {
            ToDoItemModel? toDoObj = _db.ToDoItems.Find(itemId.Value);
            if (toDoObj == null)
            {
                return NotFound();
            }

            _db.ToDoItems.Remove(toDoObj);
            _db.SaveChanges();
            TempData["success"] = "ToDo Goal successfully deleted";
            return RedirectToAction("DisplayAdmin");
        }
    }
}
