using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Helper;
using GreenDiamond.Application.Interface.File;
using GreenDiamond.Application.Interface.GreenDiamond;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GreenDiamond.WebApi.Controllers
{
    public class ClotheDisplayController : BaseController
    {
        public readonly IClotheDisplayService _clotheDisplayService;
        public readonly IImageStorageService _imageStorageService;

        public ClotheDisplayController(IClotheDisplayService clotheDisplayService, IImageStorageService imageStorageService)
        {
            _clotheDisplayService = clotheDisplayService;
            _imageStorageService = imageStorageService;
        }

        [HttpGet]
        [Route("GetAllClotheDisplay")]
        public async Task<IActionResult> GetAllClotheDisplay([FromQuery] int page = PaginationConstant.DefaultPage, [FromQuery] int pageSize = PaginationConstant.DefaultPageSize, [FromQuery] string search = "")
        {
            var Result = await _clotheDisplayService.GetAllClotheDisplay(page, pageSize, search);
            if (Result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._retriveResponse, Data = Result });
        }

        [HttpGet]
        [Route("GetClotheDisplayById/{id}")]
        public async Task<IActionResult> GetClotheDisplayById(int id)
        {
            var Result = await _clotheDisplayService.GetClotheDisplayById(id);
            if (Result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._retriveResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._recordNotFound });
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveClotheDisplay([FromForm] ClotheDisplayDto clotheDisplayDto)
        {

            if (clotheDisplayDto.ClotheFile != null)
            {
                if (_imageStorageService.IsImage(clotheDisplayDto.ClotheFile))
                {
                    string filepath = await _imageStorageService.SaveImage(clotheDisplayDto.ClotheFile, GlobalDeclaration._clothe_path);
                    clotheDisplayDto.Photo = filepath;
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { Message = GlobalDeclaration._invalidFileExtResponse });
                }
            }

            var Result = await _clotheDisplayService.Save(clotheDisplayDto);
            if (Result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._savedResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = GlobalDeclaration._internalServerError });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteClotheDisplaye(int id)
        {
            var Result = await _clotheDisplayService.Delete(id);
            if (Result)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._deletedResponse, Data = Result });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = GlobalDeclaration._internalServerError });
        }
    }
}
