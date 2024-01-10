using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description{ get; set; }
        public decimal? Price{ get; set; }
        public int? Stock{ get; set; }
        public bool? Status{ get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
