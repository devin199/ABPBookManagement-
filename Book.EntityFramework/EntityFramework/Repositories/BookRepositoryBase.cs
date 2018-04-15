using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Book.EntityFramework.Repositories
{
    public abstract class BookRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<BookDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BookRepositoryBase(IDbContextProvider<BookDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class BookRepositoryBase<TEntity> : BookRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BookRepositoryBase(IDbContextProvider<BookDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
