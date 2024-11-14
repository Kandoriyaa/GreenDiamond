using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.Interface.GreenDiamond;
using Microsoft.EntityFrameworkCore;

namespace GreenDiamond.Infrastructure.Repositories.GreenDiamond
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GreenDiamondContext _context;

        public CustomerRepository(GreenDiamondContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Remove(customer);
        }

        public async Task<(IEnumerable<Customer> customer, int TotalCount)> GetAllAsync(int page, int pageSize, string search)
        {
            var query = from C in _context.Customers
                        where C.IsActive != false && C.IsDelete != true
                        select C;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(aa => aa.CustUserName.Contains(search));
            }

            var totalCount = await query.CountAsync();
            var customer = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (customer, totalCount);
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var query = _context.Customers.Where(aa => aa.CustId == id && aa.IsDelete != true && aa.IsActive != true);

            return query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}
