using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SQLitedllVM.Models;

namespace SQLitedllVM.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20170509100115_InitialGin")]
    partial class InitialGin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("SQLitedllVM.Models.Point", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<string>("Invoicenumber");

                    b.Property<string>("Pointname")
                        .IsRequired();

                    b.Property<bool>("Signedoff");

                    b.Property<int>("UserForeignKey");

                    b.Property<int?>("UsernumberID1");

                    b.HasKey("PointId");

                    b.HasIndex("UserForeignKey");

                    b.HasIndex("UsernumberID1");

                    b.ToTable("UserPoints");
                });

            modelBuilder.Entity("SQLitedllVM.Models.User", b =>
                {
                    b.Property<int>("UsernumberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessName")
                        .HasMaxLength(12);

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(16);

                    b.Property<string>("Username")
                        .HasMaxLength(12);

                    b.HasKey("UsernumberID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SQLitedllVM.Models.Point", b =>
                {
                    b.HasOne("SQLitedllVM.Models.User")
                        .WithMany("Data")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SQLitedllVM.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UsernumberID1");
                });
        }
    }
}
