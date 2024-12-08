using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Persistence.Departments;
using Maktab.Sample.Blog.Persistence.Infirmaries;
using Maktab.Sample.Blog.Persistence.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SQLServer_Persitance
{
    public static class ProgramConfigs
    {
        public static void AddSQLServerPersistance(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<SqlServerDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseSqlServer(connectionString);
    });


            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IInfirmaryRepository, InfirmaryRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
        }
    }
}
