using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Abstraction.Service.Exceptions;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.Users;
using Maktab.Sample.Blog.Service.Configurations;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
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

namespace Maktab.Sample.Blog.Service.Infirmaries
{
    public class InfirmaryService : IInfirmaryService
    {

        private readonly IInfirmaryRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly InternalGrantsSettings _grants;
        private readonly InternalGrantsSettings _grantsSettings;

        public InfirmaryService(IInfirmaryRepository repository, UserManager<User> userManager, InternalGrantsSettings grants, IOptions<InternalGrantsSettings> settings)
        {
            _repository = repository;
            _userManager = userManager;
            _grants = grants;
            _grantsSettings = settings.Value;
        }
        public async Task<GeneralResult> AddInfirmaryAsync(AddInfirmaryCommand command)
        {
           

            var infirmary = new Infirmary(command.InfirmaryName, command.SupportedInsurance, command.State, command.City, command.Street, command.PhoneNumber,command.IsAroundTheClock);
            await _repository.AddAsync(infirmary);
            return new GeneralResult
            {
                Id = infirmary.Id
            };
        }

        public async Task DeleteInfirmaryByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidOperationException("Id is not valid.");

            var infirmary = await _repository.GetAsync(id);

            if (infirmary == null)
                throw new ItemNotFoundException(nameof(infirmary));

            await _repository.HardDeleteAsync(id);
        }

        public async Task<List<InfirmaryArgs>> GetAllInfirmariesAsync(Expression<Func<Infirmary, bool>> predicate=null)
        {
            var infirmaries = await _repository.QueryAsync(predicate ?? (p => true), include: p => p.Include(x => x.Departments));
                                                                                                   

            return infirmaries.Select(i => i.MapToInfirmaryArgs()).ToList();
        }

        public async Task<GetInfirmariesListResult> GetInfirmariesListAsync(Paging paging)
        {
            var result = await _repository.GetInfirmariesListAsync(paging, include: p => p.Include(x => x.Departments));

            var items = result.items.Select(p => p.MapToInfirmaryArgs()).ToList();
            return new GetInfirmariesListResult(items, result.totalRows, paging);
        }

        public async Task<InfirmaryArgs> GetInfirmaryByIdAsync(Guid id)
        {
            var infirmary = await _repository.GetAsync(id,
            include: i => i.Include(x => x.Departments));
                            

            if (infirmary == null)
                throw new ItemNotFoundException(nameof(Infirmary));

            return infirmary.MapToInfirmaryArgs();
        }


        public async Task UpdateInfirmaryAsync(UpdateInfirmaryCommand command)
        {
            var infirmary = await _repository.GetAsync(command.Id, false);
            

            if (infirmary == null)
                throw new ItemNotFoundException(nameof(Infirmary));

            

            infirmary.SetInfirmaryInfo(command.InfirmaryName, command.SupportedInsurance, command.State, command.City, command.Street, command.PhoneNumber, command.IsAroundTheClock);

            await _repository.UpdateAsync(infirmary);
        }
    }
}
