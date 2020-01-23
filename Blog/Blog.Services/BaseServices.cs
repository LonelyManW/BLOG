using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Blog.Core;
using Blog.IServices;

namespace Blog.Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _repository;
        public BaseServices(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

    }
}
