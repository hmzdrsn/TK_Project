using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Capability;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories.Capability
{
    public class CapabilityWriteRepository : WriteRepository<Domain.Entities.Capability>, ICapabilityWriteRepository
    {
        public CapabilityWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
