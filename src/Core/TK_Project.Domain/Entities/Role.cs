﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Project.Domain.Entities
{
    public class Role : BaseEntity
    {
        
        public string Name { get; set; }
        public List<Capability>? Capabilities { get; set; }
        public List<User>? Users { get; set; }

    }
}
