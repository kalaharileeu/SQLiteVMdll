using SQLitedllVM.Models;
using System;
using System.Threading.Tasks;

namespace SQLitedllVM.Repo
{
    public class PointRepo : BaseRepo<Point>, IRepo<Point>
    {
        public PointRepo()
        {
            Table = Context.UserPoints;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
