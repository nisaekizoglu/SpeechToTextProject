using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeechToTextProject.EntityLayer.Concrete;
using SpeechToTextProject.WebUI.Models;

namespace SpeechToTextProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AudioUser> _userManager;

        public RegisterController(UserManager<AudioUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {

                AudioUser w = new AudioUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email=p.Mail,
                    UserName = p.UserName,
                };

                var result = await _userManager.CreateAsync(w,p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);                    }
                }
            return View(p);
        }
    }
}
