using Microsoft.AspNetCore.Identity;

namespace TamaDotNet.Server.Models {
    public class ApplicationUser:IdentityUser {
        public string Token { get; set; } = string.Empty;

    }
}