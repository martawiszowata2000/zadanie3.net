﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zadanie03.Data;

namespace zadanie03.Migrations
{
    [DbContext(typeof(NumContext))]
    [Migration("20210413003332_UpdateData")]
    partial class UpdateData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("zadanie03.Models.Num", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Result")
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("Value")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Number");
                });
#pragma warning restore 612, 618
        }
    }
}
