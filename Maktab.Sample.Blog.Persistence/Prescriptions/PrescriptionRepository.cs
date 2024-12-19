using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Prescriptions
{
    public class PrescriptionRepository : GenericRepository<Prescription, BlogDbContext>, IPrescriptionRepository
    {
        public PrescriptionRepository(BlogDbContext dbContext, ILogger<PrescriptionRepository> logger) : base(dbContext, logger)
        {
        }

        public Task<(List<Prescription> items, int totalRows)> GetPrescriptionsListAsync(Expression<Func<Prescription, bool>> predicate, Paging paging, bool asNoTracking = true, Func<IQueryable<Prescription>, IIncludableQueryable<Prescription, object>> include = null)
        {
            throw new NotImplementedException();
        }
    }
}
