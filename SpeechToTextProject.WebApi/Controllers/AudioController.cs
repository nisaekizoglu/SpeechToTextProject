using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.EntityLayer.Concrete;

namespace SpeechToTextProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }
        [HttpGet]
        public IActionResult AudioList()
        {
            var value = _audioService.TGetAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateAudio(Audio audio)
        {
            _audioService.TInsert(audio);
            return Ok("Ekleme başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteAudio(int id)
        {
            _audioService.TDelete(id);
            return Ok("Silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateAudio(Audio audio)
        {
            _audioService.TUpdate(audio);
            return Ok("Güncelleme yapıldı");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetAudio(int id)
        {
            var value = _audioService.TGetById(id);
            return Ok(value);
        }
    }
}
