using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.EntityLayer.Concrete
{
    public class User
    {
        public int UserId { get; set; }
        
        public string Namee { get; set; }
        public string Surnamee { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
