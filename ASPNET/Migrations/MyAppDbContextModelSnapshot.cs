﻿// <auto-generated />
using System;
using ASPNET.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPNET.Migrations
{
    [DbContext(typeof(MyAppDbContext))]
    partial class MyAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASPNET.Models.Category", b =>
                {
                    b.Property<int>("ID_Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Category"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RowInsertTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RowUpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID_Category");

                    b.ToTable("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}