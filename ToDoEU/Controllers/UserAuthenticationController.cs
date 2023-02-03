using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ToDoEU.Models.DTO;
using ToDoEU.Respository.Abstract;

namespace ToDoEU.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this._service = service;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            model.Role = "user";
            var result = await _service.RegistrationAysnc(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.LoginAysnc(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard", model); ;
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel()
        //    {
        //        Username = "admin",
        //        Name = "Ext_todo_admin",
        //        Email = "joshua.oguntola22@gmail.com",
        //        Password = "Admin@123456",
        //    };
        //    model.Role = "admin";
        //    var result = await _service.RegistrationAysnc(model);
        //    return Ok(result);
        //}
    }
}
