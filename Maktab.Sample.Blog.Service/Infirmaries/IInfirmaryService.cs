using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Commands;
using Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results;
using System.Linq.Expressions;

namespace Maktab.Sample.Blog.Service.Posts;

public interface IInfirmaryService
{
    Task<GeneralResult> AddInfirmaryAsync(AddInfirmaryCommand command);
    Task UpdateInfirmaryAsync(UpdateInfirmaryCommand command, string userName);
    Task<InfirmaryArgs> GetInfirmaryByIdAsync(Guid id);
    Task DeleteInfirmaryByIdAsync(Guid id, Guid userId);
    Task<List<InfirmaryArgs>> GetAllInfirmariesAsync(Expression<Func<Infirmary, bool>> predicate);
}