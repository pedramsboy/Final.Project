using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.prescription
{
    public interface IPrescriptionRepository : IGenericRepository<Prescription>
    {
        Task<List<Prescription>> PrescriptionsList(Guid doctorId);
    }
}
