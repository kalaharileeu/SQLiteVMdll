using SQLitedllVM.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SQLitedllVM.Repo
{
    public class UserRepo : BaseRepo<User>, IRepo<User>
    {
        public UserRepo()
        {
            Table = Context.Users;
            //Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }
        /// <summary>
        /// Delete the user and all it data points
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUserByID(int id)
        {
            User findTR = GetOne(id);
            if (findTR == null)
                return;
            else
            {
                //Remove value form repo
                Table.Remove(findTR);
                SaveChanges();
            }
            //Now remove all the Points with that FK user Id
            using (var prepo = new PointRepo())
            {
                var listOfPoints = prepo.GetPointsByFK(findTR.UsernumberID);
                if (listOfPoints == null) return;
                foreach(var point in listOfPoints)
                    prepo.DeletePointsByID(point.PointId);//Delete the points
            }
        }
        /// <summary>
        /// Delete only one data point from a user
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOneUserPoint(int iduser, int idpointid)
        {
            User findTR = GetOne(iduser);
            if (findTR == null)
                return;

            //Now remove all the Points with that FK user Id
            using (var prepo = new PointRepo())
            {
                prepo.DeletePointsByID(idpointid);//Delete the points
            }
        }

        public int Delete(int id)
        {
            var toRemove = Context.Entry(new User { UsernumberID = id /*, Timestamp = timeStamp*/ });
            if (toRemove.State == EntityState.Detached)
            {
                Table.Add(toRemove.Entity);
            }
            toRemove.State = EntityState.Added;

            return SaveChanges();
        }

        //Update, to update I delete the old user and add the new user
        public int Update(User oldUpdated)
        {
            //The user is not there cannot update it 
            if (GetUserIdbyName(oldUpdated.Username) == null) return -1;
            //Get the old user
            User old = GetOne(oldUpdated.UsernumberID);
            if (old != null)
            {
                old.BusinessName = oldUpdated.BusinessName;
                old.ContactNumber = oldUpdated.ContactNumber;
                //if(oldUpdated.Url != "")old.SetUrl(oldUpdated.Url);
                old.Username = oldUpdated.Username;
                old.UsernumberID = oldUpdated.UsernumberID;
                base.SaveChanges();
                return 0;
            }
            return -1;
        }

        //"new" hides the base class the calls it later
        public new int Add(User newUser)
        {
            //Check it the user name is there first, if is, the return 
            if (GetUserIdbyName(newUser.Username) != null) return -1;
            //If the user is already there return a default value
            if(GetOne(newUser.UsernumberID) == null)
                return base.Add(newUser);
            return -1;
        }

        /// <summary>
        /// Because it is SQLite I have to do most the foreign key management
        /// myself
        /// </summary>
        /// <param name="newPoint"></param>
        /// <returns></returns>
        public int Add(Point newPoint)
        {
            //Does the Point idFK exist as a User id
            if (GetOne(newPoint.UserIDFK) == null)return -1;
            using (var pointrepo = new PointRepo())
                return pointrepo.Add(newPoint);
        }

        /// <summary>
        /// Return all the data for a user id the 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserAndData(int id)
        {
            var tempuser = GetOne(id);
            if (tempuser == null) return null;

            using (var pointrepo = new PointRepo())
            {
                tempuser.Data = pointrepo.GetPointsByFK(tempuser.UsernumberID);
            }
            return tempuser;
        }
        /// <summary>
        /// Get the First USer with the username found.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserIdbyName(string username)
        {
            return Table.FirstOrDefault(x => x.Username == username);
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
