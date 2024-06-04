using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace CDNUsersAPI.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public List<string> Skillsets { get; set; }

        public List<string> Hobby { get; set; }
    }
}
