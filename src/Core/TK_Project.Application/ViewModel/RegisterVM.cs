﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Domain.Entities;

namespace TK_Project.Application.ViewModel
{
    public class RegisterVM
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone_Number { get; set; }
    }
}
