using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal? Amount { get; set; }
        public string? Payment_Status{ get; set; }
        public DateTime? Date {  get; set; }
        public List<Product>? Products { get; set; }
        public User? User { get; set; }
    }
}
