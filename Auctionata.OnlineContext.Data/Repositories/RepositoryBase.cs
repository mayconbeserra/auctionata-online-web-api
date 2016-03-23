using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionata.OnlineContext.DomainModel.Repositories;

namespace Auctionata.OnlineContext.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected AuctionataDbContext context;

        public RepositoryBase(AuctionataDbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsEnumerable();
        }

        public virtual TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}