using System;
//Right clicked on Dependencies and added the ref to the dll project
using SQLitedllVM.Repo;
using System.Linq;

namespace TestRunSQLiteVM
{
    class Program
    {
        //Do some database seeding for some tests
        static void Main()
        {
            using (var userRepo = new UserRepo())
            {
                userRepo.Add(new SQLitedllVM.Models.Userdetail { BusinessName = "Happy hour", Usernumber = 34523, ContactNumber = "0312354", Username="MadMonkeys"});

                  //(userRepo.).Data.Add(new Point { JodId = 12 });
                  foreach(var v in userRepo.GetAll())
                    Console.WriteLine($"Username: {v.Usernumber}");
                Console.WriteLine();
                //iterate throught the users
            }
            Console.ReadLine();
        }
    }
}