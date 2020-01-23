using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Blog.Entities;
using Blog.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Init();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());

        ///<summary>
        ///初始化返回提示码
        ///</summary>
        public static void Init()
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo dir = new DirectoryInfo(path + @"\Configs\");
            FileInfo[] fs = dir.GetFiles("Code_*.json");
            ErrorCodeMsg.CodeMsg = new Dictionary<string, CodeMessage>();
            foreach (var item in fs)
            {
                var codeMsg = WebUtil.DeserializeObject<CodeMessage>(item.ToString());
                ErrorCodeMsg.CodeMsg.Add(codeMsg.Language.ToLower(), codeMsg);
            }

        }

    }
}
