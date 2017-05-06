using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SQLitedllVM.Models;

namespace SQLitedllVM.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("SQLitedllVM.Models.Point", b =>
                {
                    b.Property<int>("JodId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<string>("Invoicenumber");

                    b.Property<string>("Jobname")
                        .IsRequired();

                    b.Property<bool>("Signedoff");

                    b.Property<int?>("Usernumber");

                    b.HasKey("JodId");

                    b.HasIndex("Usernumber");

                    b.ToTable("UserPoints");
                });

            modelBuilder.Entity("SQLitedllVM.Models.Userdetail", b =>
                {
                    b.Property<int>("Usernumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessName")
                        .HasMaxLength(12);

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(16);

                    b.Property<string>("Username")
                        .HasMaxLength(12);

                    b.HasKey("Usernumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SQLitedllVM.Models.Point", b =>
                {
                    b.HasOne("SQLitedllVM.Models.Userdetail", "Userdetail")
                        .WithMany("Data")
                        .HasForeignKey("Usernumber");
                });
        }
    }
}
