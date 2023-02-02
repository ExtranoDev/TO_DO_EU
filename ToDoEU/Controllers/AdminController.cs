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
            Console.WriteLine(_userId);

            if (_userId == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<ToDoItemModel> toDoList = _db.ToDoItems.Where(q => q.userId == _userId).ToList();
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
                var toDoList = _db.ToDoItems.Where(q => q.userId == _userId).ToList();
                if (toDoList == null)
                    return NotFound();
                return View(toDoList);
            }
        }
    }
}
