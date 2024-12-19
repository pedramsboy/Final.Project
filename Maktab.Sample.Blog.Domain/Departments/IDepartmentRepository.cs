using System;
using System.Linq.Expressions;
using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore.Query;

namespace Maktab.Sample.Blog.Domain.Departments;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<(List<Department> items, int totalRows)> GetDepartmentsListAsync(Expression<Func<Department, bool>> predicate, Paging paging, bool asNoTracking = true,
         Func<IQueryable<Department>, IIncludableQueryable<Department, object>> include = null);
}