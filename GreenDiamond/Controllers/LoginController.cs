using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Helper;
using GreenDiamond.Application.Interface.File;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GreenDiamond.Application.Interface.GreenDiamond.Authentication;

namespace GreenDiamond.WebApi.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly IImageStorageService _imageStorageService;

        public LoginController (ILoginService loginService, IImageStorageService imageStorageService)
        {
            _loginService = loginService;
            _imageStorageService = imageStorageService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _loginService.Login(loginDto);
            if (response != null)
            {
                return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._loginResponse, Data = response });
            }
                return StatusCode(StatusCodes.Status404NotFound, new { Message = GlobalDeclaration._recordNotFound, Data = response });
            
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return StatusCode(StatusCodes.Status200OK, new { Message = GlobalDeclaration._logoutResponse, Data = true });
        }
    }
}
