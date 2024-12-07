﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands
{
    public class AddInfirmaryCommand
    {
        public string InfirmaryName { get; set; }
        public InfirmaryClassification Classification { get; set; }
        public InfirmaryType Type { get; set; }
        public string SupportedInsurance { get; set; } 
        public string State { get; set; } 
        public string City { get; set; }
        public string Street { get; set; } 
        public string PhoneNumber { get; set; } 
        public Boolean IsAroundTheClock { get; set; }
        public string UserName { get; set; }

        public enum InfirmaryClassification
        {
            Community,
            Private,
            All
        }

        public enum InfirmaryType
        {
            Hospital,
            Laboratory,
            ImagingCenter,
            Clinic
        }
        
    }
}
