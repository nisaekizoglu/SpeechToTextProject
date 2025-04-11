using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechToTextProject.BusinessLayer;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.EntityLayer.Concrete;
using System.Transactions;

namespace SpeechToTextProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptionController : ControllerBase
    {

        private readonly ITranscriptionService _transcriptionService;

        public TranscriptionController(ITranscriptionService transcriptionService)
        {
            _transcriptionService = transcriptionService;
        }

        [HttpGet]
        public IActionResult TranscriptionList()
        {
            var value = _transcriptionService.TGetAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTranscription(Transcription transcription)
        {
            _transcriptionService.TInsert(transcription);
            return Ok("Ekleme başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteTranscription(int id)
        {
            _transcriptionService.TDelete(id);
            return Ok("Silme başarılı");    
        }
        [HttpGet("GetTranscription")]
        public IActionResult GetTranscription(int id)
        {
            var value =_transcriptionService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTranscription(Transcription transcription)
        {
            _transcriptionService.TUpdate(transcription);
            return Ok("Güncelleme başarılı");
        }
        [HttpGet("TranscriptionCount")]
        public IActionResult TranscriptionCount()
        {
            return Ok(_transcriptionService.TGetTranscriptionCount());
        }
    }
}
