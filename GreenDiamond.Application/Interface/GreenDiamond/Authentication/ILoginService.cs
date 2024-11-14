using GreenDiamond.Application.DTOs.GreenDiamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Application.Interface.GreenDiamond.Authentication
{
    public interface ILoginService
    {
        Task<LoginDto> Login(LoginDto loginDto);
    }
}
