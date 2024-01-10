using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Application.Interfaces.Repositories.Capability
{
    public interface ICapabilityWriteRepository : IWriteRepository<Domain.Entities.Capability>
    {
        //Task<Domain.Entities.Capability> AddCapabilityWithRole();
    }
}
