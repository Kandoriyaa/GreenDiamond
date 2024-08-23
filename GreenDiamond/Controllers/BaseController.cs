﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GreenDiamond.WebApi.Middleware;

namespace GreenDiamond.WebApi.Controllers
{
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ResponseFormatting]
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}