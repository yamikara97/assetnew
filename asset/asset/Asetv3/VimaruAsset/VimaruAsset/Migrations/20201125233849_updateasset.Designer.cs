﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VimaruAsset.Data;

namespace VimaruAsset.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201125233849_updateasset")]
    partial class updateasset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VimaruAsset.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastOnline")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("VimaruAsset.Models.AssetGroups", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetGroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AssetTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AtrophyPercent")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LifeTime")
                        .HasColumnType("int");

                    b.Property<int>("LifeTimeMin")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("AssetGroups");
                });

            modelBuilder.Entity("VimaruAsset.Models.AssetTypes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("VimaruAsset.Models.Assets", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AidSource")
                        .HasColumnType("float");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("AnotherSource")
                        .HasColumnType("float");

                    b.Property<Guid?>("AssetGroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BudgetSource")
                        .HasColumnType("float");

                    b.Property<double>("CareerSource")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("CurrentUses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUse")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Guarantee")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MFG")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TechnicalData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehiclePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WareHouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Wattage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("WeightHandle")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AssetGroupsId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UnitId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("VimaruAsset.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("VimaruAsset.Models.Exploit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unitname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Exploits");
                });

            modelBuilder.Entity("VimaruAsset.Models.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("VimaruAsset.Models.PlanAssets", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountExpected")
                        .HasColumnType("float");

                    b.Property<int>("BuyingMethod")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Estimate")
                        .HasColumnType("float");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PriceExpected")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeExpected")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TypesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TypesId");

                    b.HasIndex("UnitId");

                    b.ToTable("PlanAsset");
                });

            modelBuilder.Entity("VimaruAsset.Models.ReductionHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DayMove")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frombook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberofAsset")
                        .HasColumnType("int");

                    b.Property<string>("PersonMove")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToBook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReductionHistories");
                });

            modelBuilder.Entity("VimaruAsset.Models.ShoppingPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Phongban")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShoppingPlan");
                });

            modelBuilder.Entity("VimaruAsset.Models.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("VimaruAsset.Models.WareHouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WHStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("departmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("departmentId");

                    b.ToTable("WareHouse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("VimaruAsset.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("VimaruAsset.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VimaruAsset.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("VimaruAsset.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VimaruAsset.Models.ApplicationUser", b =>
                {
                    b.HasOne("VimaruAsset.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("VimaruAsset.Models.AssetGroups", b =>
                {
                    b.HasOne("VimaruAsset.Models.AssetTypes", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId");
                });

            modelBuilder.Entity("VimaruAsset.Models.Assets", b =>
                {
                    b.HasOne("VimaruAsset.Models.AssetGroups", "AssetGroups")
                        .WithMany()
                        .HasForeignKey("AssetGroupsId");

                    b.HasOne("VimaruAsset.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("VimaruAsset.Models.AssetTypes", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("VimaruAsset.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.HasOne("VimaruAsset.Models.WareHouse", "WareHouse")
                        .WithMany()
                        .HasForeignKey("WareHouseId");
                });

            modelBuilder.Entity("VimaruAsset.Models.Exploit", b =>
                {
                    b.HasOne("VimaruAsset.Models.Assets", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId");
                });

            modelBuilder.Entity("VimaruAsset.Models.PlanAssets", b =>
                {
                    b.HasOne("VimaruAsset.Models.AssetTypes", "Types")
                        .WithMany()
                        .HasForeignKey("TypesId");

                    b.HasOne("VimaruAsset.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("VimaruAsset.Models.WareHouse", b =>
                {
                    b.HasOne("VimaruAsset.Models.Department", "department")
                        .WithMany()
                        .HasForeignKey("departmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
