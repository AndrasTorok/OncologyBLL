using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace OncologyReceipts.Api
{
    public abstract class ApiBaseController<T> : ApiController
        where T : class
    {
        protected OncologyReceiptsContext context;

        public ApiBaseController(OncologyReceiptsContext context)
        {
            this.context = context;
        }

        public virtual async Task<IList<T>> Get()
        {
            IList<T> entities = await context.Set<T>().ToListAsync();

            return entities;
        }

        public virtual async Task<T> GetById(int id)
        {
            T entity = await context.Set<T>().FindAsync(id);

            return entity;
        }

        public virtual async Task<T> Put(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Post(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> Delete(int id)
        {
            T entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);

            int deletedRecords = await context.SaveChangesAsync();

            return deletedRecords > 0;
        }
    }
}