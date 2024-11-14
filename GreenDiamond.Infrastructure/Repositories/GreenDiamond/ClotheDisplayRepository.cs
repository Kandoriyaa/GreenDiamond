using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.Interface.GreenDiamond;
using Microsoft.EntityFrameworkCore;

namespace GreenDiamond.Infrastructure.Repositories.GreenDiamond
{
    public class ClotheDisplayRepository : IClotheDisplayRepository
    {
        private readonly GreenDiamondContext _context;

        public ClotheDisplayRepository(GreenDiamondContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Category> clothedisplayList, int TotalCount)> GetAllAsync(int page, int pageSize, string search)
        {
            var query = from CD in _context.Categories
                        .Where(aa => aa.IsDelete != true && aa.IsActive != false)
                        select CD;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(yy => yy.ClotheName.Contains(search));
            }

            var totalCount = await query.CountAsync();
            var clothedisplayList = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (clothedisplayList, totalCount);
        }

        public async Task<Category> GetClotheIdAsync(int Id)
        {
            var query = _context.Categories
                .Where(aa => aa.Id == Id && aa.IsDelete != true );

            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(Category clotheDisplay)
        {
            _context.Categories.AddAsync(clotheDisplay);
        }

        public async Task DeleteAsync(Category clotheDisplay)
        {
            _context.Categories.Remove(clotheDisplay);
        }

        public async Task UpdateAsync(Category clotheDisplay)
        {
            _context.Categories.Update(clotheDisplay);
        }
    }
}
