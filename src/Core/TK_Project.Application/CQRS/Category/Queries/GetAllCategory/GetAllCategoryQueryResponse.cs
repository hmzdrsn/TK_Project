using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.CQRS.Category.Queries.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public object CategoryList { get; set; }
    }
}
