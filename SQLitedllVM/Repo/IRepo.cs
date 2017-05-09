using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLitedllVM.Repo
{
    /// <summary>
    /// CRUD
    /// The interface will expose the essential CRUD methods for the models.
    /// Expose both the synchronous and asynchronous versions(see chapter 19)
    /// Synchronous and Asynchronous access weigh up for app specific
    /// </summary>
    public interface IRepo<T>
    {
        int Add(T entity);
        int Save(T entity);
        int Delete(int id/*, byte[] timeStamp*/);
        int Delete(T entity);
        List<T> GetAll();
        T GetOne(int? id);
        //Task<int> AddAsync(T entity);
        //int AddRange(IList<T> entities);
        // Task<int> AddRangeAsync(IList<T> entities);
        // Task<int> SaveAsync(T entity);
        //Task<int> DeleteAsync(int id/*, byte[] timeStamp*/);
        //Task<int> DeleteAsync(T entity);
        //Task<T> GetOneAsync(int? id);
        //Task<List<T>> GetAllAsync();
        //The below except passing in string SQL query
        //Executing these will load and track the entitiesin the DbSet<T> of the context
        //These queries not really used as can build queries with LINQ
        //List<T> ExecuteQuery(string sql);
        //Task<List<T>> ExecuteQueryAsync(string sql);
        //List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
        //Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects);
    }
}
