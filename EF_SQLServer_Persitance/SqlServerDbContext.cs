
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
using Maktab.Sample.Blog.Persistence.Prescriptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EF_SQLServer_Persitance
{
    public class SqlServerDbContext : IdentityDbContext<User, Role, Guid>
    {
        
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Infirmary> Infirmaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conStr =
                
                 "Data Source=.;Initial Catalog=TestOnlineDoctorAppointment;TrustServerCertificate=True;User Id=sa;Password=13790047;MultipleActiveResultSets=true;";

                optionsBuilder.UseSqlServer(conStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());*/
            modelBuilder.ConfigureUserModelBuilder();
            modelBuilder.ConfigurePostModelBuilder();
            modelBuilder.ConfigureInfirmaryModelBuilder();
            modelBuilder.ConfigureDepartmentModelBuilder();
            modelBuilder.ConfigurePatientModelBuilder();
            modelBuilder.ConfigureDoctorModelBuilder();
            modelBuilder.ConfigurePrescriptionModelBuilder();
        }
    }
}
