using GreenDiamond.Domain.ErpEntities;
using System;

namespace GreenDiamond.Domain.Interface.GreenDiamond
{
    public interface IClotheDisplayRepository
    {
        Task<Category> GetClotheIdAsync(int Id);
        Task<(IEnumerable<Category> clothedisplayList, int TotalCount)> GetAllAsync(int page, int pageSize, string search);
        Task AddAsync(Category clotheDisplay);
        Task UpdateAsync(Category clotheDisplay);
        Task DeleteAsync(Category clotheDisplay);
    }
}
