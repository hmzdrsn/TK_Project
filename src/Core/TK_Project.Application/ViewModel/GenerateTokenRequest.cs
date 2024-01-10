using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.ViewModel
{
    public class GenerateTokenRequest
    {
        public string? Username { get; set; }
        public List<string> RoleName { get; set; }
    }
}
