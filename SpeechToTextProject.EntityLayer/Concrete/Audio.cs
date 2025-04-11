using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.EntityLayer.Concrete
{
    public class Audio
    {
        public int AudioId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string FilePath { get; set; }
    }
}
