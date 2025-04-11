using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeechToTextProject.EntityLayer.Concrete;
using SpeechToTextProject.WebUI.Models;

namespace SpeechToTextProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AudioUser> _signInManager;

        public LoginController(SignInManager<AudioUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(p.UserName,p.Password,true,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("AudioList","Audios");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı Adı veya şifre yanlış.");
                }
            }
            return View();
        }
    }
}
