using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Patients.Contracts.Commands;
using Maktab.Sample.Blog.Service.Patients.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Patients
{
    public interface IPatientService
    {
        Task<GeneralResult> AddPatientAsync(AddPatientCommand command);
        Task UpdatePatientAsync(UpdatePatientCommand command, string userName);
        Task<PatientArgs> GetPatientByIdAsync(Guid id);
        Task DeletePatientByIdAsync(Guid id, Guid userId);
        Task<List<PatientArgs>> GetAllPatientsAsync(Expression<Func<Patient, bool>> predicate);
    }
}
