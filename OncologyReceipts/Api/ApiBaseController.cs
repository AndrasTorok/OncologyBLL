using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace OncologyReceipts.Api
{
    public abstract class ApiBaseController<T> : ApiController
        where T : class, IIdentity<T>
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
            try
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> Post(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                T entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);

                int deletedRecords = await context.SaveChangesAsync();

                return Request.CreateResponse(HttpStatusCode.OK, deletedRecords > 0);
            }
            catch(DbUpdateException ex)
            {
                string name = typeof(T).Name;
                string message = $"Entitatea {name} nu se poate sterge! Sunt deja create cu ea inregistrari in aplicatie.";   
                    
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, message);                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
        }

        public async Task<T> SaveGraph<TItems>(T live, string itemsPropertyName)
            where TItems : class, IIdentity<TItems>
        {
            var itemsPropertyInfo = typeof(T).GetProperty(itemsPropertyName);

            if (itemsPropertyInfo == null)
            {
                bool isInvalid = !itemsPropertyInfo.PropertyType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<TItems>));

                var tPropertyName = typeof(T).Name;
                string message = $"SaveGraph({tPropertyName} live, {itemsPropertyName}): there is no {itemsPropertyName} collection property on {tPropertyName} type.";

                throw new ApplicationException(message);
            }

            try
            {
                if (live != null)
                {
                    if (live.Id != 0)                                                                   //updating entity                     
                    {
                        T store = await context.Set<T>().Include(itemsPropertyName).FirstOrDefaultAsync(c => c.Id == live.Id);      //find the store entity

                        if (!store.Equals(live))                                //if store and live entity is not the same then update the store entity to the live entity
                        {
                            store.UpdatePropertiesFrom(live);                                           //using the custom UpdatePropertiesFrom method
                        }

                        IList<TItems> liveItems = itemsPropertyInfo.GetValue(live) as IList<TItems>,   //obtian the collection items using reflection
                            storeItems = itemsPropertyInfo.GetValue(store) as IList<TItems>;           //for live and store

                        var itemsChanges = CollectionChangeDetector<TItems>.CollectionChanges(liveItems, storeItems);               //get the collection changes for the items

                        itemsChanges.Added.ForEach(liveItem =>                                          //items to be added
                        {
                            storeItems.Add(liveItem);                                                   //add them to the store items
                        });

                        itemsChanges.Deleted.ForEach(liveItem =>                                        //items to be deleted
                        {
                            TItems storeItem = storeItems.First(sci => sci.Id == liveItem.Id);          //find the corresponding store item

                            context.Set<TItems>().Remove(storeItem);                                    //remove them from the context ( removing from the store item would not work )
                        });

                        itemsChanges.Updated.ForEach(liveItem =>                                        //items to be updated
                        {
                            TItems storeItem = storeItems.First(sci => sci.Id == liveItem.Id);          //find the corresponding store item

                            storeItem.UpdatePropertiesFrom(liveItem);                                   //update the store 
                        });
                    }
                    else
                    {                                                                                   //adding the live entity
                        context.Set<T>().Add(live);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return live;
        }
    }    
}
