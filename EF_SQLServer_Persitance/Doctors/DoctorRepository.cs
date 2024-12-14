using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Doctors
{
    public class DoctorRepository : GenericRepository<Doctor, SqlServerDbContext>, IDoctorRepository
    {
        public DoctorRepository(SqlServerDbContext dbContext, ILogger<DoctorRepository> logger) : base(dbContext, logger)
        {
        }
    }
}
