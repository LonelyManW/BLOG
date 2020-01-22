using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Blog.Core
{
    /// <summary>
    /// 仓储通用操作接口
    /// </summary>
    /// <typeparam name="TEntity">数据库表映射实体</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {

    }
}
