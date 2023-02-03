using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoEU.Models.Domain;
using ToDoEU.Models.DTO;

namespace ToDoEU.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ToDoDbContext _db;
        private string? _userId;
        public DashboardController(ToDoDbContext db)
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
        public IActionResult Create(string name)
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoItemModel toDoObj)
        {
            if (toDoObj.ItemName == toDoObj.ItemDescription.ToString())
            {
                ModelState.AddModelError("name", "ToDo Name cannot exactly match the Description.");
            }
            if (toDoObj.ItemName != null && toDoObj.ItemDescription.ToString() != null)
            {
                //Guid myuuid = Guid.NewGuid();
                //string todoItemId = myuuid.ToString();
                // Don't forget to insert email from form
                //toDoObj.ItemId = todoItemId;
                toDoObj.userId = User.Identity.Name;
                toDoObj.ItemStatus = "pending";
                _db.ToDoItems.Add(toDoObj);
                _db.SaveChanges();
                TempData["success"] = "ToDo Goal successfully created";
                return RedirectToAction("Display");
            }
            else
            {
                return View(toDoObj);
            }
        }

        //GET
        public IActionResult Edit(int? itemId)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDoItemModel toDoObj)
        {
            if (toDoObj.ItemName == toDoObj.ItemDescription.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot exactly match the Name.");
            }
            if (toDoObj.ItemName != "" && toDoObj.ItemDescription.ToString() != "")
            {
                _db.ToDoItems.Update(toDoObj);
                _db.SaveChanges();
                TempData["success"] = "ToDo Goal successfully updated";
                return RedirectToAction("Display");
            }
            return View(toDoObj);
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
            return RedirectToAction("Display");
        }
    }
}

