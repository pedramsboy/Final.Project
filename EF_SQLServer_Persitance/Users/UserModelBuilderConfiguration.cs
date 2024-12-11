

using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLServer_Persitance;

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

        builder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<User>()
            .HasMany(u => u.Likes)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

       

        
    }
}

