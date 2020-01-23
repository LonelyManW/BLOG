using System;
using System.Collections.Generic;
using System.Text;
using Blog.Entities;
using Blog.Core;
using System.Data;

namespace Blog.IRepository
{
    public interface IManageRepository : IBaseRepository<dt_manage>
    {
        /// <summary>
        /// 增删改 
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        bool ExecuteModel(dt_manage model, IDbTransaction transaction = null);
    }
}
