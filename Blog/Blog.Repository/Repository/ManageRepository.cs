using System;
using System.Collections.Generic;
using System.Text;
using Blog.IRepository;
using Blog.Entities;
using Blog.Core;
using System.Data;

namespace Blog.Repository
{
    public class ManageRepository : BaseRepository<dt_manage>, IManageRepository
    {
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool ExecuteModel(dt_manage model, IDbTransaction transaction = null)
        {
            return DBContext.ExecuteSqlInt(manage_sql.insert_sql, model, transaction) > 0;
        }
    }
}
