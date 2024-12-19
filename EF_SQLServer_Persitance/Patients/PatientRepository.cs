using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Patients
{
    public class PatientRepository : GenericRepository<Patient, SqlServerDbContext>, IPatientRepository
    {
        public PatientRepository(SqlServerDbContext dbContext, ILogger<PatientRepository> logger) : base(dbContext, logger)
        {
        }

        
    }
}
