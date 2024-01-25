namespace TK_Project.WebUI.Models
{
    public class AddOrderVM
    {
        public string? Payment_Status { get; set; }
        public DateTime? Date { get; set; }
        public int UserID { get; set; }
        public string Products { get; set; }
    }
}
