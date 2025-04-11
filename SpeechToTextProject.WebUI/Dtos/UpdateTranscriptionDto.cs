using SpeechToTextProject.EntityLayer.Concrete;

namespace SpeechToTextProject.WebUI.Dtos
{
    public class UpdateTranscriptionDto
    {
        public int TranscriptionId { get; set; }
        public string Text { get; set; }
        public DateTime CreaedAt { get; set; }
        public string Language { get; set; }
        public int AudioId { get; set; }
        public Audio Audio { get; set; }
    }
}
