using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blog.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;
using Blog.Entities;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region 模型验证注入
            //模型绑定 特性验证，自定义返回格式
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    //获取验证失败的模型字段 
                    var errorList = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => e.Value.Errors.First().ErrorMessage)
                    .ToList();
                    //设置返回内容
                    BaseResponse result = new BaseResponse()
                    {
                        Code = ErrorCode.Code_100,
                        Status = ErrorCode.Code_100
                    };
                    if (errorList.Count > 0)
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        var errors=errorList.Distinct();
                        foreach (var item in errors)
                        {
                            dic.Add(item, WebUtil.GetMsg(item, HttpHelper.GetLanguageCode()));
                        }
                        result.ErrorList = dic;
                    }
                    result.Msg = WebUtil.GetMsg(result.Code, HttpHelper.GetLanguageCode());
                    return new BadRequestObjectResult(result);
                };
            });
            #endregion
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            Assembly service = Assembly.Load("Blog.Services");
            Assembly repository = Assembly.Load("Blog.Repository");

            builder.RegisterAssemblyTypes(service, repository)
           .Where(t => t.Name.EndsWith("Services")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(service, repository)
           .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //HttpContext扩展
            app.UseHttpContextHelper();

            app.UseHttpsRedirection();
        }
    }
}