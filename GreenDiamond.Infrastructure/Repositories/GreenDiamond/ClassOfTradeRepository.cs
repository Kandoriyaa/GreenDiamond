using Microsoft.EntityFrameworkCore;
using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.Interfaces.GreenDiamond;

namespace GreenDiamond.Infrastructure.Repositories.GreenDiamond
{
    public class ClassOfTradeRepository : IClassOfTradeRepository
    {
        private readonly GreenDiamondContext _context;

        public ClassOfTradeRepository(GreenDiamondContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ClassOfTrade> classOfTrade, int TotalCount)> GetAllAsync(int page, int pageSize, string search)
        {

            var query = from CT in _context.ClassOfTrades
                        where  CT.IsDeleted != true && CT.IsActive != false
                        select CT;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(yy => yy.TradeDesc.Contains(search));
            }

            var totalCount = await query.CountAsync();
            var classOfTrade = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (classOfTrade, totalCount);
        }

        public Task<ClassOfTrade> GetByIdAsync(string id)
        {

            var query = _context.ClassOfTrades
                .Where(aa => aa.TradeCode == id && aa.IsDeleted != true && aa.TradeCode != null);

            return query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(ClassOfTrade classOfTrade)
        {
           await _context.ClassOfTrades.AddAsync(classOfTrade);
        }

        public async Task DeleteAsync(ClassOfTrade classOfTrade)
        {
            _context.ClassOfTrades.Remove(classOfTrade);
        }

        public async Task UpdateAsync(ClassOfTrade classOfTrade)
        {
            _context.ClassOfTrades.Update(classOfTrade);
        }
    }
}
