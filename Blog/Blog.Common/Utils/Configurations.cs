using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;

namespace Blog.Common
{
    public class Configurations
    {
        public static readonly IConfiguration Configuration;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnStrRead { get => Configuration.GetConnectionString("CONN_STR_READ"); }
        public static string ConnStrWrite { get => Configuration.GetConnectionString("CONN_STR_WRITE"); }

        /// <summary>
        /// Redis连接字符串
        /// </summary>
        public static string RedisConnectionString { get => Configuration.GetConnectionString("RedisConnection"); }

        static Configurations()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        /// <summary>
        /// 将制定节点转换为实体对象
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="key">配置文件key</param>
        /// <returns></returns>
        public static T GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }

        /// <summary>
        /// 获取指定key对应的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSection(string key)
        {
            return Configuration.GetValue<string>(key);
        }
    }
}
