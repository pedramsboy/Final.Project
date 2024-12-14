using EF_SQLServer_Persitance;
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
    public class PrescriptionRepository : GenericRepository<Prescription, SqlServerDbContext>, IPrescriptionRepository
    {
        public PrescriptionRepository(SqlServerDbContext dbContext, ILogger<PrescriptionRepository> logger) : base(dbContext, logger)
        {
        }
    }
}
