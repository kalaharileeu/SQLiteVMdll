using System;
//Right clicked on Dependencies and added the ref to the dll project
using SQLitedllVM.Repo;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;//C# 6
using System.Collections.Generic;
using SQLitedllVM.Models;

namespace TestRunSQLiteVM
{
    class Program
    {
        static void Main()
        {
            //Userdetail UD1;
            //Userdetail UD2;
            //Userdetail UD3;
            //using (var userRepo = new UserRepo())
            //{
            //    UD1 = userRepo.GetOne(19730417);
            //    UD2 = userRepo.GetOne(55555);
            //    UD3 = userRepo.GetOne(775567);
            //}

            //using (var pointRepo = new PointRepo())
            //{
            //    Point temppoint = new Point { Signedoff = false, Description = "Test123", Invoicenumber = "223", JodId = 1, Jobname = "Pppoio",  Usernumber = UD1.Usernumber};
            //    pointRepo.Add(temppoint);
            //    temppoint = new Point { Signedoff = false, Description = "Test123", Invoicenumber = "223", JodId = 3, Jobname = "Pppoio", Usernumber = UD2.Usernumber };
            //    pointRepo.Add(temppoint);
            //    temppoint = new Point { Signedoff = false, Description = "Test123", Invoicenumber = "223", JodId = 2, Jobname = "Pppoio", Usernumber = UD3.Usernumber };
            //    pointRepo.Add(temppoint);
            //}



            using (var userRepo = new UserRepo())
            {
                foreach (var v in userRepo.GetAll())
                {
                    Console.WriteLine($"Username: {v.Username}");
                    Console.WriteLine($"/nDataCount: {v.Data.Count}");
                }
            }
            Console.WriteLine();
            //iterate throught the users

            Console.ReadLine();
        }


    }
}