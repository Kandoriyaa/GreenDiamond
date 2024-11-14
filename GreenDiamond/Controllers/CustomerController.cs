using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Helper;
using GreenDiamond.Application.Interface.GreenDiamond;
using Microsoft.AspNetCore.Mvc;

namespace GreenDiamond.WebApi.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("Get-All-Customer")]
        public async Task<IActionResult> GetAllCustomer([FromQuery] int page = PaginationConstant.DefaultPage, [FromQuery] int pageSize = PaginationConstant.DefaultPageSize, [FromQuery] string search = "")
        {
            var result = await _customerService.GetAllCustomer(page, pageSize, search);
            if (result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._retriveResponse, Data = result });
        }

        [HttpGet]
        [Route("Get-Customer-By-Id/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerById(id);
            if (result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._retriveResponse, Data = result });
        }

        [HttpPost]
        [Route("Save-Customer")]
        public async Task<IActionResult> SaveCustomer(CustomerDto customerDto)
        {
            var result = await _customerService.SaveCustomer(customerDto);
            if (result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._retriveResponse, Data = result });
        }

        [HttpDelete]
        [Route("Delete-Customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._retriveResponse, Data = result });
        }
    }
}
