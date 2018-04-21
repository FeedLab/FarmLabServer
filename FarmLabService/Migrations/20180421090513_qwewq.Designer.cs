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
    [Migration("20180421090513_qwewq")]
    partial class qwewq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FarmLabService.DataObjects.FarmItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("FarmName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Farm");
                });

            modelBuilder.Entity("FarmLabService.DataObjects.UserItem", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid?>("FarmId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Token")
                        .IsRequired();

                    b.HasKey("Email");

                    b.HasIndex("FarmId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FarmLabService.DataObjects.UserItem", b =>
                {
                    b.HasOne("FarmLabService.DataObjects.FarmItem", "Farm")
                        .WithMany()
                        .HasForeignKey("FarmId");
                });
#pragma warning restore 612, 618
        }
    }
}
