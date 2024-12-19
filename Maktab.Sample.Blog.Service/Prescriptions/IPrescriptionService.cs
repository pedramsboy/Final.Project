using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Commands;
using Maktab.Sample.Blog.Service.Doctors.Contracts.Results;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Commands;
using Maktab.Sample.Blog.Service.Prescriptions.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Prescriptions
{
    public interface IPrescriptionService
    {
        Task<GeneralResult> AddPrescriptionAsync(AddPrescriptionCommand command);
        Task UpdatePrescriptionAsync(UpdatePrescriptionCommand command);
        Task<PrescriptionArgs> GetPrescriptionByIdAsync(Guid id);
        Task DeletePrescriptionByIdAsync(Guid id);
        Task HardDeletePrescriptionByIdAsync(Guid id);
        Task<List<PrescriptionArgs>> GetAllPrescriptionsAsync(Expression<Func<Prescription, bool>> predicate);
        Task<List<PrescriptionArgs>> GetAllPrescriptionsByDoctorIdAsync(Guid doctortId);
        Task<List<PrescriptionArgs>> GetAllPrescriptionsByAuthorIdAsync(Guid authortId);
        Task<GetPrescriptionsListResult> GetPrescriptionsListAsync(Guid doctortId, Paging paging);
    }
}
