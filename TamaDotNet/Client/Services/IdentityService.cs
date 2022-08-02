
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
            await _httpClient.PostAsJsonAsync("api/identity/signup", SignUp);
        }
    }
}
