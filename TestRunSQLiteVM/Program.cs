using System;
//Right clicked on Dependencies and added the ref to the dll project
using SQLitedllVM.Models;
using System.Linq;

namespace TestRunSQLiteVM
{
    class Program
    {
        static void Main()
        {
            using (var db = new UserContext())
            {
                db.Users.Add(new Userdetail { Username = "Susan", Password = "1234567" });
                db.Users.Add(new Userdetail { Username = "Rick", Password = "7654321" });
                //Add a new data poitn to last entered user
                //(db.Users.Last()).Data.Add(new Point { Id = "something" });
                var count = db.SaveChanges();
                (db.Users.Last()).Data.Add(new Point { Id = "something" });
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                //iterate throught the users
                foreach (var user in db.Users)
                {
                    Console.WriteLine(" - {0}", user.Username);
                }
            }
            Console.ReadLine();
        }
    }
}