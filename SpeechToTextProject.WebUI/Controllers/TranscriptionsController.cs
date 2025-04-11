using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.WebUI.Dtos;
using System.Text;

namespace SpeechToTextProject.WebUI.Controllers
{
    public class TranscriptionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TranscriptionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TranscriptionList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7142/api/Transcription");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTranscriptionDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateTranscription()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTranscription(CreateTranscriptionDto createTranscriptionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTranscriptionDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7142/api/Transcription", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TranscriptionList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTranscription(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7142/api/Transcription?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TranscriptionList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTranscription(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7142/api/Transcription/GetTranscription?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTranscriptionDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTranscription(UpdateTranscriptionDto updateTranscriptionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTranscriptionDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7142/api/Transcription", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TranscriptionList");
            }
            return View();
        }
    }
}
