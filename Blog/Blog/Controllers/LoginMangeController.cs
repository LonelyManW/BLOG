using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Entities;
using Blog.IServices;
using Blog.Services;
using Blog.Repository;
using Blog.Common;

namespace Blog.Controllers
{
    [Route("api/loginmange")]
    [ApiController]
    public class LoginMangeController : BaseController
    {
        private readonly IManageServices _manageServices;
        public LoginMangeController(IManageServices manageServices)
        {
            _manageServices = manageServices;
        }

        [HttpPost("login")]
        public IActionResult login([FromBody]LoginRequest loginModel)
        {
            
            DataResponse<dt_manage> res = new DataResponse<dt_manage>()
            {
                Status = ErrorCode.Code_100,
                Code = ErrorCode.Code_100,
            };
            
            return GetBaseResponse(res);
        }

    }
}