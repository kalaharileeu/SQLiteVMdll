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
        /// <summary>
        /// TODO: Check the user name and business name in repo, if it exists the return, append user id
        /// </summary>
        static void Main()
        {
            User UD1;

            using (var userRepo = new UserRepo())
            {
                //Can ADD with aotu id
                userRepo.Add(new User() {UsernumberID = 2344, BusinessName = "ManualAdd2", Username = "Thehosue", ContactNumber = "233552353" });
                userRepo.Add(new User() { UsernumberID = 2345, BusinessName = "TwoMonkeys", Username = "MonkeyStraw", ContactNumber = "233552353" });
                userRepo.Add(new User() { UsernumberID = 2346, BusinessName = "samenameUSER", Username = "MonkeyStraw", ContactNumber = "233552353" });


                //Add some jobs
                userRepo.Add(new Point() { UserIDFK = 2, Pointname = "VeggieGarden", Description = "Pull all weeds out and clean up edges" });
                userRepo.Add(new Point() { UserIDFK = 2346, Pointname = "BoomBoom", Description = "Pull all Boom out of Boom" });
                //Add a user point to the User repo
                userRepo.Add(new Point() { UserIDFK = 1, Pointname = "VeggieGarden", Description = "Pull all weeds out and clean up edges" });
                userRepo.Add(new Point() { UserIDFK = 2345, Pointname = "B", Description = "P" });

                userRepo.Add(new Point() { UserIDFK = 1, Pointname = "VeggieGarden", Description = "Pull all weeds out and clean up edges" });
                userRepo.Add(new Point() { UserIDFK = 2345, Pointname = "C", Description = "C" });


                //GetALL()
                foreach (var justuser in userRepo.GetAll())
                {
                    var userwithdata = userRepo.GetUserAndData(justuser.UsernumberID);
                    WriteLine($"Username: {justuser.Username}");
                    if (userwithdata.Data == null)
                        WriteLine($"No Data for {justuser.BusinessName}");
                    else
                    {
                        foreach(var p in userwithdata.Data)
                            WriteLine($"\n Job for : {p.Pointname}, Description:  {p.Description}");
                    }
                }
                //Add a user point to the User repo
                userRepo.Add(new Point() { UserIDFK = 2, Pointname = "VeggieGarden", Description = "Pull all weeds out and clean up edges" });
                userRepo.Add(new Point() { UserIDFK = 2346, Pointname = "BoomBoom", Description = "Pull all Boom out of Boom" });
                //Add a user point to the User repo
                userRepo.Add(new Point() { UserIDFK = 1, Pointname = "VeggieGarden", Description = "Pull all weeds out and clean up edges" });
                userRepo.Add(new Point() { UserIDFK = 2345, Pointname = "B", Description = "P" });

                userRepo.Add(new Point() { UserIDFK = 1, Pointname = "VeggieGarden", Description = "Pull all weeds out and clean up edges" });
                userRepo.Add(new Point() { UserIDFK = 2345, Pointname = "C", Description = "C" });

            }

            Console.ReadLine();


            using (var userRepo = new UserRepo())
            {
                userRepo.DeleteUserByID(2345);
                userRepo.DeleteUserByID(2345);
                userRepo.DeleteUserByID(2346);
                userRepo.DeleteUserByID(2344);
                userRepo.DeleteUserByID(2);


                //Get all the user out of the data base again
                foreach (var justuser in userRepo.GetAll())
                {
                    var userwithdata = userRepo.GetUserAndData(justuser.UsernumberID);
                    WriteLine($"Username: {justuser.Username}");
                    if (userwithdata.Data == null)
                        WriteLine($"No Data for {justuser.BusinessName}");
                    else
                    {
                        foreach (var p in userwithdata.Data)
                            WriteLine($"\n Job for : {p.Pointname}, Description:  {p.Description}");
                    }
                }
            }


            Console.ReadLine();

            //Getone(id)
            //    UD1 = userRepo.GetOne(2);
            //    WriteLine($"Get One Data {UD1.BusinessName}");
            //}
            //Point temppoint;
            //using (var pointRepo = new PointRepo())
            //{
            //    pointRepo.Add(new Point() { PointId = 4000, Pointname = "sippy"});
            //    temppoint = pointRepo.GetOne(4001);
            //    temppoint.SetUrl("http://www.google.com");
            //    pointRepo.Save(temppoint);



            //    //Seeting the URL works
            //    foreach (var pnt in pointRepo.GetAll())
            //    {
            //        WriteLine($"Pointname: {pnt.Pointname} URL: {pnt.Url}");
            //    }
            //}

            //using (var userRepo = new UserRepo())
            //{
            //    if (UD1.Data == null)
            //        UD1.Data = new List<Point>();
            //    UD1.Data.Add(temppoint);
            //    userRepo.Save(UD1);


            //    UD1 = userRepo.GetOne(2);
            //    WriteLine($"Get One Data {UD1.BusinessName} data count: {UD1.Data.Count}");

            //}

            //    Console.WriteLine();
            //iterate throught the users

        }
    }
}