﻿    using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specification
{
   public  class SpecificationEvaluator <TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            try
            {


                var Query = inputQuery;
                if (spec.Criteria != null)
                    Query = Query.Where(spec.Criteria);
                if (spec.OrderBy != null)
                    Query = Query.OrderBy(spec.OrderBy);



                if (spec.IsPaginationEnabled)
                    Query = Query.Skip(spec.Skip).Take(spec.Take);



                if (spec.Includes != null)
                    Query = spec.Includes.Aggregate(Query, (currentQuery, include) => currentQuery.Include(include));

                return Query;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }



}
