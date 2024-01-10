using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Domain.Entities
{
    public class Capability : BaseEntity
    {
        public string Name { get; set; }
        public List<Role>? Roles { get; set; }

    }
}
