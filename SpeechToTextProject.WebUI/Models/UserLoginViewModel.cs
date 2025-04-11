using System.ComponentModel.DataAnnotations;

namespace SpeechToTextProject.WebUI.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adınızı giriniz...")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz...")]
        public string Password { get; set; }
    }
}
