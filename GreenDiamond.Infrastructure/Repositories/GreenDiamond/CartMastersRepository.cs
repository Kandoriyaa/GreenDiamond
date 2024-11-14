using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.Interface.GreenDiamond;
using Microsoft.EntityFrameworkCore;

namespace GreenDiamond.Infrastructure.Repositories.GreenDiamond
{
    public class CartMastersRepository : ICartMastersRepository
    {
        private readonly GreenDiamondContext _context;
        public CartMastersRepository(GreenDiamondContext context)
        {
            _context = context;
        }
        public async Task AddAysnc(CartMaster cartMaster)
        {
            await _context.CartMasters.AddAsync(cartMaster);
        }

        public async Task DeleteAysnc(CartMaster cartMaster)
        {
            _context.CartMasters.Remove(cartMaster);
        }

        public async Task<IEnumerable<CartMaster>> GetAllAsync()
        {
            return await _context.CartMasters.Where(aa => aa.IsClear != true && aa.IsDelete != true).ToListAsync();
        }

        public Task<CartMaster> GetByIdAsync(int id)
        {
            var query = _context.CartMasters.Where(aa => aa.Id == id && aa.IsDelete != true);
            return query.FirstOrDefaultAsync();
        }
    }
}
