﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands
{
    public class UpdateInfirmaryCommand
    {
        public Guid Id { get; set; }
        public string InfirmaryName { get; set; }
        public string SupportedInsurance { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string IsAroundTheClock { get; set; }

       
    }
}
