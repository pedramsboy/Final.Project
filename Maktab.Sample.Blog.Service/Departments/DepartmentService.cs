using Maktab.Sample.Blog.Abstraction.Presistence;
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
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
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
        private readonly IInfirmaryRepository _infirmaryRepository;
        private readonly InternalGrantsSettings _grants;
        private readonly InternalGrantsSettings _grantsSettings;

        public DepartmentService(IDepartmentRepository repository, IInfirmaryRepository infirmaryRepository, InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
        {
            _repository = repository;
            _infirmaryRepository = infirmaryRepository;
            _grants = grants;
            _grantsSettings = settings.Value;
        }
        public async Task<GeneralResult> AddDepartmentAsync(AddDepartmentCommand command)
        {
            
           var infirmary = await _infirmaryRepository.GetAsync(command.InfirmaryId);
            

            if (infirmary == null)
                throw new ItemNotFoundException(nameof(Infirmary));

            var department = new Department(command.DepartmentName, command.DepartmentService,infirmary.Id);
            await _repository.AddAsync(department);
            return new GeneralResult
            {
                Id = department.Id
            };
        }

        public async Task DeleteDepartmentByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Id is not valid.");

            var department = await _repository.GetAsync(id);

            if (department == null)
                throw new ItemNotFoundException(nameof(Department));

            

             await _repository.HardDeleteAsync(id);
        }

        

        public async Task<List<DepartmentArgs>> GetAllDepartmentsAsync(Expression<Func<Department, bool>> predicate)
        {
            var departments = await _repository.QueryAsync(predicate ?? (p => true), include: p => p.Include(x => x.Doctors));

            return departments.Select(p => p.MapToDepartmentArgs()).ToList();
            
        }

        public async Task<List<DepartmentArgs>> GetAllDepartmentsByInfirmaryIdAsync(Guid infirmaryId)
        {
            var departments = await _repository.QueryAsync(d => d.InfirmaryId == infirmaryId, include: p => p.Include(x => x.Doctors));

            return departments.Select(p => p.MapToDepartmentArgs()).ToList();
        }

        public async Task<DepartmentArgs> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _repository.GetAsync(id, include: p => p.Include(x => x.Doctors));
            
            


            if (department == null)
                throw new ItemNotFoundException(nameof(Department));

            return department.MapToDepartmentArgs();
            
        }

        public async Task<GetDepartmentsListResult> GetDepartmentsListAsync(Guid infirmaryId,Paging paging)
        {
            var result = await _repository.GetDepartmentsListAsync(d => d.InfirmaryId == infirmaryId, paging, include: p => p.Include(x => x.Doctors));

            var items = result.items.Select(d => d.MapToDepartmentArgs()).ToList();
            return new GetDepartmentsListResult(items, result.totalRows, paging);
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentCommand command)
        {
            var department = await _repository.GetAsync(command.Id, false);
            

            if (department == null)
                throw new ItemNotFoundException(nameof(Department));

            

            department.SetDepartmentInfo(command.DepartmentName, command.DepartmentService);

            await _repository.UpdateAsync(department);
        }
    }
}
