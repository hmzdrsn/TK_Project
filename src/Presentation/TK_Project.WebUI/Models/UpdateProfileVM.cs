using TK_Project.Domain.Entities;

namespace TK_Project.WebUI.Models
{
    public class UpdateProfileVM
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? Phone_Number { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
