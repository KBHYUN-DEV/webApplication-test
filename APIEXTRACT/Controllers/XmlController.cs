using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace APIEXTRACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public XmlController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetXmlData")]
        public async Task<IActionResult> GetXmlData(string url, string expDclrNo)
        {
            try
            {
                // expDclrNo 파라미터를 URL에 추가
                string fullUrl = $"{url}&expDclrNo={HttpUtility.UrlEncode(expDclrNo)}";

                // 주어진 URL로부터 XML 데이터를 가져옴
                var response = await _httpClient.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    var xmlContent = await response.Content.ReadAsStringAsync();
                    // XML 콘텐츠를 반환
                    return Content(xmlContent, "application/xml");
                }
                else
                {
                    return BadRequest("Failed to fetch XML data. The API returned a non-success status.");
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"An error occurred while fetching XML data: {ex.Message}");
            }
        }
    }
}
