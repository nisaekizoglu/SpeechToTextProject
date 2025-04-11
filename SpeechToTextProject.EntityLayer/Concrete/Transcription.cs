using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.EntityLayer.Concrete
{
    public class Transcription
    {
        public int TranscriptionId { get; set; }
        public string Text { get; set; }
        public string AudioFileName { get; set; }
        public DateTime CreaedAt { get; set; }
        public string Language { get; set; }
        public int AudioId { get; set; }
        public Audio Audio { get; set; }

    }
}
