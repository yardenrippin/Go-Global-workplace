﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_workeplae;

namespace My_workeplae.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("My_workeplae.Modles.Employees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Last_Update");

                    b.Property<int>("ManagerID");

                    b.HasKey("ID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("My_workeplae.Modles.Managers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("My_workeplae.Modles.Employees", b =>
                {
                    b.HasOne("My_workeplae.Modles.Managers", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
