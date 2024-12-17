using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Prescriptions
{
    public class PrescriptionRepository : GenericRepository<Prescription, BlogDbContext>, IPrescriptionRepository
    {
        public PrescriptionRepository(BlogDbContext dbContext, ILogger<PrescriptionRepository> logger) : base(dbContext, logger)
        {
        }

        public Task<List<Prescription>> PrescriptionsList(Guid doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
