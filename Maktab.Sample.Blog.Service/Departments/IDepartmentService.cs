using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts.Contracts.Commands;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Departments
{
    public interface IDepartmentService
    {
        Task<GeneralResult> AddDepartmentAsync(AddDepartmentCommand command);
        Task UpdateDepartmentAsync(UpdateDepartmentCommand command);
        Task<DepartmentArgs> GetDepartmentByIdAsync(Guid id);
        Task DeleteDepartmentByIdAsync(Guid id);
        Task<List<DepartmentArgs>> GetAllDepartmentsAsync(Expression<Func<Department, bool>> predicate);
        Task<List<DepartmentArgs>> GetAllDepartmentsByInfirmaryIdAsync(Guid infirmaryId);
    }
}
