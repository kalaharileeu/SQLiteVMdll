using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SQLitedllVM.Models;

namespace SQLitedllVM.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20170502193724_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("SQLitedllVM.Models.Point", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserdetailUsername");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id");

                    b.HasIndex("UserdetailUsername");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("SQLitedllVM.Models.Userdetail", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessName");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Password")
                        .HasMaxLength(15);

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SQLitedllVM.Models.Point", b =>
                {
                    b.HasOne("SQLitedllVM.Models.Userdetail")
                        .WithMany("Data")
                        .HasForeignKey("UserdetailUsername");
                });
        }
    }
}
