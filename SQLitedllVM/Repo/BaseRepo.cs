using Microsoft.EntityFrameworkCore;
using SQLitedllVM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SQLitedllVM.Repo
{
    /// <summary>
    /// Could be pricy to new instances of BaseRepo thus:
    /// BaseRepo could be a singleton in a  ASP.net app or similar, in a WPF or winforms app
    /// in reality the will not be many instances:
    /// 
    /// Implement the commons functionality for all the repository classes
    /// A generic class so the derived repostiories can strongly type the methods
    /// </summary>
    public abstract class BaseRepo<T> : IDisposable where T : class, new()
    {

        //UserContext is in the EF folder
        //Context get created when a new specialised repo gets instantiated
        protected UserContext Context { get; } = new UserContext();
        //The derived Class instantiates this: Table  = Context.Users for example
        //the DbSet<User> lives in UserContext class
        protected DbSet<T> Table;
        /// <summary>
        /// Most of the below are wrappers for DbSet or DbContext
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetOne(int? id) => Table.Find(id);

        //public async Task<T> GetOneAsync(int? id) => await Table.FindAsync(id);

        public List<T> GetAll() => Table.ToList();

        //public Task<List<T>> GetAllAsync() => Table.ToListAsync();

        public int Add(T entity)
        {
            Table.Add(entity);

            return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }


        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }


        //This changes the entity state to delete.
        //There is another way of deleting, slower:
        //  Locate record in DbSet<T>, by calling Find()
        //  Then call remove, and pass the instance. Find(),
        //  requires extra trip to database
        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        /// <summary>
        /// Wrappers for SaveChangesAsync in DbContext
        /// </summary>
        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Thrown when there is a concurrency error
                //If Entries propery is null, no records were modified
                //entities in Entries threw error due to timestamp/conncurrency
                //for now, just rethrow the exception
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner exception(s) for additional 
                //details and affected objects
                //for now, just rethrow the exception
                Debug.WriteLine(ex.Message);
               throw;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Wrap Context.Dispose()
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //Wrap
                Context.Dispose();
                // Free any managed objects here. 
            }

            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
        //public async Task<int> SaveAsync(T entity)
        //{
        //    Context.Entry(entity).State = EntityState.Modified;
        //    return await SaveChangesAsync();
        //}

        //public async Task<int> DeleteAsync(T entity)
        //{
        //    Context.Entry(entity).State = EntityState.Deleted;
        //    return await SaveChangesAsync();
        //}

        /// <summary>
        /// Wrappers for SaveChangesAsync in DbContext
        /// </summary>
        /// <returns></returns>
        //internal async Task<int> SaveChangesAsync()
        //{
        //    try
        //    {
        //        return await Context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        //Thrown when there is a concurrency error
        //        //for now, just rethrow the exception
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        //Thrown when database update fails
        //        //Examine the inner exception(s) for additional 
        //        //details and affected objects
        //        //for now, just rethrow the exception
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        //some other exception happened and should be handled
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}
        //public Task<int> AddRangeAsync(IList<T> entities)
        //{
        //    Table.AddRange(entities);
        //    return SaveChangesAsync();
        //}

        //public int AddRange(IEnumerable<T> entities)
        //{
        //    Table.AddRange(entities);
        //    return SaveChanges();
        //}

        //public Task<int> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    Table.AddRange(entities);
        //    return SaveChangesAsync();
        //}
        //public async Task<int> AddAsync(T entity)
        //{
        //    Table.Add(entity);
        //    return await SaveChangesAsync();
        //}
    }
}
