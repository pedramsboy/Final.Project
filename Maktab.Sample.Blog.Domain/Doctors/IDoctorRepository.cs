using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Departments;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Domain.Doctors
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<(List<Doctor> items, int totalRows)> GetDoctorsListAsync(Expression<Func<Doctor, bool>> predicate, Paging paging, bool asNoTracking = true,
        Func<IQueryable<Doctor>, IIncludableQueryable<Doctor, object>> include = null);
    }
}
