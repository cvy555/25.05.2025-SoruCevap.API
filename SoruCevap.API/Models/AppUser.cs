using Microsoft.AspNetCore.Identity;

namespace SoruCevap.API.DTOs
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public string PhotoUrl { get; set; }

    }
}