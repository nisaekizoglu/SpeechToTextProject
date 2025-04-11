using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.WebUI.Dtos;
using System.Text;

namespace SpeechToTextProject.WebUI.Controllers
{
    public class AudiosController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public AudiosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AudioList()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7142/api/Audio");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAudioDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAudio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAudio(CreateAudioDto createAudioDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createAudioDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7142/api/Audio",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AudioList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteAudio(int id)
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7142/api/Audio?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AudioList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAudio(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7142/api/Audio/GetCategory?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAudioDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAudio(UpdateAudioDto updateAudioDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateAudioDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7142/api/Audio/GetCategory/",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AudioList");
            }
            return View();
        }

    }
}
