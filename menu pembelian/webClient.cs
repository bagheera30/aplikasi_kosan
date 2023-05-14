using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace menu_pembelian
{
    public  class webClient
    {
        private  readonly HttpClient httpClient;
        private const string baseUrl = "http://localhost:5065/api/menu";

        public webClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<menu>> GetAllMenusAsync()
        {
            var response = await httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<menu>>(responseBody);
        }

        public async Task<menu> GetMenuByNamaAsync(string nama)
        {
            var response = await httpClient.GetAsync($"{nama}");
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<menu>(responseBody);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new HttpRequestException($"Failed to get menu. Status code: {response.StatusCode}");
            }
        }

        public async Task<HttpResponseMessage> AddMenuAsync(menu menu)
        {
            var menuJson = JsonSerializer.Serialize(menu);
            var content = new StringContent(menuJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("", content);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> UpdateMenuAsync(string nama, menu menu)
        {
            var menuJson = JsonSerializer.Serialize(menu);
            var content = new StringContent(menuJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{nama}", content);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> DeleteMenuAsync(string nama)
        {
            var response = await httpClient.DeleteAsync($"{nama}");
            response.EnsureSuccessStatusCode();
            return response;
        }

    }
}
