using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Doctors
{
    public static class DoctorModelBuilderConfiguration
    {
        public static void ConfigureDoctorModelBuilder(this ModelBuilder builder)
        {

            builder.Entity<Doctor>().HasKey(d => d.Id);
            builder.Entity<Doctor>().HasQueryFilter(x => !x.IsDeleted);

            builder.Entity<Doctor>()
            .HasOne(d => d.Department)
            .WithMany(x => x.Doctors)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Doctor>()
                .Property(d => d.FirstName)
                .HasColumnType("Nvarchar(200)")
                .IsRequired()
                .IsUnicode();

            builder.Entity<Doctor>()
                .Property(d => d.LastName)
                .HasColumnType("Nvarchar(200)")
                .IsRequired()
                .IsUnicode();

            builder.Entity<Doctor>()
                .Property(d => d.MedicalSystemCode)
                .HasColumnType("Nvarchar(200)")
                .IsRequired()
                .IsUnicode();

            builder.Entity<Doctor>()
                .Property(d => d.LevelOfSpeciality)
                .HasColumnType("Nvarchar(200)")
                .IsRequired()
                .IsUnicode();


            builder.Entity<Doctor>()
                .Property(d => d.DoctorService)
                .HasColumnType("Nvarchar(500)")
                .IsRequired()
                .IsUnicode();


        }

    }
}
