using BLL.Interfaces;
using BLL.Specification;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        private readonly EduChatbot_DB_Context context;

        public GenericRepository(EduChatbot_DB_Context context)
        {
            this.context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await context.Set<T>().ToListAsync();


        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)

            => await ApplySpecifications(spec).ToListAsync();


        public async Task<T> GetByIdAsync(int id)
         => await context.Set<T>().FindAsync(id);

    
        public async Task<T> GetDataByEmailAsync(string Email)
          => await context.Set<T>().FindAsync(Email);

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        => await ApplySpecifications(spec).CountAsync();



        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
            => await ApplySpecifications(spec).FirstOrDefaultAsync();



        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);


        }

        public async Task Add(T entity)
        => await context.Set<T>().AddAsync(entity);

        public T Delete(T entity)
            => context.Set<T>().Remove(entity).Entity;



        public T Update(T entity)
            => context.Set<T>().Update(entity).Entity;
       
       
    }
}
