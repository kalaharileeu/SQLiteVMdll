What did I do here:
-created the dll core app
-created the models
--edit the .csproj file
-Compiled in vidual studio
--Did not add packages through NuGet manager.

-opened the project in command line, "ran dotnet restore" from command line
that installed all my packages for me
-ran "dotnet ef migrations add InitialCreate" from CMD
-ran "dotnet ef database update" from CMD
---If any update issues deleted the old migration files--
---I also deleted the old .db in the bin\debug\blah blah file to create the new, had to, complain---

C:\Users\cdelange\Documents\Visual Studio 2017\ProjectsCore\APICoreABC\SqliteDBuser>dotnet ef migrations add InitialCreate

this sort of worked form this website:
Could not migrate or creat the db had to follow the below website
https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite

With the below website I could migrate a new sqlite db
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations#introduction-to-migrations
-This website follow the migration from command line
-Sit in the project folder in command line and type:
dotnet ef migrations add InitialCreate

-This will creat the initial migration files then:
dotnet ef database update

Note
If you see an error message No executable found matching command "dotnet-ef", see this blog post for help troubleshooting.
http://thedatafarm.com/data-access/no-executable-found-matching-command-dotnet-ef/


Did not use this site that much but it has a little repo pattern that I want to use
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api


Problems You May Encounter with ‘dotnet ef’ from:
http://thedatafarm.com/data-access/no-executable-found-matching-command-dotnet-ef/
While some of these notes are specific to the project.json use in the course,
I’ve also added tips for using dotnet ef with the newer csproj/msbuild support.

There are a few key things to watch out for.

The current stable tooling for EF Core migrations is split into two packages.
     Microsoft.EntityFrameworkCore.Tools is for PowerShell
    Microsoft.EntityFrameworkCore.Tools.DotNet is for the CLI (dotnet commands)
Be sure you’ve referenced the Tools.DotNet version of the package so that you have access to the CLI commands. 
If you’re following my course, that’s explained.
dotnet ef only works in .NET Core projects. If your project targets the full .NET framework, then you’ll need to
use the PowerShell commands e.g. add-migration, update-database.
Make sure that you are running the command from the folder that contains the project where the Tools package is
referenced. This is explained in the course demos, but still a step you may overlook in your excitement!

-Bug workaround for the .dll. This is only for .dll projects with not .exe
Add this: <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
in the project file like so:
  <PropertyGroup>
    <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
    <TargetFramework>netcoreapp1.1</TargetFramework>
  </PropertyGroup>
  as described here:
  https://github.com/aspnet/EntityFramework/issues/7889
