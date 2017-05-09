using System;
using System.Threading.Tasks;
using SQLitedllVM.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace SQLitedllVM.Repo
{
    public class UserRepo : BaseRepo<User>, IRepo<User>
    {
        public UserRepo()
        {
            Table = Context.Users;
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public void removeUserByID(int id)
        {
            User findTR = GetOne(id);
            if (findTR == null)
                return;
            else
            {
                //Remove value form repo
                Context.Users.Remove(findTR);
                Context.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            var toRemove = Context.Entry(new User { UsernumberID = id /*, Timestamp = timeStamp*/ });

            Debug.WriteLine(toRemove.State);
            if (toRemove.State == EntityState.Detached)
            {
                Table.Add(toRemove.Entity);
            }
            Debug.WriteLine(toRemove.State);
            toRemove.State = EntityState.Added;

            return SaveChanges();
        }


        //"new" hides the base class the calls it later
        public new int Add(User newUser)
        {
            //If the user is already there return a default value
            if(GetOne(newUser.UsernumberID) == null)
                return base.Add(newUser);
            return default(int);
        }

        ///// <summary>
        ///// Reomove a Userdetail by id, the Point data will also be removed
        ///// </summary>
        ///// <param name="v"></param>
        //private void removeUserByID(int v)
        //{
        //    Userdetail userToDel = GetOne(v);
        //    if (userToDel == null)
        //        return;
        //    else
        //    {
        //        //Remove value form repo
        //        Table.Remove(userToDel);
        //        Context.SaveChanges();
        //    }
        //    }
        //}
        //public Task<int> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
