using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApiAlumno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IgnacioPostaController : ControllerBase
    {
        public readonly HttpClient _httpClient;
        
        public IgnacioPostaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var response= await _httpClient.GetAsync("https://localhost:5050/api/IgnacioPosta");
            if (response.IsSuccessStatusCode)
                          {
                var data = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Por aqui paso la posta de Nacho");
                return Ok(data);
            }
            return StatusCode((int)response.StatusCode, "Error fetching data from external API.");
            
        }
        
    }
}
