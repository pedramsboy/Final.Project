using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
namespace EF_SQLServer_Persitance;


public static class CommentModelBuilderConfiguration
{
    public static void ConfigureCommentModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Comment>().HasKey(c => c.Id);

        builder.Entity<Comment>()
            .Property(c => c.CommentText)
            .HasColumnType("varchar(1000)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}