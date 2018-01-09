USE [master]
GO
/****** Object:  Database [BSAdmin]    Script Date: 11/8/2017 2:25:35 PM ******/
CREATE DATABASE [BSAdmin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BSAdmin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BSAdmin.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BSAdmin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BSAdmin_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BSAdmin] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BSAdmin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BSAdmin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BSAdmin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BSAdmin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BSAdmin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BSAdmin] SET ARITHABORT OFF 
GO
ALTER DATABASE [BSAdmin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BSAdmin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BSAdmin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BSAdmin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BSAdmin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BSAdmin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BSAdmin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BSAdmin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BSAdmin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BSAdmin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BSAdmin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BSAdmin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BSAdmin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BSAdmin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BSAdmin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BSAdmin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BSAdmin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BSAdmin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BSAdmin] SET  MULTI_USER 
GO
ALTER DATABASE [BSAdmin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BSAdmin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BSAdmin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BSAdmin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BSAdmin] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BSAdmin]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 11/8/2017 2:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Push_Raw_data]    Script Date: 11/8/2017 2:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Push_Raw_data](
	[Id] [uniqueidentifier] NOT NULL,
	[OpenId] [nvarchar](200) NULL,
	[message] [text] NULL,
	[PushTime] [datetime] NULL,
	[Type] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[Disabled] [int] NULL,
 CONSTRAINT [PK_Push_Raw_data] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RechargeFiled]    Script Date: 11/8/2017 2:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RechargeFiled](
	[Id] [uniqueidentifier] NOT NULL,
	[RechargeAmount] [decimal](18, 0) NULL,
	[GiftAmount] [decimal](18, 0) NULL,
	[GiftIntegral] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[Disabled] [int] NULL,
 CONSTRAINT [PK_RechargeFiled] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RechargeRecord]    Script Date: 11/8/2017 2:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RechargeRecord](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NULL,
	[RechargeAmount] [decimal](18, 0) NULL,
	[GiftAmount] [decimal](18, 0) NULL,
	[GiftIntegral] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[Disabled] [int] NULL,
 CONSTRAINT [PK_RechargeRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/8/2017 2:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/8/2017 2:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[RoleName] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[StoreName] [nvarchar](50) NULL,
	[RoleType] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RechargeFiled] ADD  CONSTRAINT [DF_RechargeFiled_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送类型 （1 生日推送 2 消费推送）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Push_Raw_data', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RechargeFiled', @level2type=N'COLUMN',@level2name=N'RechargeAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赠送金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RechargeFiled', @level2type=N'COLUMN',@level2name=N'GiftAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RechargeRecord', @level2type=N'COLUMN',@level2name=N'MemberId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RechargeRecord', @level2type=N'COLUMN',@level2name=N'RechargeAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赠送金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RechargeRecord', @level2type=N'COLUMN',@level2name=N'GiftAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赠送积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RechargeRecord', @level2type=N'COLUMN',@level2name=N'GiftIntegral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色类型(1超级管理员 2 管理员 3 店员)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RoleType'
GO
USE [master]
GO
ALTER DATABASE [BSAdmin] SET  READ_WRITE 
GO
