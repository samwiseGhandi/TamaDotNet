
using System.Net.Http.Json;

namespace TamaDotNet.Client.Services {
    public class IdentityService {

        readonly HttpClient _httpClient;
        readonly ILocalStorageService _localStorageService;

        public IdentityService(HttpClient httpClient, ILocalStorageService localStorageService) {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public async Task PostUser(SignupModel SignUp) {
            var response = await _httpClient.PostAsJsonAsync("api/identity/signup", SignUp);

            if(response.IsSuccessStatusCode) {
                string token = await response.Content.ReadFromJsonAsync<string>();
                await _localStorageService.SetItemAsStringAsync("token", token);
            }
        }
        public async Task LoginUser(LoginModel LogIn) {
            var response = await _httpClient.PostAsJsonAsync("api/identity/login", LogIn);

            if(response.IsSuccessStatusCode) {
                string token = await response.Content.ReadFromJsonAsync<string>();
                await _localStorageService.SetItemAsStringAsync("token", token);
            }
        }
    }
}
