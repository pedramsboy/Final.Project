using System;
using Maktab.Sample.Blog.Abstraction.Domain;

namespace Maktab.Sample.Blog.Domain.Departments;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<List<Department>> SearchDepartmentsByTitle(string title);
    Task<List<Department>> DepartmentsList(Guid infirmaryId);
}