using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse
    {
        public string Message { get; set; }
        public string UpdatedName { get; set; }
    }
}
