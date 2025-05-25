using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SoruCevap.API.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

       
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }
    }
}