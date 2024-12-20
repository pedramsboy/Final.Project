﻿using Maktab.Sample.Blog.Domain.Departments;
using Microsoft.EntityFrameworkCore;

namespace Maktab.Sample.Blog.Persistence.Departments;

public static class DepartmentModelBuilderConfiguration
{
    public static void ConfigureDepartmentModelBuilder(this ModelBuilder builder)
    {
        builder.Entity<Department>().HasKey(d => d.Id);
        builder.Entity<Department>().HasQueryFilter(x => !x.IsDeleted);
        

        builder.Entity<Department>()
            .Property(d => d.DepartmentName)
            .HasColumnType("Nvarchar(200)")
            .IsRequired()
            .IsUnicode();

        builder.Entity<Department>()
            .Property(d => d.DepartmentService)
            .HasColumnType("Nvarchar(Max)")
            .IsRequired()
            .IsUnicode();

     
    }
}