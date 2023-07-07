using BLL.Interfaces;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly EduChatbot_DB_Context _context;
        private Hashtable _repositories;
        public UnitOfWork(EduChatbot_DB_Context context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repositry = new GenericRepository<TEntity>(_context);
                _repositories.Add(type, repositry);
            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }


    }
}
