using Maktab.Sample.Blog.Abstraction.Domain;

namespace Maktab.Sample.Blog.Domain.Infirmaries;

public interface IInfirmaryRepository : IGenericRepository<Infirmary>
{
    Task<List<Infirmary>> SearchInfirmaryByTitle(string infirmaryName);
    Task<List<Infirmary>> GetAllInfirmaries();
}