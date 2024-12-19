using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maktab.Sample.Blog.Persistence.Users;

public static class UserModelBuilderConfiguration
{
    public static void ConfigureUserModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(u => u.Id);
        
        
        
        builder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnType("Nvarchar(100)")
            .IsRequired()
            .IsUnicode();
        
        builder.Entity<User>()
            .Property(u => u.LastName)
            .HasColumnType("Nvarchar(100)")
            .IsRequired()
            .IsUnicode();

        


       
    }
}

