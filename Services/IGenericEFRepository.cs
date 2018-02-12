using System.Collections.Generic;

//note: in this implementation long is used & not int for bigint 2/10/2018 William Thompson
namespace AspNetCoreWebAPI.Services
{
    public interface IGenericEFRepository
    {
        IEnumerable<TEntity> Get<TEntity>() where TEntity : class;
        TEntity Get<TEntity>(long id, bool includeRelatedEntities = false) where TEntity : class;
        void Add<TEntity>(TEntity item) where TEntity : class;
        void Delete<TEntity>(TEntity item) where TEntity : class;
        bool Exists<TEntity>(long id) where TEntity : class;
        bool Save();
    }
}
