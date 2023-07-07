using BLL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {

   

        Task<T> GetByIdAsync(int id);

      

        Task<T> GetDataByEmailAsync(string Email);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        Task<int> GetCountAsync(ISpecification<T> spec);
       
        Task Add(T entity);
        
        T Delete(T entity);
        
        T Update(T entity);


    }
}
