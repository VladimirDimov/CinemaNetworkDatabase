USE [master]
GO
/****** Object:  Database [CinameNetwork]    Script Date: 10/19/2015 3:16:39 PM ******/
CREATE DATABASE [CinameNetwork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinameNetwork', FILENAME = N'F:\Telerik\11_DataBases\CinemaNetworkDatabase\CinameNetwork.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CinameNetwork_log', FILENAME = N'F:\Telerik\11_DataBases\CinemaNetworkDatabase\CinameNetwork_log.ldf' , SIZE = 10176KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CinameNetwork] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinameNetwork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinameNetwork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinameNetwork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinameNetwork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinameNetwork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinameNetwork] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinameNetwork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinameNetwork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinameNetwork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinameNetwork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinameNetwork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinameNetwork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinameNetwork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinameNetwork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinameNetwork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinameNetwork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinameNetwork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinameNetwork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinameNetwork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinameNetwork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinameNetwork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinameNetwork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinameNetwork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinameNetwork] SET RECOVERY FULL 
GO
ALTER DATABASE [CinameNetwork] SET  MULTI_USER 
GO
ALTER DATABASE [CinameNetwork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinameNetwork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinameNetwork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinameNetwork] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CinameNetwork] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CinameNetwork', N'ON'
GO
USE [CinameNetwork]
GO
/****** Object:  Table [dbo].[Cinemas]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cinemas](
	[CinemaId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[TownId] [int] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Cinemas] PRIMARY KEY CLUSTERED 
(
	[CinemaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genders]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genres]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movies]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[GenreId] [int] NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[Director] [int] NOT NULL,
	[Actors] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[CoverLink] [nvarchar](500) NULL,
	[Subtitles] [bit] NOT NULL,
	[DurationMinutes] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MoviesActors]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesActors](
	[MovieId] [int] NOT NULL,
	[Actor] [int] NOT NULL,
 CONSTRAINT [PK_MoviesActors] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[Actor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[GenderId] [int] NOT NULL,
	[BirthYear] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shows]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shows](
	[ShowId] [int] IDENTITY(1,1) NOT NULL,
	[CienemaId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Shows] PRIMARY KEY CLUSTERED 
(
	[ShowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 10/19/2015 3:16:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Movies] ADD  CONSTRAINT [DF_Movies_Subtitles]  DEFAULT ((0)) FOR [Subtitles]
GO
ALTER TABLE [dbo].[Cinemas]  WITH CHECK ADD  CONSTRAINT [FK_Cinemas_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Cinemas] CHECK CONSTRAINT [FK_Cinemas_Towns]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Country]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Person] FOREIGN KEY([Director])
REFERENCES [dbo].[People] ([PersonId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Person]
GO
ALTER TABLE [dbo].[MoviesActors]  WITH CHECK ADD  CONSTRAINT [FK_MoviesActors_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[MoviesActors] CHECK CONSTRAINT [FK_MoviesActors_Movies]
GO
ALTER TABLE [dbo].[MoviesActors]  WITH CHECK ADD  CONSTRAINT [FK_MoviesActors_Person] FOREIGN KEY([Actor])
REFERENCES [dbo].[People] ([PersonId])
GO
ALTER TABLE [dbo].[MoviesActors] CHECK CONSTRAINT [FK_MoviesActors_Person]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_Person_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_Person_Country]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_Person_Genders] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([GenderId])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_Person_Genders]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Cinemas] FOREIGN KEY([CienemaId])
REFERENCES [dbo].[Cinemas] ([CinemaId])
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Cinemas]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Movies]
GO
USE [master]
GO
ALTER DATABASE [CinameNetwork] SET  READ_WRITE 
GO
