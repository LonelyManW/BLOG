using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController() { }

        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        ///返回提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult GetBaseResponse(BaseResponse data)
        {
            data.Msg = WebUtil.GetMsg(data.Code, LanguageCode);
            return Ok(data);
        }

        /// <summary>
        /// 获取ip
        /// </summary>
        /// <returns></returns>
        public string GetIp()
        {
            return HttpHelper.GetClientIp();
        }

        /// <summary>
        /// 语言编码
        /// </summary>
        protected string LanguageCode { get => HttpHelper.GetLanguageCode(); }


    }
}