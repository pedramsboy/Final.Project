using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Patients;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.prescription
{
    public interface IPrescriptionRepository : IGenericRepository<Prescription>
    {
        Task<(List<Prescription> items, int totalRows)> GetPrescriptionsListAsync(Expression<Func<Prescription, bool>> predicate, Paging paging, bool asNoTracking = true,
        Func<IQueryable<Prescription>, IIncludableQueryable<Prescription, object>> include = null);
    }
}
