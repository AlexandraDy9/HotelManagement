USE [master]
GO
/****** Object:  Database [HotelDataBase]    Script Date: 6/15/2019 7:51:39 AM ******/
CREATE DATABASE [HotelDataBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelDataBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HotelDataBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelDataBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HotelDataBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HotelDataBase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelDataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelDataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelDataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelDataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelDataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelDataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelDataBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelDataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelDataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelDataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelDataBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelDataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelDataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelDataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelDataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelDataBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelDataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelDataBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelDataBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelDataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelDataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelDataBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelDataBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelDataBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelDataBase] SET  MULTI_USER 
GO
ALTER DATABASE [HotelDataBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelDataBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelDataBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelDataBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelDataBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelDataBase] SET QUERY_STORE = OFF
GO
USE [HotelDataBase]
GO
/****** Object:  Table [dbo].[AdditionalServices]    Script Date: 6/15/2019 7:51:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdditionalServices](
	[idServices] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AdditionalServices] PRIMARY KEY CLUSTERED 
(
	[idServices] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[idFeatures] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[idFeatures] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[idPrice] [int] IDENTITY(1,1) NOT NULL,
	[value] [float] NOT NULL,
	[dataStart] [datetime] NOT NULL,
	[dataEnd] [datetime] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[idServices] [int] NULL,
	[idRoom] [int] NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[idPrice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[idReservation] [int] IDENTITY(1,1) NOT NULL,
	[checkIn] [datetime] NOT NULL,
	[checkOut] [datetime] NOT NULL,
	[state] [nchar](10) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[totalPrice] [float] NULL,
	[idUser] [int] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[idReservation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationRoom]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationRoom](
	[idReservation] [int] NOT NULL,
	[idRoom] [int] NOT NULL,
	[number] [int] NOT NULL,
	[idSales] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationServices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationServices](
	[idReservation] [int] NOT NULL,
	[idServices] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_role] [int] NOT NULL,
	[name_role] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[idRoom] [int] IDENTITY(1,1) NOT NULL,
	[type] [nchar](20) NOT NULL,
	[numberOfRooms] [int] NOT NULL,
	[image] [nchar](50) NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[idRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomFeatures](
	[idRoom] [int] NOT NULL,
	[idFeatures] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[idSales] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NULL,
	[price] [float] NOT NULL,
	[dateStart] [datetime] NOT NULL,
	[dateEnd] [datetime] NOT NULL,
	[numberOfDays] [int] NOT NULL,
	[idRoom] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[idSales] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[IdRole] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdditionalServices] ON 

INSERT [dbo].[AdditionalServices] ([idServices], [name], [isDeleted]) VALUES (1, N'spa                                               ', 0)
INSERT [dbo].[AdditionalServices] ([idServices], [name], [isDeleted]) VALUES (2, N'fitness                                           ', 0)
INSERT [dbo].[AdditionalServices] ([idServices], [name], [isDeleted]) VALUES (3, N'mic-dejun                                         ', 0)
INSERT [dbo].[AdditionalServices] ([idServices], [name], [isDeleted]) VALUES (4, N'all-inclusive                                     ', 0)
SET IDENTITY_INSERT [dbo].[AdditionalServices] OFF
SET IDENTITY_INSERT [dbo].[Features] ON 

INSERT [dbo].[Features] ([idFeatures], [name], [isDeleted]) VALUES (1, N'frigider                                          ', 0)
INSERT [dbo].[Features] ([idFeatures], [name], [isDeleted]) VALUES (2, N'aer conditionat                                   ', 0)
INSERT [dbo].[Features] ([idFeatures], [name], [isDeleted]) VALUES (3, N'balcon                                            ', 0)
INSERT [dbo].[Features] ([idFeatures], [name], [isDeleted]) VALUES (4, N'tv                                                ', 0)
INSERT [dbo].[Features] ([idFeatures], [name], [isDeleted]) VALUES (5, N'uscator de par                                    ', 0)
INSERT [dbo].[Features] ([idFeatures], [name], [isDeleted]) VALUES (6, N'halat                                             ', 1)
SET IDENTITY_INSERT [dbo].[Features] OFF
SET IDENTITY_INSERT [dbo].[Prices] ON 

INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (1, 120, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (2, 138.9, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, NULL, 1)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (3, 150, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, NULL, 2)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (4, 110, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, NULL, 3)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (6, 90, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, NULL, 4)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (7, 200, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, NULL, 5)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (8, 180, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, NULL, 6)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (9, 250, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 1, NULL, 7)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (10, 100, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, 2, NULL)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (11, 156.4, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, 3, NULL)
INSERT [dbo].[Prices] ([idPrice], [value], [dataStart], [dataEnd], [isDeleted], [idServices], [idRoom]) VALUES (12, 325.6, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-30T00:00:00.000' AS DateTime), 0, 4, NULL)
SET IDENTITY_INSERT [dbo].[Prices] OFF
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (3, CAST(N'2019-02-02T00:00:00.000' AS DateTime), CAST(N'2019-02-10T00:00:00.000' AS DateTime), N'activ     ', 0, 300, 5)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (4, CAST(N'2019-04-09T00:00:00.000' AS DateTime), CAST(N'2019-04-12T00:00:00.000' AS DateTime), N'anulat    ', 0, 340, 5)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (5, CAST(N'2019-06-07T00:00:00.000' AS DateTime), CAST(N'2019-06-14T00:00:00.000' AS DateTime), N'activ     ', 0, 2620, 8)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (6, CAST(N'2019-07-05T00:00:00.000' AS DateTime), CAST(N'2019-07-09T00:00:00.000' AS DateTime), N'activ     ', 0, 1556.8000000000002, 7)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (7, CAST(N'2019-07-03T00:00:00.000' AS DateTime), CAST(N'2019-07-10T00:00:00.000' AS DateTime), N'activ     ', 0, 3912, 7)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (8, CAST(N'2019-07-05T00:00:00.000' AS DateTime), CAST(N'2019-07-06T00:00:00.000' AS DateTime), N'activ     ', 0, 936.4, 7)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (9, CAST(N'2019-07-04T00:00:00.000' AS DateTime), CAST(N'2019-07-06T00:00:00.000' AS DateTime), N'activ     ', 0, 520, 7)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (10, CAST(N'2019-07-03T00:00:00.000' AS DateTime), CAST(N'2019-07-05T00:00:00.000' AS DateTime), N'activ     ', 0, 420, 7)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (11, CAST(N'2019-07-05T00:00:00.000' AS DateTime), CAST(N'2019-07-06T00:00:00.000' AS DateTime), N'activ     ', 0, 270, 9)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (12, CAST(N'2019-06-07T00:00:00.000' AS DateTime), CAST(N'2019-06-14T00:00:00.000' AS DateTime), N'activ     ', 0, 1120, 9)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (13, CAST(N'2019-06-08T00:00:00.000' AS DateTime), CAST(N'2019-06-15T00:00:00.000' AS DateTime), N'activ     ', 0, 2520, 9)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (14, CAST(N'2019-07-06T00:00:00.000' AS DateTime), CAST(N'2019-07-13T00:00:00.000' AS DateTime), N'activ     ', 0, 1940, 9)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (15, CAST(N'2019-06-08T00:00:00.000' AS DateTime), CAST(N'2019-06-14T00:00:00.000' AS DateTime), N'activ     ', 0, 1020, 7)
INSERT [dbo].[Reservation] ([idReservation], [checkIn], [checkOut], [state], [isDeleted], [totalPrice], [idUser]) VALUES (16, CAST(N'2019-06-08T00:00:00.000' AS DateTime), CAST(N'2019-06-15T00:00:00.000' AS DateTime), N'activ     ', 0, 1220, 5)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (3, 1, 1, NULL)
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (4, 5, 2, NULL)
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (5, 1, 2, 1)
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (5, 6, 1, NULL)
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (13, 1, 2, 1)
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (16, 1, 2, 1)
INSERT [dbo].[ReservationRoom] ([idReservation], [idRoom], [number], [idSales]) VALUES (12, 1, 2, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (5, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (5, 2)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (7, 3)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (7, 4)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (8, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (8, 3)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (9, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (9, 2)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (10, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (11, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (12, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (13, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (16, 1)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (16, 2)
INSERT [dbo].[ReservationServices] ([idReservation], [idServices]) VALUES (15, 1)
INSERT [dbo].[Roles] ([id_role], [name_role]) VALUES (1, N'Admin     ')
INSERT [dbo].[Roles] ([id_role], [name_role]) VALUES (2, N'Client    ')
INSERT [dbo].[Roles] ([id_role], [name_role]) VALUES (3, N'Employee  ')
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (1, N'Double              ', 30, N'Images/double.jpg                                 ', 0)
INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (2, N'Triple              ', 30, N'Images/triple.jpg                                 ', 0)
INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (3, N'Twin                ', 30, N'Images/twin.jpg                                   ', 0)
INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (4, N'Single              ', 30, N'Images/single.jpg                                 ', 0)
INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (5, N'Deluxe              ', 20, N'Images/deluxe.jpg                                 ', 0)
INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (6, N'Cvadrupla           ', 30, N'Images/cvadrupla.jpg                              ', 0)
INSERT [dbo].[Room] ([idRoom], [type], [numberOfRooms], [image], [isDeleted]) VALUES (7, N'Queen               ', 10, N'Images/queen.jpg                                  ', 1)
SET IDENTITY_INSERT [dbo].[Room] OFF
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (3, 1, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (1, 1, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (1, 2, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (1, 3, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (2, 4, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (2, 5, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (2, 1, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (3, 2, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (3, 4, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (4, 1, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (4, 2, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (4, 3, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (4, 5, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (5, 2, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (5, 5, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (5, 4, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (5, 1, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (5, 3, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (6, 4, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (6, 3, 0)
INSERT [dbo].[RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) VALUES (2, 1, 0)
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([idSales], [name], [price], [dateStart], [dateEnd], [numberOfDays], [idRoom], [isDeleted]) VALUES (1, N'Litoralul Pentru Toti                             ', 500, CAST(N'2019-06-01T00:00:00.000' AS DateTime), CAST(N'2019-07-01T00:00:00.000' AS DateTime), 7, 1, 0)
INSERT [dbo].[Sales] ([idSales], [name], [price], [dateStart], [dateEnd], [numberOfDays], [idRoom], [isDeleted]) VALUES (3, N'Timp in Familie                                   ', 500, CAST(N'2019-06-06T00:00:00.000' AS DateTime), CAST(N'2019-06-20T00:00:00.000' AS DateTime), 10, 5, 0)
SET IDENTITY_INSERT [dbo].[Sales] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (3, N'Diana                                             ', N'Diana                                             ', 1, 0)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (4, N'Dana                                              ', N'Dana                                              ', 3, 0)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (5, N'Lucian                                            ', N'Lucian                                            ', 2, 0)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (6, N'Ana                                               ', N'Ana                                               ', 1, 1)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (7, N'kali                                              ', N'kali                                              ', 2, 0)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (8, N'Tina                                              ', N'Tina                                              ', 2, 0)
INSERT [dbo].[User] ([IdUser], [Username], [Password], [IdRole], [IsDeleted]) VALUES (9, N'Andreea                                           ', N'Andreea                                           ', 2, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_AdditionalServices] FOREIGN KEY([idServices])
REFERENCES [dbo].[AdditionalServices] ([idServices])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_AdditionalServices]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_Room] FOREIGN KEY([idRoom])
REFERENCES [dbo].[Room] ([idRoom])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_Room]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_User]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoom_Reservation] FOREIGN KEY([idReservation])
REFERENCES [dbo].[Reservation] ([idReservation])
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_ReservationRoom_Reservation]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoom_Room] FOREIGN KEY([idRoom])
REFERENCES [dbo].[Room] ([idRoom])
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_ReservationRoom_Room]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoom_Sales] FOREIGN KEY([idSales])
REFERENCES [dbo].[Sales] ([idSales])
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_ReservationRoom_Sales]
GO
ALTER TABLE [dbo].[ReservationServices]  WITH CHECK ADD  CONSTRAINT [FK_ReservationServices_AdditionalServices] FOREIGN KEY([idServices])
REFERENCES [dbo].[AdditionalServices] ([idServices])
GO
ALTER TABLE [dbo].[ReservationServices] CHECK CONSTRAINT [FK_ReservationServices_AdditionalServices]
GO
ALTER TABLE [dbo].[ReservationServices]  WITH CHECK ADD  CONSTRAINT [FK_ReservationServices_Reservation] FOREIGN KEY([idReservation])
REFERENCES [dbo].[Reservation] ([idReservation])
GO
ALTER TABLE [dbo].[ReservationServices] CHECK CONSTRAINT [FK_ReservationServices_Reservation]
GO
ALTER TABLE [dbo].[RoomFeatures]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeatures_Features] FOREIGN KEY([idFeatures])
REFERENCES [dbo].[Features] ([idFeatures])
GO
ALTER TABLE [dbo].[RoomFeatures] CHECK CONSTRAINT [FK_RoomFeatures_Features]
GO
ALTER TABLE [dbo].[RoomFeatures]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeatures_Room] FOREIGN KEY([idRoom])
REFERENCES [dbo].[Room] ([idRoom])
GO
ALTER TABLE [dbo].[RoomFeatures] CHECK CONSTRAINT [FK_RoomFeatures_Room]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Roles] ([id_role])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Roles]
GO
/****** Object:  StoredProcedure [dbo].[ChangeReservationState]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ChangeReservationState]
@IdReservation int,
@State varchar(10)
as
update [Reservation]
set state = @State
where idReservation = @IdReservation

GO
/****** Object:  StoredProcedure [dbo].[DeleteFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteFeatures]
@Name varchar(50)
As
UPDATE [Features] 
SET isDeleted = 1
WHERE name = @Name
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoom]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteRoom]
@IdRoom int
As
UPDATE [Room]
SET Room.isDeleted = 1
WHERE Room.idRoom = @IdRoom

UPDATE [Prices]
SET Prices.isDeleted = 1
WHERE Prices.idRoom = @IdRoom

UPDATE [RoomFeatures]
SET RoomFeatures.isDeleted = 1
WHERE RoomFeatures.idRoom = @IdRoom
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoomFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[DeleteRoomFeatures]
@IdRoom int,
@IdFeature int
As
UPDATE [RoomFeatures] 
SET isDeleted = 1
WHERE idRoom = @IdRoom
AND idFeatures = @IdFeature
GO
/****** Object:  StoredProcedure [dbo].[DeleteSales]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteSales]
@Name varchar(50)
AS
UPDATE [Sales] 
SET isDeleted = 1
WHERE name = @Name
GO
/****** Object:  StoredProcedure [dbo].[DeleteServices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteServices]
@Name varchar(50)
As
UPDATE [AdditionalServices] 
SET isDeleted = 1
WHERE name = @Name
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteUser]
@UsernameToSearch varchar(50)
as
Update [User]
Set IsDeleted = 1
Where Username = @UsernameToSearch
GO
/****** Object:  StoredProcedure [dbo].[GetAllAdditionalServices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllAdditionalServices]
as
Select AdditionalServices.idServices,
AdditionalServices.name +' ('+ CAST(Prices.value AS VARCHAR(7)) + ' lei)', 
Prices.value, AdditionalServices.isDeleted
from [AdditionalServices]
inner join Prices on Prices.idServices = AdditionalServices.idServices
where
AdditionalServices.isDeleted = 0
AND 
Prices.isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllAvailableRooms]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllAvailableRooms]
@Checkin datetime,
@Checkout datetime
AS
SELECT  Room.idRoom, type, numberOfRooms, image, Room.isDeleted, Prices.value
FROM    [Room]
inner join Prices on Prices.idRoom = Room.idRoom
WHERE   Room.idRoom NOT IN (SELECT idRoom FROM ReservationRoom)
and Room.isDeleted = 0
and Prices.isDeleted = 0
UNION all
SELECT Room.idRoom, type, numberOfRooms, image, Room.isDeleted, Prices.value FROM [Room]
inner join Prices on Prices.idRoom = Room.idRoom
INNER JOIN ReservationRoom ON ReservationRoom.idRoom = Room.idRoom
INNER JOIN Reservation ON Reservation.idReservation=ReservationRoom.idReservation
WHERE Reservation.checkOut < @Checkin OR Reservation.checkIn > @Checkout
AND Reservation.isDeleted = 0 
AND Room.isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllAvailableSales]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllAvailableSales]
@Checkin datetime,
@Checkout datetime
as
Select * from [Sales]
where dateEnd >= @CheckIn and dateStart <= @Checkout
and 
isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllFeatures]
as
Select * from [Features]
where isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllReservationForClient]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllReservationForClient]
@Iduser int
as
select * from [Reservation]
where Reservation.idUser = @Iduser
and Reservation.isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllReservations]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllReservations]
as
select * from [Reservation]
where
isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllRooms]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllRooms]
As
Select Room.idRoom, Room.type, Room.numberOfRooms, Room.image, Room.isDeleted, Prices.value from [Room]
inner join Prices ON Prices.idRoom = Room.idRoom
Where 
Room.isDeleted = 0
and
Prices.isDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllSales]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllSales]
as
select * from [Sales]
where
sales.isDeleted  = 0
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllUsers]
AS
SELECT * FROM [User]
Where IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[GetFeaturesForRoom]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetFeaturesForRoom]
@IdRoom int
AS
SELECT Features.name FROM Features
INNER JOIN RoomFeatures ON RoomFeatures.idFeatures = Features.idFeatures
INNER JOIN Room ON Room.idRoom = RoomFeatures.idRoom
WHERE Room.idRoom = @IdRoom
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetUser]
@Username varchar(50),
@Password varchar(50)
As
SELECT IdUser, Username, Password, IdRole FROM [User] 
WHERE Username = @Username 
AND 
Password = @Password
AND 
IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[InsertFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertFeatures]
@Name varchar(50)
As
Insert Into [Features] ([name], [isDeleted]) 
values(@Name, 0)
GO
/****** Object:  StoredProcedure [dbo].[InsertReservation]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertReservation]
@DateStart datetime,
@DateEnd datetime,
@State varchar(10),
@TotalPrice float,
@IdUser int
as
Insert Into [Reservation] ([checkIn],[checkOut],[state],[totalPrice],[idUser],[isDeleted]) 
values(@DateStart, @DateEnd,@State, @TotalPrice, @IdUser, 0)
GO
/****** Object:  StoredProcedure [dbo].[InsertReservationRoom]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertReservationRoom]
@IdReservation int,
@IdRoom int,
@Number int,
@IdSales int
as
Insert into [ReservationRoom] ([idReservation],[idRoom],[number],[idSales])
values(@IdReservation,@IdRoom,@Number,@IdSales)
GO
/****** Object:  StoredProcedure [dbo].[InsertReservationServices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertReservationServices]
@IdReservation int,
@IdServices int
as
Insert into [ReservationServices] ([idReservation],[idServices])
values(@IdReservation,@IdServices)
GO
/****** Object:  StoredProcedure [dbo].[InsertRoom]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRoom]
@Type varchar(20),
@Image varchar(20),
@NumberOfRooms int
As
Insert Into [Room] ([type],[image],[numberOfRooms], [isDeleted]) 
values(@Type,@Image,@NumberOfRooms, 0)
GO
/****** Object:  StoredProcedure [dbo].[InsertRoomFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[InsertRoomFeatures]
@IdRoom int,
@IdFeature int
As
Insert Into [RoomFeatures] ([idRoom], [idFeatures], [isDeleted]) 
values (@IdRoom, @IdFeature, 0)
GO
/****** Object:  StoredProcedure [dbo].[InsertRoomPrice]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertRoomPrice]
@Price float,
@DataStart datetime,
@DataEnd datetime,
@Item varchar(50)
As
Insert Into [Prices] ([value],[dataStart],[dataEnd],[idRoom],[idServices], [isDeleted]) 
select @Price, @DataStart, @DataEnd, Room.idRoom, NULL, 0
from Room
where Room.type = @Item
GO
/****** Object:  StoredProcedure [dbo].[InsertSales]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertSales]
@Name varchar(20),
@DataStart datetime,
@DataEnd datetime,
@Price float,
@NumberOfDays int,
@Type varchar(20)
As
Insert Into [Sales] ([name],[dateStart],[dateEnd],[price],[numberOfDays],[idRoom], [isDeleted]) 
select @Name, @DataStart, @DataEnd, @Price, @NumberOfDays, Room.idRoom, 0
from Room
where Room.type = @Type
GO
/****** Object:  StoredProcedure [dbo].[InsertServicePrice]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertServicePrice]
@Price float,
@DataStart datetime,
@DataEnd datetime,
@Item varchar(50)
As
Insert Into [Prices] ([value],[dataStart],[dataEnd],[idRoom],[idServices], [isDeleted]) 
select @Price, @DataStart, @DataEnd, NULL, AdditionalServices.idServices, 0
from AdditionalServices
where AdditionalServices.name = @Item
GO
/****** Object:  StoredProcedure [dbo].[InsertServices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertServices]
@Name varchar(50)
As
Insert Into [AdditionalServices] ([name], [isDeleted]) 
values(@Name, 0)
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertUser]
@Username varchar(50),
@Password varchar(50),
@idRole int
As
Insert Into [User] ([username], [password], [idRole], [isDeleted]) 
values(@Username, @Password, @idRole, 0)
GO
/****** Object:  StoredProcedure [dbo].[UpdateFeatures]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateFeatures]
@NameToSearch varchar(50),
@Name varchar(50)
As
UPDATE [Features]
SET name = @Name
WHERE name = @NameToSearch
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoom]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateRoom]
@type varchar(20),
@idRoom int,
@numberOfRooms int
As
UPDATE [Room] 
SET type = @Type, numberOfRooms = @numberOfRooms
WHERE idRoom = @IdRoom
GO
/****** Object:  StoredProcedure [dbo].[UpdateSales]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateSales]
@Name varchar(50),
@NewName varchar(50),
@DataStart datetime,
@DataEnd datetime,
@Price float,
@NumberOfDays int,
@Type varchar(20)
As
UPDATE [Sales] 
SET name = @NewName, dateStart = @DataStart, dateEnd = @DataEnd, price = @Price, numberOfDays = @NumberOfDays, idRoom = Room.idRoom
FROM Sales
INNER JOIN Room on Room.idRoom = Sales.idRoom
WHERE Room.type = @Type
GO
/****** Object:  StoredProcedure [dbo].[UpdateServices]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateServices]
@NameToSearch varchar(50),
@Name varchar(50)
As
UPDATE [AdditionalServices]
SET name = @Name
WHERE name = @NameToSearch
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 6/15/2019 7:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[UpdateUser]
@UsernameToSearch varchar(50),
@Username varchar(50),
@Password varchar(50)
as
UPDATE [User]
SET Username = @Username, Password = @Password
WHERE Username = @UsernameToSearch;
GO
USE [master]
GO
ALTER DATABASE [HotelDataBase] SET  READ_WRITE 
GO
