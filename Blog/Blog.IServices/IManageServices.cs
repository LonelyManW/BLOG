using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Blog.Entities;

namespace Blog.IServices
{
    public interface IManageServices : IBaseServices<dt_manage>
    {
        /// <summary>
        /// 根据实体添加
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        bool ExecuteModel(dt_manage model, IDbTransaction transaction = null);
    }
}
