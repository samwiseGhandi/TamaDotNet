using System.Net.Http.Json;

namespace TamaDotNet.Client.Services
{
    public class TamaService
    {
        readonly HttpClient _httpClient;

        public TamaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateTama(CreateTama _tama)
        {
            var response = await _httpClient.PostAsJsonAsync("api/tama", _tama);
        }
        public async Task<TamaModel> GetTama(UserDataModel _user)
        {
            var response = await _httpClient.GetFromJsonAsync<TamaModel>($"api/tama/{_user.Id}");
            return response;
        }
    }
}
