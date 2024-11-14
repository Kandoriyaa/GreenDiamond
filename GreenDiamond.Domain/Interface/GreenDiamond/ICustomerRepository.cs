using GreenDiamond.Domain.ErpEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Domain.Interface.GreenDiamond
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<(IEnumerable<Customer> customer, int TotalCount)> GetAllAsync(int page, int pageSize, string search);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}
