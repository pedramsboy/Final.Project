using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Persistence.Comments;
using Maktab.Sample.Blog.Persistence.Departments;
using Maktab.Sample.Blog.Persistence.Doctors;
using Maktab.Sample.Blog.Persistence.Infirmaries;
using Maktab.Sample.Blog.Persistence.Likes;
using Maktab.Sample.Blog.Persistence.Patients;
using Maktab.Sample.Blog.Persistence.Posts;
using Maktab.Sample.Blog.Persistence.Prescriptions;
using Maktab.Sample.Blog.Persistence.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Maktab.Sample.Blog.Persistence;

public class BlogDbContext : IdentityDbContext<User, Role, Guid>
{
    public BlogDbContext()
    {
        
    }
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContext) : base(dbContext)
    {
        
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
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
                "server=localhost; port=3006; database=MaktabBlogDb; user=root; password=root; Persist Security Info=False; Connect Timeout=300";
            optionsBuilder.UseMySql(conStr, ServerVersion.AutoDetect(conStr));
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
        modelBuilder.ConfigureDoctorModelBuilder();
        modelBuilder.ConfigurePatientModelBuilder();
        modelBuilder.ConfigurePrescriptionModelBuilder();
        modelBuilder.ConfigureCommentModelBuilder();
        modelBuilder.ConfigureLikeModelBuilder();
    }
}