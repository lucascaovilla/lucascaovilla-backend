﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PostgresDataContext))]
    partial class PostgresDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.HomeBanner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundImageAlt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BackgroundImageAvifSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BackgroundImageHeight")
                        .HasColumnType("integer");

                    b.Property<string>("BackgroundImageSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BackgroundImageWebpSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BackgroundImageWidth")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("HomeBanner");
                });
#pragma warning restore 612, 618
        }
    }
}
