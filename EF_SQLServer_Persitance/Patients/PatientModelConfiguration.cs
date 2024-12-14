using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Patients
{
    public static class PatientModelConfiguration
    {
        public static void ConfigurePatientModelBuilder(this ModelBuilder builder)
        {
            builder.Entity<Patient>().HasKey(p => p.Id);
            builder.Entity<Patient>().HasQueryFilter(x => !x.IsDeleted);

            //builder.Entity<Patient>()
            //.HasOne(p => p.Author)
            //.WithOne(u => u.Patient)
            //.HasForeignKey<Patient>(p => p.AuthorId)
            //.IsRequired()
            //.OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Patient>()
          .HasOne(p => p.Author)
          .WithMany(u => u.Patients)
          .HasForeignKey(p => p.AuthorId)
          .IsRequired()
          .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Patient>()
                .Property(p => p.NationalCode)
                .HasColumnType("Nvarchar(200)")
                .IsRequired()
                .IsUnicode();

            builder.Entity<Patient>()
                .Property(p => p.PatientDescription)
                .HasColumnType("Nvarchar(Max)")
                .IsRequired()
                .IsUnicode();

            builder.Entity<Patient>()
                .Property(p => p.InsuranceName)
                .HasColumnType("Nvarchar(200)")
                .IsRequired()
                .IsUnicode();

            builder.Entity<Patient>()
                .Property(p => p.InsuranceDescription)
                .HasColumnType("Nvarchar(Max)")
                .IsRequired()
                .IsUnicode();


        }
    }
}
