using Blog.Entities;
using Blog.IServices;
using Blog.IRepository;
using Blog.Core;
using System.Data;

namespace Blog.Services
{
    public class ManageServices : BaseServices<dt_manage>, IManageServices
    {
        IManageRepository _manageRepository;
        public ManageServices(IManageRepository manageRepository) : base(manageRepository)
        {
            _manageRepository = manageRepository;
        }

        /// <summary>
        /// 根据实体添加
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public bool ExecuteModel(dt_manage model, IDbTransaction transaction = null)
        {
            return _manageRepository.ExecuteModel(model, transaction);
        }
    }
}
