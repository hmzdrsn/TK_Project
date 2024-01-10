using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.UnitTest.Models
{
    public interface IDbContext
    {
        public List<Domain.Entities.User> Data {  get; set; }
    }
}
