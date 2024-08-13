using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APIEXTRACT.Pages
{
    public class DisplayXmlModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public XElement XmlData { get; set; }

        public DisplayXmlModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnGet()
        {
            string url = "https://unipass.customs.go.kr:38010/ext/rest/expDclrNoPrExpFfmnBrkdQry/retrieveExpDclrNoPrExpFfmnBrkd?crkyCn=r250u214v038l099n030a040d0&expDclrNo=1286524008922X";

            var response = await _httpClient.GetAsync(url);
            var xmlContent = await response.Content.ReadAsStringAsync();

            XmlData = XElement.Parse(xmlContent);
        }
    }
}
