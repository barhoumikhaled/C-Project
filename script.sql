USE [master]
GO
/****** Object:  Database [gestioncontact]    Script Date: 8/31/2015 1:50:07 PM ******/
CREATE DATABASE [gestioncontact]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gestioncontact', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\gestioncontact.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gestioncontact_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\gestioncontact_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [gestioncontact] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gestioncontact].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gestioncontact] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gestioncontact] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gestioncontact] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gestioncontact] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gestioncontact] SET ARITHABORT OFF 
GO
ALTER DATABASE [gestioncontact] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [gestioncontact] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gestioncontact] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gestioncontact] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gestioncontact] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gestioncontact] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gestioncontact] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gestioncontact] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gestioncontact] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gestioncontact] SET  ENABLE_BROKER 
GO
ALTER DATABASE [gestioncontact] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gestioncontact] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gestioncontact] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gestioncontact] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gestioncontact] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gestioncontact] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gestioncontact] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gestioncontact] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gestioncontact] SET  MULTI_USER 
GO
ALTER DATABASE [gestioncontact] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gestioncontact] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gestioncontact] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gestioncontact] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [gestioncontact] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'gestioncontact', N'ON'
GO
USE [gestioncontact]
GO
/****** Object:  Table [dbo].[activities]    Script Date: 8/31/2015 1:50:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[activities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[description] [text] NOT NULL,
	[id_contact] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[adressecontact]    Script Date: 8/31/2015 1:50:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[adressecontact](
	[adresseid] [int] IDENTITY(1,1) NOT NULL,
	[contactid] [int] NOT NULL,
	[rue] [varchar](50) NOT NULL,
	[num] [varchar](50) NOT NULL,
	[codepostal] [varchar](50) NOT NULL,
	[ville] [varchar](50) NOT NULL,
	[province] [varchar](50) NOT NULL,
	[pays] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[adresseid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[adresseuser]    Script Date: 8/31/2015 1:50:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[adresseuser](
	[adresseid] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[rue] [varchar](50) NOT NULL,
	[num] [varchar](50) NOT NULL,
	[codepostal] [varchar](50) NOT NULL,
	[ville] [varchar](50) NOT NULL,
	[province] [varchar](50) NOT NULL,
	[pays] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[adresseid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[contact]    Script Date: 8/31/2015 1:50:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[contact](
	[contactid] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[groupId] [int] NOT NULL,
	[photo] [varchar](150) NULL DEFAULT (''),
PRIMARY KEY CLUSTERED 
(
	[contactid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[groupe]    Script Date: 8/31/2015 1:50:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[groupe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[utilisateur]    Script Date: 8/31/2015 1:50:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[utilisateur](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[prenom] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[mdp] [varchar](50) NOT NULL,
	[photo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[activities] ON 

INSERT [dbo].[activities] ([id], [name], [description], [id_contact], [id_user], [date]) VALUES (2, N'Cinema', N'Lundi soir', 1, 2, CAST(N'2015-09-17 17:00:00.000' AS DateTime))
INSERT [dbo].[activities] ([id], [name], [description], [id_contact], [id_user], [date]) VALUES (3, N'Takwira', N'Samedi matin', 3, 2, CAST(N'2015-10-15 00:03:12.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[activities] OFF
SET IDENTITY_INSERT [dbo].[adressecontact] ON 

INSERT [dbo].[adressecontact] ([adresseid], [contactid], [rue], [num], [codepostal], [ville], [province], [pays]) VALUES (1, 1, N'255', N'255', N'H3n!t1', N'Mtl', N'Qc', N'Ca')
INSERT [dbo].[adressecontact] ([adresseid], [contactid], [rue], [num], [codepostal], [ville], [province], [pays]) VALUES (3, 3, N'255', N'255', N'H3n1t1', N'Mtl', N'Qc', N'Ca')
SET IDENTITY_INSERT [dbo].[adressecontact] OFF
SET IDENTITY_INSERT [dbo].[adresseuser] ON 

INSERT [dbo].[adresseuser] ([adresseid], [userid], [rue], [num], [codepostal], [ville], [province], [pays]) VALUES (1, 2, N'Creamzie', N'255', N'h3n1t1', N'Mtl', N'Qc', N'CA')
INSERT [dbo].[adresseuser] ([adresseid], [userid], [rue], [num], [codepostal], [ville], [province], [pays]) VALUES (2, 4, N'cremazie', N'22', N'h2f2c5', N'montreal', N'quebec', N'canada')
SET IDENTITY_INSERT [dbo].[adresseuser] OFF
SET IDENTITY_INSERT [dbo].[contact] ON 

INSERT [dbo].[contact] ([contactid], [userid], [nom], [prenom], [email], [groupId], [photo]) VALUES (1, 2, N'Ghassan', N'Ghassan', N'Ghassan@Ghassan.ca', 1, N'')
INSERT [dbo].[contact] ([contactid], [userid], [nom], [prenom], [email], [groupId], [photo]) VALUES (3, 2, N'Issa', N'Issa', N'Issa@Issa.ca', 3, N'')
SET IDENTITY_INSERT [dbo].[contact] OFF
SET IDENTITY_INSERT [dbo].[groupe] ON 

INSERT [dbo].[groupe] ([Id], [GroupName]) VALUES (1, N'Amis')
INSERT [dbo].[groupe] ([Id], [GroupName]) VALUES (2, N'Famille')
INSERT [dbo].[groupe] ([Id], [GroupName]) VALUES (3, N'Collegues')
SET IDENTITY_INSERT [dbo].[groupe] OFF
SET IDENTITY_INSERT [dbo].[utilisateur] ON 

INSERT [dbo].[utilisateur] ([userid], [nom], [prenom], [email], [mdp], [photo]) VALUES (1, N'Barhoumi', N'Khaled', N'bar.khaled@gmail.com', N'abc123...', N'')
INSERT [dbo].[utilisateur] ([userid], [nom], [prenom], [email], [mdp], [photo]) VALUES (2, N'Barhoumi', N'Khaled', N'bar.khaled@gmail.com', N'abc123...', N'')
INSERT [dbo].[utilisateur] ([userid], [nom], [prenom], [email], [mdp], [photo]) VALUES (3, N'aouadi', N'ghassen', N'ghasse@gmail.com', N'abc123', N'')
INSERT [dbo].[utilisateur] ([userid], [nom], [prenom], [email], [mdp], [photo]) VALUES (4, N'aouadi', N'ghassen', N'ghasse@gmail.com', N'abc123', N'')
SET IDENTITY_INSERT [dbo].[utilisateur] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [uniqueEmail]    Script Date: 8/31/2015 1:50:07 PM ******/
ALTER TABLE [dbo].[contact] ADD  CONSTRAINT [uniqueEmail] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[activities]  WITH CHECK ADD FOREIGN KEY([id_contact])
REFERENCES [dbo].[contact] ([contactid])
GO
ALTER TABLE [dbo].[activities]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[utilisateur] ([userid])
GO
ALTER TABLE [dbo].[adressecontact]  WITH CHECK ADD FOREIGN KEY([contactid])
REFERENCES [dbo].[contact] ([contactid])
GO
ALTER TABLE [dbo].[adresseuser]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[utilisateur] ([userid])
GO
ALTER TABLE [dbo].[contact]  WITH CHECK ADD FOREIGN KEY([groupId])
REFERENCES [dbo].[groupe] ([Id])
GO
ALTER TABLE [dbo].[contact]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[utilisateur] ([userid])
GO
ALTER TABLE [dbo].[contact]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[utilisateur] ([userid])
GO
USE [master]
GO
ALTER DATABASE [gestioncontact] SET  READ_WRITE 
GO
