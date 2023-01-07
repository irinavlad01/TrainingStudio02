﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingStudio02.Data;

#nullable disable

namespace TrainingStudio02.Migrations
{
    [DbContext(typeof(TrainingStudio02Context))]
    [Migration("20230107211849_MembersSubscriptions")]
    partial class MembersSubscriptions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrainingStudio02.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TrainingStudio02.Models.FitnessClass", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TrainerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("TrainerID");

                    b.ToTable("FitnessClass");
                });

            modelBuilder.Entity("TrainingStudio02.Models.FitnessClassCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("FitnessClassID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("FitnessClassID");

                    b.ToTable("FitnessClassCategory");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Subscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("FitnessClassID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("FitnessClassID");

                    b.HasIndex("MemberID");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Trainer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("TrainingStudio02.Models.FitnessClass", b =>
                {
                    b.HasOne("TrainingStudio02.Models.Location", "Location")
                        .WithMany("FitnessClasses")
                        .HasForeignKey("LocationID");

                    b.HasOne("TrainingStudio02.Models.Trainer", "Trainer")
                        .WithMany("FitnessClasses")
                        .HasForeignKey("TrainerID");

                    b.Navigation("Location");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TrainingStudio02.Models.FitnessClassCategory", b =>
                {
                    b.HasOne("TrainingStudio02.Models.Category", "Category")
                        .WithMany("FitnessClassCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingStudio02.Models.FitnessClass", "FitnessClass")
                        .WithMany("FitnessClassCategories")
                        .HasForeignKey("FitnessClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FitnessClass");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Subscription", b =>
                {
                    b.HasOne("TrainingStudio02.Models.FitnessClass", "FitnessClass")
                        .WithMany("Subscriptions")
                        .HasForeignKey("FitnessClassID");

                    b.HasOne("TrainingStudio02.Models.Member", "Member")
                        .WithMany("Subscriptions")
                        .HasForeignKey("MemberID");

                    b.Navigation("FitnessClass");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Category", b =>
                {
                    b.Navigation("FitnessClassCategories");
                });

            modelBuilder.Entity("TrainingStudio02.Models.FitnessClass", b =>
                {
                    b.Navigation("FitnessClassCategories");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Location", b =>
                {
                    b.Navigation("FitnessClasses");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Member", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("TrainingStudio02.Models.Trainer", b =>
                {
                    b.Navigation("FitnessClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
