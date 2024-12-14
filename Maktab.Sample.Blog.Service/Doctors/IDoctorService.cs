using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Doctors
{
    public interface IDoctorService
    {
        Task<GeneralResult> AddDoctorAsync(AddDoctorCommand command);
        Task UpdateDoctorAsync(UpdateDoctorCommand command);
        Task<DoctorArgs> GetDoctorByIdAsync(Guid id);
        Task DeleteDoctorByIdAsync(Guid id);
        Task<List<DoctorArgs>> GetAllDoctorsAsync(Expression<Func<Doctor, bool>> predicate);

    }
}
