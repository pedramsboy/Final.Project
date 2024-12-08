﻿using Maktab.Sample.Blog.Domain.Comments;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Likes;
using Maktab.Sample.Blog.Domain.Patients;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Roles;
using Maktab.Sample.Blog.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EF_SQLServer_Persitance
{
    public class SqlServerDbContext : IdentityDbContext<User, Role, Guid>
    {
        public SqlServerDbContext()
        {

        }
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Infirmary> Infirmaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conStr =
                 // "Data Source=.\\SQLEXPRESS;Initial Catalog=blogdb;TrustServerCertificate=True;Integrated Security=SSPI";
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
            modelBuilder.ConfigureCommentModelBuilder();
            modelBuilder.ConfigureLikeModelBuilder();
        }
    }
}
