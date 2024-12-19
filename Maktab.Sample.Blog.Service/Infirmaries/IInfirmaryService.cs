using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using System.Linq.Expressions;

namespace Maktab.Sample.Blog.Service.Posts;

public interface IInfirmaryService
{
    Task<GeneralResult> AddInfirmaryAsync(AddInfirmaryCommand command);
    Task UpdateInfirmaryAsync(UpdateInfirmaryCommand command);
    Task<InfirmaryArgs> GetInfirmaryByIdAsync(Guid id);
    Task DeleteInfirmaryByIdAsync(Guid id);
    Task<List<InfirmaryArgs>> GetAllInfirmariesAsync(Expression<Func<Infirmary, bool>> predicate);
    Task<GetInfirmariesListResult> GetInfirmariesListAsync(Paging paging);
}