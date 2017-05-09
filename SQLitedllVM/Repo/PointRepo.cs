using Microsoft.EntityFrameworkCore;
using SQLitedllVM.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace SQLitedllVM.Repo
{
    public class PointRepo : BaseRepo<Point>, IRepo<Point>
    {
        public PointRepo()
        {
            Table = Context.UserPoints;
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public void removePointsByID(int id)
        {
            Point findTR = GetOne(id);
            if (findTR == null)
                return;
            else
            {
                //Remove value form repo
                Context.UserPoints.Remove(findTR);
                Context.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            var toRemove = Context.Entry(new Point { PointId = id /*, Timestamp = timeStamp*/ });
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
        public new int Add(Point datapoint)
        {
            //If the user is already there return a default value
            if (GetOne(datapoint.PointId) == null)
                return base.Add(datapoint);
            return default(int);
        }
        //public Task<int> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
