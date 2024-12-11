using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Departments.Contracts.Commands;
using Maktab.Sample.Blog.Service.Departments.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Departments
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _repository;
        //private readonly IInfirmaryRepository _infirmaryRepository;
        private readonly UserManager<User> _userManager;
        private readonly InternalGrantsSettings _grants;
        private readonly InternalGrantsSettings _grantsSettings;

        public DepartmentService(IDepartmentRepository repository/*, IInfirmaryRepository infirmaryRepository*/, UserManager<User> userManager, InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
        {
            _repository = repository;
            //_infirmaryRepository = infirmaryRepository;
            _userManager = userManager;
            _grants = grants;
            _grantsSettings = settings.Value;
        }
        public async Task<GeneralResult> AddDepartmentAsync(AddDepartmentCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.UserName);
           // var infirmary = await _infirmaryRepository.GetAsync(command.InfirmaryId);
            if (user == null)
                throw new ItemNotFoundException(nameof(User));

            //if (infirmary == null)
            //    throw new ItemNotFoundException(nameof(Infirmary));

            var department = new Department(command.DepartmentName, command.DepartmentService, user.Id/*,infirmary.Id*/);
            await _repository.AddAsync(department);
            return new GeneralResult
            {
                Id = department.Id
            };
        }

        public async Task DeleteDepartmentByIdAsync(Guid id/*, Guid userId*/)
        {
            //if (id == Guid.Empty)
            //    throw new InvalidOperationException("Id is not valid.");

            //var department = await _repository.GetAsync(id);

            //if (department == null)
            //    throw new ItemNotFoundException(nameof(Department));

            //if (department.AuthorId != userId)
            //    throw new PermissionDeniedException();

           // await _repository.HardDeleteAsync(id);
        }

        public Task DeleteDepartmentByIdAsync(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public  Task<List<DepartmentArgs>> GetAllDepartmentsAsync(Expression<Func<Department, bool>> predicate)
        {
            //var departments = await _repository.QueryAsync(predicate ?? (p => true), include: d => d.Include(x => x.Author));

            //return departments.Select(p => p.MapToDepartmentArgs()).ToList();
            throw new NotImplementedException();
        }

        public async Task<DepartmentArgs> GetDepartmentByIdAsync(Guid id)
        {
            //var department = await _repository.GetAsync(id,
            //include: d => d.Include(x => x.Author));


            //if (department == null)
            //    throw new ItemNotFoundException(nameof(Department));

            //return department.MapToDepartmentArgs();
            throw new NotImplementedException();
        }


        public async Task UpdateDepartmentAsync(UpdateDepartmentCommand command, string userName)
        {
            var department = await _repository.GetAsync(command.Id, false);
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                throw new ItemNotFoundException(nameof(User));

            if (department == null)
                throw new ItemNotFoundException(nameof(Department));

            //if (department.AuthorId != user.Id)
            //    throw new PermissionDeniedException();

            department.SetDepartmentInfo(command.DepartmentName, command.DepartmentService);

            await _repository.UpdateAsync(department);
        }
    }
}
