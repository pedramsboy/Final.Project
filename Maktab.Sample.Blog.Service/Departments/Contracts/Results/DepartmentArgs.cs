using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Results;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using Maktab.Sample.Blog.Service.Users.Contracts.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Departments.Contracts.Results
{
    public class DepartmentArgs : GeneralResult
    {
        public string DepartmentName { get; set; }
        public string DepartmentService { get; set; }
        public Guid InfirmaryId { get; set; }
        public List<DoctorArgs> Doctors { get; set; } = new();
    }

    public static class DepartmentArgsMapper
    {
        public static DepartmentArgs MapToDepartmentArgs(this Department department)
        {
            return new DepartmentArgs
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                DepartmentService = department.DepartmentService,
                InfirmaryId = department.InfirmaryId,
                Doctors = department.Doctors.Select(c => c.MapToDoctorArgs()).ToList(),
                
            };
        }
    }
}
