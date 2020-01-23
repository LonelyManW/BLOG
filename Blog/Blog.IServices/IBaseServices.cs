using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Blog.IServices
{
    public interface IBaseServices<TEntity> where TEntity : class, new()
    {

    }
}
