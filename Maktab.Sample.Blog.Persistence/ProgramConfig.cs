using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence.Departments;
using Maktab.Sample.Blog.Persistence.Doctors;
using Maktab.Sample.Blog.Persistence.Infirmaries;
using Maktab.Sample.Blog.Persistence.Patients;
using Maktab.Sample.Blog.Persistence.Posts;
using Maktab.Sample.Blog.Persistence.Prescriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Maktab.Sample.Blog.Persistence
{
    public static class ProgramConfig
    {
        public static void AddMySQLPersistance(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<BlogDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });


            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IInfirmaryRepository, InfirmaryRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
        }
    }
}
