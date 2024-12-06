using Maktab.Sample.Blog.Domain.Infirmaries;
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
            .HasColumnType("varchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.SupportedInsurance)
            .HasColumnType("text")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.State)
            .HasColumnType("varchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.City)
            .HasColumnType("varchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.Street)
            .HasColumnType("varchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Infirmary>()
            .Property(i => i.PhoneNumber)
            .HasColumnType("varchar(200)")
            .IsRequired()
            .IsUnicode();
    }
}