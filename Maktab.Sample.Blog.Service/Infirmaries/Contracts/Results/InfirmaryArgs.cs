using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Infirmaries;
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
        public InfirmaryClassification Classification { get; set; }
        public InfirmaryType Type { get; set; }
        public string SupportedInsurance { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsAroundTheClock { get; set; }

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

    public static class InfirmaryArgsMapper
    {
        public static InfirmaryArgs MapToInfirmaryArgs(this Infirmary infirmary)
        {
            return new InfirmaryArgs
            {
                Id = infirmary.Id,
                InfirmaryName = infirmary.InfirmaryName,
                //Classification = infirmary.Classification,
                //InfirmaryType = infirmary.InfirmaryType,
                SupportedInsurance = infirmary.SupportedInsurance,
                State = infirmary.State,
                City = infirmary.City,
                Street = infirmary.Street,
                PhoneNumber = infirmary.PhoneNumber,
                IsActive = infirmary.IsActive,
                IsAroundTheClock = infirmary.IsAroundTheClock,
                //Departments = Infirmary.Departments.Select(c => c.MapToDepartmentArgs()).ToList(),

            };
        }
    }
}
