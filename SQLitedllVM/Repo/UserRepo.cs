using System;
using System.Threading.Tasks;
using SQLitedllVM.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace SQLitedllVM.Repo
{
    public class UserRepo : BaseRepo<Userdetail>, IRepo<Userdetail>
    {
        public UserRepo()
        {
            Table = Context.Users;
        }

        public int Delete(int id)
        {
            var toRemove = Context.Entry(new Userdetail { Usernumber = id /*, Timestamp = timeStamp*/ });
            Debug.WriteLine(toRemove.State);
            if (toRemove.State == EntityState.Detached)
            {
                Table.Add(toRemove.Entity);
            }
            Debug.WriteLine(toRemove.State);
            toRemove.State = EntityState.Added;

            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
