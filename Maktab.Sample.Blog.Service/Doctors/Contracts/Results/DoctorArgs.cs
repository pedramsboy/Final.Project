using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Doctors.Contracts.Results
{
    public class DoctorArgs : GeneralResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MedicalSystemCode { get; set; }

        public string LevelOfSpeciality { get; set; }

        public string DoctorService { get; set; }

        public Guid DepartmentId { get; set; }

        public DepartmentArgs? Department { get; set; }

        
    }

    public static class DoctortArgsMapper
    {
        public static DoctorArgs MapToDoctorArgs(this Doctor doctor)
        {
            return new DoctorArgs
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MedicalSystemCode = doctor.MedicalSystemCode,
                LevelOfSpeciality = doctor.LevelOfSpeciality,
                DoctorService = doctor.DoctorService,
                DepartmentId = doctor.DepartmentId,
                Department = doctor.Department?.MapToDepartmentArgs(),

            };
        }
    }
}
