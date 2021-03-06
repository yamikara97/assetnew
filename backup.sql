USE [master]
GO
/****** Object:  Database [Vimaru_asset]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE DATABASE [Vimaru_asset]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vimaru_asset', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Vimaru_asset.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Vimaru_asset_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Vimaru_asset_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Vimaru_asset] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vimaru_asset].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vimaru_asset] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vimaru_asset] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vimaru_asset] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vimaru_asset] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vimaru_asset] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vimaru_asset] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Vimaru_asset] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vimaru_asset] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vimaru_asset] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vimaru_asset] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vimaru_asset] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vimaru_asset] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vimaru_asset] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vimaru_asset] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vimaru_asset] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Vimaru_asset] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vimaru_asset] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vimaru_asset] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vimaru_asset] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vimaru_asset] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vimaru_asset] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Vimaru_asset] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vimaru_asset] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Vimaru_asset] SET  MULTI_USER 
GO
ALTER DATABASE [Vimaru_asset] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vimaru_asset] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vimaru_asset] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vimaru_asset] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Vimaru_asset] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Vimaru_asset]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[DepartmentId] [uniqueidentifier] NULL,
	[DateCreate] [datetime2](7) NULL,
	[LastOnline] [datetime2](7) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssetGroups]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AssetGroupCode] [nvarchar](max) NOT NULL,
	[LifeTimeMin] [int] NOT NULL,
	[LifeTime] [int] NOT NULL,
	[AtrophyPercent] [real] NOT NULL,
	[AssetTypeId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_AssetGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Assets]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](15) NULL,
	[MFG] [datetime2](7) NOT NULL,
	[Guarantee] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[TechnicalData] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[Status] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[BudgetSource] [float] NOT NULL,
	[CareerSource] [float] NOT NULL,
	[AidSource] [float] NOT NULL,
	[AnotherSource] [float] NOT NULL,
	[ManufacturerId] [uniqueidentifier] NULL,
	[UnitId] [uniqueidentifier] NULL,
	[TypeId] [uniqueidentifier] NULL,
	[AssetGroupsId] [uniqueidentifier] NULL,
	[WareHouseId] [uniqueidentifier] NULL,
	[SeatNumber] [int] NOT NULL,
	[VehiclePlate] [nvarchar](max) NULL,
	[WeightHandle] [real] NOT NULL,
	[Wattage] [nvarchar](max) NULL,
	[Reason] [nvarchar](max) NULL,
	[CurrentUses] [nvarchar](max) NULL,
	[DateUse] [datetime2](7) NOT NULL,
	[Amount] [int] NOT NULL,
	[IsConfirm] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[identify] [uniqueidentifier] NOT NULL DEFAULT ('00000000-0000-0000-0000-000000000000'),
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssetTypes]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[AssetTypeName] [nvarchar](max) NOT NULL,
	[AssetTypeCode] [nvarchar](max) NOT NULL,
	[Detail] [nvarchar](max) NULL,
 CONSTRAINT [PK_AssetTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[ManagerName] [nvarchar](max) NULL,
	[FatherID] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exploits]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exploits](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[AssetId] [uniqueidentifier] NULL,
	[Unitname] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[Purpose] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Exploits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](10) NULL,
	[Address] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlanAsset]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanAsset](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[TypesId] [uniqueidentifier] NULL,
	[Method] [nvarchar](max) NULL,
	[UnitId] [uniqueidentifier] NULL,
	[Describe] [nvarchar](max) NULL,
	[TimeExpected] [datetime2](7) NOT NULL,
	[AmountExpected] [float] NOT NULL,
	[PriceExpected] [float] NOT NULL,
	[BuyingMethod] [int] NOT NULL,
	[Estimate] [float] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[PlanId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PlanAsset] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReductionHistories]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReductionHistories](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Reason] [nvarchar](max) NULL,
	[FromDepartment] [nvarchar](max) NULL,
	[ToDepartment] [nvarchar](max) NULL,
	[Frombook] [nvarchar](max) NULL,
	[ToBook] [nvarchar](max) NULL,
	[NumberofAsset] [int] NOT NULL,
	[DayMove] [datetime2](7) NOT NULL,
	[PersonMove] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReductionHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShoppingPlan]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingPlan](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Year] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Phongban] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ShoppingPlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Units]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[UnitName] [nvarchar](max) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 4/23/2021 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouse](
	[Id] [uniqueidentifier] NOT NULL,
	[DateUpdate] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[WHStatus] [nvarchar](max) NULL,
	[departmentId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_DepartmentId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_DepartmentId] ON [dbo].[AspNetUsers]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AssetGroups_AssetTypeId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_AssetGroups_AssetTypeId] ON [dbo].[AssetGroups]
(
	[AssetTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Assets_AssetGroupsId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assets_AssetGroupsId] ON [dbo].[Assets]
(
	[AssetGroupsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Assets_ManufacturerId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assets_ManufacturerId] ON [dbo].[Assets]
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Assets_TypeId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assets_TypeId] ON [dbo].[Assets]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Assets_UnitId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assets_UnitId] ON [dbo].[Assets]
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Assets_WareHouseId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assets_WareHouseId] ON [dbo].[Assets]
(
	[WareHouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exploits_AssetId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Exploits_AssetId] ON [dbo].[Exploits]
(
	[AssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlanAsset_TypesId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlanAsset_TypesId] ON [dbo].[PlanAsset]
(
	[TypesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlanAsset_UnitId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlanAsset_UnitId] ON [dbo].[PlanAsset]
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WareHouse_departmentId]    Script Date: 4/23/2021 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_WareHouse_departmentId] ON [dbo].[WareHouse]
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Department_DepartmentId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AssetGroups]  WITH CHECK ADD  CONSTRAINT [FK_AssetGroups_AssetTypes_AssetTypeId] FOREIGN KEY([AssetTypeId])
REFERENCES [dbo].[AssetTypes] ([Id])
GO
ALTER TABLE [dbo].[AssetGroups] CHECK CONSTRAINT [FK_AssetGroups_AssetTypes_AssetTypeId]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_AssetGroups_AssetGroupsId] FOREIGN KEY([AssetGroupsId])
REFERENCES [dbo].[AssetGroups] ([Id])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_AssetGroups_AssetGroupsId]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_AssetTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[AssetTypes] ([Id])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_AssetTypes_TypeId]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_Manufacturers_ManufacturerId] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([Id])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_Manufacturers_ManufacturerId]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_Units_UnitId] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([Id])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_Units_UnitId]
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD  CONSTRAINT [FK_Assets_WareHouse_WareHouseId] FOREIGN KEY([WareHouseId])
REFERENCES [dbo].[WareHouse] ([Id])
GO
ALTER TABLE [dbo].[Assets] CHECK CONSTRAINT [FK_Assets_WareHouse_WareHouseId]
GO
ALTER TABLE [dbo].[Exploits]  WITH CHECK ADD  CONSTRAINT [FK_Exploits_Assets_AssetId] FOREIGN KEY([AssetId])
REFERENCES [dbo].[Assets] ([Id])
GO
ALTER TABLE [dbo].[Exploits] CHECK CONSTRAINT [FK_Exploits_Assets_AssetId]
GO
ALTER TABLE [dbo].[PlanAsset]  WITH CHECK ADD  CONSTRAINT [FK_PlanAsset_AssetTypes_TypesId] FOREIGN KEY([TypesId])
REFERENCES [dbo].[AssetTypes] ([Id])
GO
ALTER TABLE [dbo].[PlanAsset] CHECK CONSTRAINT [FK_PlanAsset_AssetTypes_TypesId]
GO
ALTER TABLE [dbo].[PlanAsset]  WITH CHECK ADD  CONSTRAINT [FK_PlanAsset_Units_UnitId] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([Id])
GO
ALTER TABLE [dbo].[PlanAsset] CHECK CONSTRAINT [FK_PlanAsset_Units_UnitId]
GO
ALTER TABLE [dbo].[WareHouse]  WITH CHECK ADD  CONSTRAINT [FK_WareHouse_Department_departmentId] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[WareHouse] CHECK CONSTRAINT [FK_WareHouse_Department_departmentId]
GO
USE [master]
GO
ALTER DATABASE [Vimaru_asset] SET  READ_WRITE 
GO
