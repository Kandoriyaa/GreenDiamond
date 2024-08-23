using GreenDiamond.Domain.ErpEntities;

namespace GreenDiamond.Domain.Interfaces.GreenDiamond
{
    public interface IClassOfTradeRepository
    {
        Task<ClassOfTrade> GetByIdAsync(string id);

        Task<(IEnumerable<ClassOfTrade> classOfTrade, int TotalCount)> GetAllAsync(int page, int pageSize, string search);

        Task AddAsync(ClassOfTrade classOfTrade);

        Task UpdateAsync(ClassOfTrade classOfTrade);

        Task DeleteAsync(ClassOfTrade classOfTrade);
    }
}
