using GreenDiamond.Application.Common;
using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Interface.File;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.UnitOfWork;

namespace GreenDiamond.Application.Service.GreenDiamond
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWorkGreenDiamond _unitOfWorkGreenDiamond;
        private readonly IImageStorageService _imageStorageService;

        public CustomerService(IUnitOfWorkGreenDiamond unitOfWorkGreenDiamond, IImageStorageService imageStorageService)
        {
            _unitOfWorkGreenDiamond = unitOfWorkGreenDiamond;
            _imageStorageService = imageStorageService;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
         var customer = await _unitOfWorkGreenDiamond.CustomerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                customer.IsDelete = true;
                customer.IsActive = false;
                await _unitOfWorkGreenDiamond.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<CustomerListDto> GetAllCustomer(int page, int pageSize, string search)
        {
            var (customer, totalCount) = await _unitOfWorkGreenDiamond.CustomerRepository.GetAllAsync(page, pageSize, search);
            var query = customer.Select(customers => new CustomerDto
            {
                CustId = customers.CustId,
                CustFirstName =customers.CustFirstName,
                CustLastName =customers.CustLastName,
                CustUserName =customers.CustUserName,
                CustPassword =customers.CustPassword,
                CustEmailAddrerss = customers.CustEmailAddrerss,
                CustApproved = customers.CustApproved,
                CustPhoneNo = customers.CustPhoneNo,
                CustAddress = customers.CustAddress,
                CustCountry = customers.CustCountry,
                CustCity = customers.CustCity,  
                CustState = customers.CustState,
                IsActive = customers.IsActive,
            });

            CustomerListDto customerDto = new CustomerListDto();
            customerDto.CustomerDtoinfo = query.ToList();
            customerDto.TotalRecords = totalCount;
            return await Task.FromResult(customerDto);
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var customer = await _unitOfWorkGreenDiamond.CustomerRepository.GetByIdAsync(id);
            var query = new CustomerDto
            {
                CustId = customer.CustId,
                CustFirstName = customer.CustFirstName,
                CustLastName = customer.CustLastName,
                CustUserName = customer.CustUserName,
                CustPassword = customer.CustPassword,
                CustEmailAddrerss = customer.CustEmailAddrerss,
                CustApproved = customer.CustApproved,
                CustPhoneNo = customer.CustPhoneNo,
                CustAddress = customer.CustAddress,
                CustCountry = customer.CustCountry,
                CustCity = customer.CustCity,
                CustState = customer.CustState,
                IsActive = customer.IsActive,
            };
            return await Task.FromResult(query);

        }

        public async Task<bool> SaveCustomer(CustomerDto customerDto)
        {
            var customer = await _unitOfWorkGreenDiamond.CustomerRepository.GetByIdAsync(Convert.ToInt32(customerDto.CustId));
            if(customer == null)
            {
                customer = new Customer();
                SetCustomerProperties(customer, customerDto, true);
                await _unitOfWorkGreenDiamond.CustomerRepository.AddAsync(customer);
            }
            else
            {
                SetCustomerProperties(customer,customerDto,false);
                await _unitOfWorkGreenDiamond.CustomerRepository.UpdateAsync(customer);
            }
            await _unitOfWorkGreenDiamond.CommitAsync();
            return true;
        }

        private void SetCustomerProperties(Customer customer, CustomerDto customerDto, bool isNew)
        {
            customer.CustFirstName = customerDto.CustFirstName;
            customer.CustLastName = customerDto.CustLastName;
            customer.CustUserName = customerDto.CustUserName;
            customer.CustPassword = customerDto.CustPassword;
            customer.CustEmailAddrerss = customerDto.CustEmailAddrerss;
            customer.CustApproved = customerDto.CustApproved;
            customer.CustPhoneNo = customerDto.CustPhoneNo;
            customer.CustAddress = customerDto.CustAddress;
            customer.CustCountry = customerDto.CustCountry;
            customer.CustCity = customerDto.CustCity;
            customer.CustState = customerDto.CustState;
            customer.IsActive = customerDto.IsActive;

            if (isNew)
            {
                customer.CreateDate = DateTime.Now;
                customer.CreateBy = 1;
            }
            else
            {
                customer.CustId = customerDto.CustId;
                customer.ModifiedBy = 1;
                customer.ModifiedDate = DateTime.Now;
            }
        }
    }
}
