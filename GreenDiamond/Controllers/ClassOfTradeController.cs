using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Helper;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WoopsaERP.WebApi.Controllers.WoopsaErp
{
    public class ClassOfTradeController : BaseController
    {
        public readonly IClassOfTradeService _classOfTradeService;

        public ClassOfTradeController(IClassOfTradeService classOfTradeService)
        {
            _classOfTradeService = classOfTradeService;
        }

        [HttpGet]
        [Route("GetAllClassOfTrade")]
        public async Task<IActionResult> GetAllClassOfTrade([FromQuery] int page = PaginationConstant.DefaultPage, [FromQuery] int pageSize = PaginationConstant.DefaultPageSize, [FromQuery] string search = "")
        {
            var Result = await _classOfTradeService.GetAllClassOfTrade(page, pageSize, search);
            if (Result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._retriveResponse, Data = Result });
        }

        [HttpGet]
        [Route("GetClassOfTradeById/{id}")]
        public async Task<IActionResult> GetClassOfTradeById(string id)
        {
            var Result = await _classOfTradeService.GetClassOfTradeById(id);
            if (Result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._recordNotFound });
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveClassOfTrade(ClassOfTradeDto classOfTradeDto)
        {
            var Result = await _classOfTradeService.Save(classOfTradeDto);
            if (Result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._savedResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = GlobalDeclaration._internalServerError });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteClassOfTrade(string id)
        {
            var Result = await _classOfTradeService.Delete(id);
            if (Result)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._deletedResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = GlobalDeclaration._internalServerError });
        }
    }
}
