﻿// <auto-generated />
using FarmLabService.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FarmLabService.Migrations
{
    [DbContext(typeof(FarmLabContext))]
    partial class FarmLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FarmLabService.DataObjects.FarmItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<Guid>("ExternalFarmReference");

                    b.Property<DateTime>("TimeCreate");

                    b.Property<DateTime>("TimeModify");

                    b.HasKey("Id");

                    b.ToTable("Farm");
                });

            modelBuilder.Entity("FarmLabService.DataObjects.SessionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsValid");

                    b.Property<DateTime>("LastActivity");

                    b.Property<Guid>("SessionKey");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("FarmLabService.DataObjects.UserItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("FarmId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsConfirmedByMail");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("SessionId");

                    b.Property<DateTime>("TimeCreate");

                    b.Property<DateTime>("TimeModify");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.HasIndex("SessionId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("FarmLabService.DataObjects.UserItem", b =>
                {
                    b.HasOne("FarmLabService.DataObjects.FarmItem", "Farm")
                        .WithMany()
                        .HasForeignKey("FarmId");

                    b.HasOne("FarmLabService.DataObjects.SessionItem", "ActiveSession")
                        .WithOne("User")
                        .HasForeignKey("FarmLabService.DataObjects.UserItem", "SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
