using Microsoft.EntityFrameworkCore;
using SQLitedllVM.Models;
using System.Collections.Generic;
using System.Linq;

namespace SQLitedllVM.Repo
{
    public class PointRepo : BaseRepo<Point>, IRepo<Point>
    {
        public PointRepo()
        {
            Table = Context.UserPoints;
            //Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public void DeletePointsByID(int id)
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

        public List<Point> GetPointsByFK(int userID)
        {
            //Find all the points if any
            var points = Table.Where(x => x.UserIDFK == userID);
            //if the count is 0, reutrn null
            if(points.Count() == 0) return null;
            //else return the list
            return points.ToList();
        }

        public int Delete(int id)
        {
            var toRemove = Context.Entry(new Point { PointId = id /*, Timestamp = timeStamp*/ });
            if (toRemove.State == EntityState.Detached)
            {
                Table.Add(toRemove.Entity);
            }
            toRemove.State = EntityState.Added;

            return SaveChanges();
        }

        //"new" hides the base class the calls it later
        public new int Add(Point datapoint)
        {
            //if the name is null the return -1
            if (datapoint.Pointname == null) return -1;
            //If the Point is already there return a default value
            if (GetOne(datapoint.PointId) == null)
                return base.Add(datapoint);
            return -1;
        }
        //public Task<int> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
