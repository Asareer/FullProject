﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FullProject.Data;

#nullable disable

namespace FullProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230706183456_newtest")]
    partial class newtest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FullProject.Models.Actions", b =>
                {
                    b.Property<int>("Id_Actions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Actions"), 1L, 1);

                    b.Property<int>("Id_Orders")
                        .HasColumnType("int");

                    b.Property<string>("Note_Actions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Actions")
                        .HasColumnType("int");

                    b.Property<string>("State_Actions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Actions");

                    b.HasIndex("Id_Orders");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("FullProject.Models.ActionsTypes", b =>
                {
                    b.Property<int>("Id_ActionsTypes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_ActionsTypes"), 1L, 1);

                    b.Property<string>("Actions1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Actions2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Actions3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_ActionsTypes");

                    b.ToTable("ActionType");
                });

            modelBuilder.Entity("FullProject.Models.GenerlDatas", b =>
                {
                    b.Property<int>("Id_GeneralDatas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_GeneralDatas"), 1L, 1);

                    b.Property<string>("Addrees_Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cellphone")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Processes2")
                        .HasColumnType("int");

                    b.Property<string>("Name_Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner_Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("P_B")
                        .HasColumnType("int");

                    b.Property<string>("Telecis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("Id_GeneralDatas");

                    b.HasIndex("Id_Processes2");

                    b.ToTable("GenerlData");
                });

            modelBuilder.Entity("FullProject.Models.Orders", b =>
                {
                    b.Property<int>("Id_Orders")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Orders"), 1L, 1);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Order")
                        .HasColumnType("int");

                    b.Property<int>("Num_Process")
                        .HasColumnType("int");

                    b.Property<string>("Paper_Pledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("States")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Orders");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FullProject.Models.Processes2", b =>
                {
                    b.Property<int>("Id_Processes2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Processes2"), 1L, 1);

                    b.Property<int>("Id_Orders")
                        .HasColumnType("int");

                    b.HasKey("Id_Processes2");

                    b.HasIndex("Id_Orders");

                    b.ToTable("Process2");
                });

            modelBuilder.Entity("FullProject.Models.Processes3", b =>
                {
                    b.Property<int>("Id_Processes2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Processes2"), 1L, 1);

                    b.Property<string>("Final_Report")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Orders")
                        .HasColumnType("int");

                    b.Property<string>("Result3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Processes2");

                    b.HasIndex("Id_Orders");

                    b.ToTable("Process3");
                });

            modelBuilder.Entity("FullProject.Models.ProductDatas", b =>
                {
                    b.Property<int>("Id_ProductDatas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_ProductDatas"), 1L, 1);

                    b.Property<string>("Country_Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Expiration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Report")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_production")
                        .HasColumnType("datetime2");

                    b.Property<string>("Homogeneity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Processes3")
                        .HasColumnType("int");

                    b.Property<string>("Item_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Trande")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Batch")
                        .HasColumnType("int");

                    b.Property<int>("Num_Product")
                        .HasColumnType("int");

                    b.Property<int>("Num_Report")
                        .HasColumnType("int");

                    b.Property<int>("Num_Sample")
                        .HasColumnType("int");

                    b.Property<int>("Numper")
                        .HasColumnType("int");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result_Report")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<double>("Size2")
                        .HasColumnType("float");

                    b.Property<string>("Smell")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Taste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type_Package")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<string>("match_Periods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("match_Statment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_ProductDatas");

                    b.HasIndex("Id_Processes3");

                    b.ToTable("ProductData");
                });

            modelBuilder.Entity("FullProject.Models.ProductTypes", b =>
                {
                    b.Property<int>("Id_ProductTypes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_ProductTypes"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class_Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Product")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Processes2")
                        .HasColumnType("int");

                    b.Property<int>("Num_Class")
                        .HasColumnType("int");

                    b.Property<int>("Num_Register")
                        .HasColumnType("int");

                    b.Property<string>("productivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_ProductTypes");

                    b.HasIndex("Id_Processes2");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("FullProject.Models.Projects", b =>
                {
                    b.Property<int>("Id_Projects")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Projects"), 1L, 1);

                    b.Property<DateTime>("Date_Project")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Orders")
                        .HasColumnType("int");

                    b.Property<string>("Locate_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Num_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner2_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Property_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("area_Project")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Projects");

                    b.HasIndex("Id_Orders");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("FullProject.Models.StartActivities", b =>
                {
                    b.Property<int>("Id_StartActivities")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_StartActivities"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Orders")
                        .HasColumnType("int");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_StartActivities");

                    b.HasIndex("Id_Orders");

                    b.ToTable("StartActivity");
                });

            modelBuilder.Entity("FullProject.Models.TaxPayers", b =>
                {
                    b.Property<int>("Id_TaxPayers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_TaxPayers"), 1L, 1);

                    b.Property<DateTime>("Date_H")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_M")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day_TaxPayers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Processes2")
                        .HasColumnType("int");

                    b.Property<string>("Name_TaxPayers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_TaxPayers")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time_TaxPayers")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_TaxPayers");

                    b.HasIndex("Id_Processes2");

                    b.ToTable("TaxPayer");
                });

            modelBuilder.Entity("FullProject.Models.Actions", b =>
                {
                    b.HasOne("FullProject.Models.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("Id_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FullProject.Models.GenerlDatas", b =>
                {
                    b.HasOne("FullProject.Models.Processes2", "Processes2")
                        .WithMany("GenerlData")
                        .HasForeignKey("Id_Processes2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Processes2");
                });

            modelBuilder.Entity("FullProject.Models.Processes2", b =>
                {
                    b.HasOne("FullProject.Models.Orders", "Order")
                        .WithMany("Process2")
                        .HasForeignKey("Id_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FullProject.Models.Processes3", b =>
                {
                    b.HasOne("FullProject.Models.Orders", "Order")
                        .WithMany("Process3")
                        .HasForeignKey("Id_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FullProject.Models.ProductDatas", b =>
                {
                    b.HasOne("FullProject.Models.Processes3", "Processes3")
                        .WithMany("ProductData")
                        .HasForeignKey("Id_Processes3")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Processes3");
                });

            modelBuilder.Entity("FullProject.Models.ProductTypes", b =>
                {
                    b.HasOne("FullProject.Models.Processes2", "Processes2")
                        .WithMany("ProductType")
                        .HasForeignKey("Id_Processes2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Processes2");
                });

            modelBuilder.Entity("FullProject.Models.Projects", b =>
                {
                    b.HasOne("FullProject.Models.Orders", "Order")
                        .WithMany("Projects")
                        .HasForeignKey("Id_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FullProject.Models.StartActivities", b =>
                {
                    b.HasOne("FullProject.Models.Orders", "Order")
                        .WithMany("StartActivity")
                        .HasForeignKey("Id_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FullProject.Models.TaxPayers", b =>
                {
                    b.HasOne("FullProject.Models.Processes2", "Processes2")
                        .WithMany("TaxPayer")
                        .HasForeignKey("Id_Processes2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Processes2");
                });

            modelBuilder.Entity("FullProject.Models.Orders", b =>
                {
                    b.Navigation("Process2");

                    b.Navigation("Process3");

                    b.Navigation("Projects");

                    b.Navigation("StartActivity");
                });

            modelBuilder.Entity("FullProject.Models.Processes2", b =>
                {
                    b.Navigation("GenerlData");

                    b.Navigation("ProductType");

                    b.Navigation("TaxPayer");
                });

            modelBuilder.Entity("FullProject.Models.Processes3", b =>
                {
                    b.Navigation("ProductData");
                });
#pragma warning restore 612, 618
        }
    }
}
