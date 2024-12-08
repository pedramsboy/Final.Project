using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Patients.Contracts.Results
{
    public class PatientArgs : GeneralResult
    {
        public string NationalCode { get; set; }
        public string PatientDescription { get; set; }
        public string InsuranceName { get; set; }
        public string InsuranceDescription { get; set; }
        public UserArgs? Author { get; set; }
    }

    public static class PatientArgsMapper
    {
        public static PatientArgs MapToPatientArgs(this Patient patient)
        {
            return new PatientArgs
            {
                Id = patient.Id,
                 NationalCode= patient.NationalCode,
                PatientDescription = patient.PatientDescription,
                InsuranceName = patient.InsuranceName,
                InsuranceDescription = patient.InsuranceDescription,
                Author = patient.Author?.MapToUserArgs(),
                
            };
        }
    }
}
