﻿using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results
{
    public class InfirmaryArgs : GeneralResult
    {
        public string InfirmaryName { get; set; }
        public string SupportedInsurance { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string IsAroundTheClock { get; set; }

        public List<DepartmentArgs> Departments { get; set; } = new();
       
       
    }

    public static class InfirmaryArgsMapper
    {
        public static InfirmaryArgs MapToInfirmaryArgs(this Infirmary infirmary)
        {
            return new InfirmaryArgs
            {
                Id = infirmary.Id,
                InfirmaryName = infirmary.InfirmaryName,
                SupportedInsurance = infirmary.SupportedInsurance,
                State = infirmary.State,
                City = infirmary.City,
                Street = infirmary.Street,
                PhoneNumber = infirmary.PhoneNumber,
                IsAroundTheClock = infirmary.IsAroundTheClock,
                Departments = infirmary.Departments.Select(d => d.MapToDepartmentArgs()).ToList(),

            };
        }
    }
}
