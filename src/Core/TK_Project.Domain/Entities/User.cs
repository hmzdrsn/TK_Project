using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Username{ get; set; }
        public string? Password{ get; set; }
        public string? First_Name{ get; set; }
        public string? Last_Name{ get; set; }
        public string? Address{ get; set; }
        public string? Mail{ get; set; }
        public string? Phone_Number{ get; set; }
        public string? ImageUrl { get; set; }
        public List<Role>? Roles { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
