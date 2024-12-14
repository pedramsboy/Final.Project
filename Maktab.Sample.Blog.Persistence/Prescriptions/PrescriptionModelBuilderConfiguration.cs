using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Prescriptions
{
    public static class PrescriptionModelBuilderConfiguration
    {
        public static void ConfigurePrescriptionModelBuilder(this ModelBuilder builder)
        {
            builder.Entity<Prescription>().HasKey(p => p.Id);
            builder.Entity<Prescription>().HasQueryFilter(x => !x.IsDeleted);

            builder.Entity<Prescription>()
           .HasOne(p => p.Author)
           .WithMany(u => u.Prescriptions)
           .HasForeignKey(p => p.AuthorId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Prescription>()
           .HasOne(p => p.Doctor)
           .WithMany(u => u.Prescriptions)
           .HasForeignKey(p => p.DoctorId)
           .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Prescription>()
            .Property(p => p.Appointment)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

            builder.Entity<Prescription>()
                .Property(u => u.PrescriptionDescription)
                .HasColumnType("Nvarchar(Max)")
                .IsUnicode();
        }
    }
}
