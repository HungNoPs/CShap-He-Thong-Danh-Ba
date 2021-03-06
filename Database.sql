USE [master]
GO
/****** Object:  Database [QLDANHBA]    Script Date: 1/9/2022 6:34:33 PM ******/
CREATE DATABASE [QLDANHBA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDANHBA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLDANHBA.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLDANHBA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLDANHBA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLDANHBA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLDANHBA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLDANHBA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLDANHBA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLDANHBA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLDANHBA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLDANHBA] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLDANHBA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLDANHBA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLDANHBA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLDANHBA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLDANHBA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLDANHBA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLDANHBA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLDANHBA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLDANHBA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLDANHBA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLDANHBA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLDANHBA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLDANHBA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLDANHBA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLDANHBA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLDANHBA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLDANHBA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLDANHBA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLDANHBA] SET  MULTI_USER 
GO
ALTER DATABASE [QLDANHBA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLDANHBA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLDANHBA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLDANHBA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLDANHBA] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLDANHBA]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 1/9/2022 6:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[PhoneID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[RelationshipID] [bigint] NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[PhoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relationship]    Script Date: 1/9/2022 6:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relationship](
	[RelationshipID] [bigint] IDENTITY(1,1) NOT NULL,
	[RelationshipName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Relationship] PRIMARY KEY CLUSTERED 
(
	[RelationshipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Relationship] FOREIGN KEY([RelationshipID])
REFERENCES [dbo].[Relationship] ([RelationshipID])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Relationship]
GO
USE [master]
GO
ALTER DATABASE [QLDANHBA] SET  READ_WRITE 
GO
