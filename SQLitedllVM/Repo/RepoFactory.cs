using SQLitedllVM.Models;
using SQLitedllVM.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using SQLitedllVM.Repo;

namespace SQLitedllVM.Repo
{
    public class BaseCreator
    {

    }



    public class RepoFactory
    {
        Dictionary<string, BaseCreator> RepoDict;

        private RepoFactory() { }
        static RepoFactory instance;
        public static RepoFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepoFactory();
                return instance;
            }
        }
        ///// <summary>
        ///// Because it is SQLite I have to do most the foreign key management
        ///// myself
        ///// </summary>
        ///// <param name="newPoint"></param>
        ///// <returns></returns>
        //public int Add(Point newPoint)
        //{
        //    //Does the Point idFK exist as a User id
        //    if (GetOne(newPoint.UserIDFK) == null) return -1;

        //    using (var pointrepo = new PointRepo())
        //    {
        //        if (pointrepo.Add(newPoint) == -1)
        //            return -1;
        //    }
        //    return -1;
        //}

        //public int DeleteUser(int id)
        //{
        //}

    }
}
