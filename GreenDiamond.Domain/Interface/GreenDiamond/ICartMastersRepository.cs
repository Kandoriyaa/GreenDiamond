using GreenDiamond.Domain.ErpEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Domain.Interface.GreenDiamond
{
    public interface ICartMastersRepository
    {
        Task<CartMaster> GetByIdAsync(int id);
        Task<IEnumerable<CartMaster>> GetAllAsync();
        Task AddAysnc(CartMaster cartMaster);
        Task DeleteAysnc(CartMaster cartMaster);
    }
}
