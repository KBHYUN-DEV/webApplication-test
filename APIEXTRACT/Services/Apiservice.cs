// 위치: YourProject/Services/ApiService.cs

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APIEXTRACT.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<XDocument> GetXmlDataAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string xmlString = await response.Content.ReadAsStringAsync();
                XDocument xmlDocument = XDocument.Parse(xmlString);

                return xmlDocument;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching XML data: {ex.Message}");
                return null;
            }
        }
    }
}
