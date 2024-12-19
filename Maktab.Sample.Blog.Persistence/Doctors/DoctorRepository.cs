using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Doctors
{
    public class DoctorRepository : GenericRepository<Doctor, BlogDbContext>, IDoctorRepository
    {
        public DoctorRepository(BlogDbContext dbContext, ILogger<DoctorRepository> logger) : base(dbContext, logger)
        {
        }

        public Task<(List<Doctor> items, int totalRows)> GetDoctorsListAsync(Expression<Func<Doctor, bool>> predicate, Paging paging, bool asNoTracking = true, Func<IQueryable<Doctor>, IIncludableQueryable<Doctor, object>> include = null)
        {
            throw new NotImplementedException();
        }
    }
}
