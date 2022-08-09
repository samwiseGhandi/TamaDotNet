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
        public async Task<bool> HasTama(UserDataModel _user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/tama/user/", _user);
            if(response.IsSuccessStatusCode)
            {
                var postResult = await response.Content.ReadAsStringAsync();
                if(postResult.Length > 3)
                {
                return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }
        public async Task<TamaModel> GetTama(UserDataModel user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/tama/user/", user);
            return await response.Content.ReadFromJsonAsync<TamaModel>();
        }
    }
}
//kontrollera ifall användare har en tama (om ej => skapa en tama ? läs tamas)
//
