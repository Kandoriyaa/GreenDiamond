using GreenDiamond.Application.DTOs.GreenDiamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Application.Interface.GreenDiamond
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerById(int id);
        Task<CustomerListDto> GetAllCustomer(int page, int pageSize, string search);
        Task<bool> SaveCustomer(CustomerDto customerDto);
        Task<bool> DeleteCustomer(int id);
    }
}
