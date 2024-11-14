using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Interface.File;
using GreenDiamond.Application.Interface.GreenDiamond.Authentication;
using GreenDiamond.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Application.Service.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWorkGreenDiamond _unitOfWorkGreenDiamond;
        private readonly IImageStorageService _imageStorageService;

        public LoginService(IUnitOfWorkGreenDiamond unitOfWorkGreenDiamond, IImageStorageService imageStorageService)
        {
            _imageStorageService = imageStorageService;
            _unitOfWorkGreenDiamond = unitOfWorkGreenDiamond;
        }

        public async Task<LoginDto> Login(LoginDto loginDto)
        {
            var login = await _unitOfWorkGreenDiamond.LoginRepository.LoginBy(loginDto.UserName, loginDto.Password);
            if (login == null)
            {
                return null;
            }
            var query = new LoginDto
            {
                Id = loginDto.Id,
                UserName = loginDto.UserName,
                Password = loginDto.Password,
            };
            return await Task.FromResult(query);
        }
    }
}
