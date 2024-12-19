using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace Maktab.Sample.Blog.Persistence.Infirmaries;

public static class InfirmaryModelBuilderConfiguration
{
    public static void ConfigureInfirmaryModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Infirmary>().HasKey(i => i.Id);
        builder.Entity<Infirmary>().HasQueryFilter(x => !x.IsDeleted);

        

        builder.Entity<Infirmary>()
            .Property(i => i.InfirmaryName)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.SupportedInsurance)
            .HasColumnType("Nvarchar(500)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.State)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.City)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.Street)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.PhoneNumber)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.IsAroundTheClock)
            .HasColumnType("Nvarchar(500)")
            .IsRequired()
            .IsUnicode();
    }
}