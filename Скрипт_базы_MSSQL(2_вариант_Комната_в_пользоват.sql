USE [ASUZ_Transport_DB]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Building] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CPC] [nvarchar](50) NULL,
	[IntercityСity] [bit] NULL,
	[PurposeUsingTransport] [varchar](500) NULL,
	[Days] [bit] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[DateCreation] [datetime] NOT NULL,
	[TypeCarID] [int] NOT NULL,
	[QuantityPassengers] [int] NULL,
	[CargoWeight] [float] NULL,
	[CarID] [int] NULL,
	[PlaceSubmission] [varchar](300) NOT NULL,
	[Route] [varchar](300) NOT NULL,
	[CommentClient] [varchar](500) NULL,
	[СommentDirector] [varchar](500) NULL,
	[СommentEconomist] [varchar](500) NULL,
	[СommentDepartment] [varchar](500) NULL,
	[СommentDispatcherNIIAR] [varchar](500) NULL,
	[СommentDispatcherATA] [varchar](500) NULL,
	[DirectorStatusDoneID] [int] NOT NULL,
	[EconomistStatusDoneID] [int] NOT NULL,
	[DepartmentStatusDoneID] [int] NOT NULL,
	[DispatcherNIIAR_StatusDoneID] [int] NOT NULL,
	[DispatcherATA_StatusDoneID] [int] NOT NULL,
	[SelectionApplicationJoin] [bit] NULL,
	[ApplicationJoin] [varchar](100) NULL,
 CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[SurName] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Partonymic] [varchar](50) NOT NULL,
	[Post] [varchar](200) NOT NULL,
	[DivisionID] [int] NOT NULL,
	[Room] [int] NOT NULL,
	[WorkPhone] [varchar](50) NULL,
	[MobilePhone] [varchar](50) NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeCars]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeCars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ModelCars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusesDone]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusesDone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StatusesDone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ApplicationView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE view [dbo].[ApplicationView]  
as   
SELECT App.Id  
   ,Us.SurName + ' ' + Us.Name +' '+ Us.Partonymic as Client
   ,Us.Email
   ,Us.Post
   --,Us.Division
   --,Us.Department
,Dvs.Name as Division
,Dvs.Building
,Us.Room
,UsrDrc.SurName + ' ' + UsrDrc.Name +' '+ UsrDrc.Partonymic as Director

   ,UsrEcn.SurName + ' ' + UsrEcn.Name +' '+ UsrEcn.Partonymic as Economist
   ,App.CPC
   ,App.IntercityСity
   ,App.PurposeUsingTransport
   ,App.Days as DaysWorkerOrWeekend
   --,Us.Location
   ,Us.WorkPhone
   ,Us.MobilePhone
   ,App.DateCreation
   ,App.StartDate
   ,App.EndDate
   ,TC.Name as TypeCar
   --,Crs.RegisterSign as RegisterSign
   --,Crs.Model as Model
   ,App.QuantityPassengers
   ,App.CargoWeight
   ,App.PlaceSubmission
   ,App.Route
   ,App.CommentClient
    ,App.СommentDirector
   ,App.СommentEconomist
    ,App.СommentDepartment
   ,App.СommentDispatcherNIIAR
   ,App.СommentDispatcherATA
   ,SDD.Name as DirectorStatusDone
   ,SDE.Name as EconomistStatusDone
    ,SDDDD.Name as DepartmentStatusDone
   ,SDDD.Name as DispatcherNIIAR_StatusDone
   ,SDDDDD.Name as DispatcherATA_StatusDone
   ,App.SelectionApplicationJoin
   ,App.ApplicationJoin
  

     
    
   
  FROM dbo.Applications as App  
  

   inner join dbo.TypeCars as TC on App.TypeCarID=TC.Id  

   --inner join dbo.Cars as Crs on App.CarID = Crs.Id
  
   inner join dbo.StatusesDone as SDD on App.DirectorStatusDoneID=SDD.Id

    inner join dbo.StatusesDone as SDDD on App.DispatcherNIIAR_StatusDoneID=SDDD.Id 
	 
   inner  join dbo.StatusesDone as SDE on App.EconomistStatusDoneID = SDE.Id

    inner  join dbo.StatusesDone as SDDDD on App.DepartmentStatusDoneID = SDDDD.Id
	inner  join dbo.StatusesDone as SDDDDD on App.DispatcherATA_StatusDoneID = SDDDDD.Id


    inner  join dbo.Users as Us on App.UserID = Us.Id

--	inner  join dbo.Users as Usr on Us.DirectorID = Usr.Id

--	inner  join dbo.Users as Ecn on Us.EconomistID = Ecn.Id
	
--inner join  dbo.Organizations as Org on Us.OrganizationID = Org.Id
--	inner join dbo.Divisions as Dvs on Org.DivisionID = Dvs.Id
	inner  join dbo.Users as UsrDrc on UsrDrc.StatusID = 3 and UsrDrc.DivisionID = Us.DivisionID

	inner  join dbo.Users as UsrEcn on UsrEcn.StatusID = 4 and UsrEcn.DivisionID = Us.DivisionID

	inner join dbo.Divisions as Dvs on Us.DivisionID = Dvs.Id

GO
/****** Object:  View [dbo].[TypeCarView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[TypeCarView]  
as   
SELECT TC.Id 
,TC.Name TypeCar
 

     
    
   
  FROM dbo.TypeCars as TC  
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE view [dbo].[UserView]  
as   
SELECT Usr.Id 
,Usr.Email
,Usr.SurName + ' ' +Usr.Name+' '+Usr.Partonymic as Customer
,Usr.Post
,Dvs.Name as Division
,Dvs.Building
,Usr.Room
,Usr.WorkPhone
,Usr.MobilePhone
,Sts.Name as Status

--,UsrDrc.SurName + ' ' + UsrDrc.Name +' '+ UsrDrc.Partonymic as Director

--   ,UsrEcn.SurName + ' ' + UsrEcn.Name +' '+ UsrEcn.Partonymic as Economist

  FROM dbo.Users as Usr 


  inner join dbo.Divisions as Dvs on Usr.DivisionID = Dvs.Id

  inner join dbo.Statuses as Sts on Usr.StatusID = Sts.Id

 -- inner  join dbo.Users as UsrDrc on UsrDrc.StatusID = 3 and UsrDrc.DivisionID = Usr.DivisionID


	--inner  join dbo.Users as UsrEcn on UsrEcn.StatusID = 4 and UsrEcn.DivisionID = Usr.DivisionID

GO
/****** Object:  Table [dbo].[ModelCars]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelCars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ModelCars_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[TypeCarID] [int] NOT NULL,
	[ModelCarID] [int] NOT NULL,
	[RegisterSign] [nvarchar](30) NOT NULL,
	[StatusCarID] [int] NOT NULL,
	[ImageMimeType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ApplicationAgreedView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE view [dbo].[ApplicationAgreedView]  
as   
SELECT App.Id  
   ,Us.SurName + ' ' + Us.Name +' '+ Us.Partonymic as Client
   ,Us.Email
   ,Us.Post
   --,Us.Division
   --,Us.Department
,Dvs.Name as Division
,Dvs.Building
,Us.Room
,UsrDrc.SurName + ' ' + UsrDrc.Name +' '+ UsrDrc.Partonymic as Director

   ,UsrEcn.SurName + ' ' + UsrEcn.Name +' '+ UsrEcn.Partonymic as Economist
   ,App.CPC
   ,App.IntercityСity
   ,App.PurposeUsingTransport
   ,App.Days as DaysWorkerOrWeekend
   --,Us.Location
   ,Us.WorkPhone
   ,Us.MobilePhone
   ,App.DateCreation
   ,App.StartDate
   ,App.EndDate
   ,TC.Name as TypeCar
    ,MC.Name as Model
   ,Crs.RegisterSign as RegisterSign
   ,App.QuantityPassengers
   ,App.CargoWeight
   ,App.PlaceSubmission
   ,App.Route
   ,App.CommentClient
    ,App.СommentDirector
   ,App.СommentEconomist
    ,App.СommentDepartment
   ,App.СommentDispatcherNIIAR
   ,App.СommentDispatcherATA
   ,SDD.Name as DirectorStatusDone
   ,SDE.Name as EconomistStatusDone
    ,SDDDD.Name as DepartmentStatusDone
   ,SDDD.Name as DispatcherNIIAR_StatusDone
   ,SDDDDD.Name as DispatcherATA_StatusDone
   ,App.SelectionApplicationJoin
   ,App.ApplicationJoin
  

  FROM dbo.Applications as App  
  

   inner join dbo.TypeCars as TC on App.TypeCarID=TC.Id  
    inner join dbo.Cars as Crs on App.CarID = Crs.Id

    inner join dbo.ModelCars as MC on Crs.ModelCarID = MC.Id
  
   inner join dbo.StatusesDone as SDD on App.DirectorStatusDoneID=SDD.Id
   
   inner join dbo.StatusesDone as SDDD on App.DispatcherNIIAR_StatusDoneID=SDDD.Id 
	 
   inner  join dbo.StatusesDone as SDE on App.EconomistStatusDoneID = SDE.Id

    inner  join dbo.StatusesDone as SDDDD on App.DepartmentStatusDoneID = SDDDD.Id

	inner  join dbo.StatusesDone as SDDDDD on App.DispatcherATA_StatusDoneID = SDDDDD.Id



    inner  join dbo.Users as Us on App.UserID = Us.Id
	
	--inner  join dbo.Users as Usr on Us.DirectorID = Usr.Id

	--inner  join dbo.Users as Ecn on Us.EconomistID = Ecn.Id
	inner  join dbo.Users as UsrDrc on UsrDrc.StatusID = 3 and UsrDrc.DivisionID = Us.DivisionID

	inner  join dbo.Users as UsrEcn on UsrEcn.StatusID = 4 and UsrEcn.DivisionID = Us.DivisionID
	--inner  join dbo.Users as UsDv on Usr.DivisionID = Us.DivisionID
	--inner  join dbo.Users as Drc on UsDv.Id = Drc.Id


	inner join dbo.Divisions as Dvs on Us.DivisionID = Dvs.Id


GO
/****** Object:  Table [dbo].[StatusCars]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StatusCars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CarView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[CarView]  
as   
SELECT Crs.Id  
,TC.Name as TypeCar
,MC.Name as Model,
Crs.RegisterSign
,SC.Name as StatusCar

  FROM dbo.Cars as Crs  
  

   inner join dbo.TypeCars as TC on Crs.TypeCarID=TC.Id  


   inner join dbo.ModelCars as MC on Crs.ModelCarID=MC.Id  


   inner join dbo.StatusCars as SC on Crs.StatusCarID=SC.Id  
GO
/****** Object:  View [dbo].[ModelCarView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create view [dbo].[ModelCarView]  
as   
SELECT Ml.Id,
Ml.Name as Model

  FROM dbo.ModelCars as Ml 
  
GO
/****** Object:  View [dbo].[CarModelView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[CarModelView]  
as   
SELECT Crs.Id  
,TC.Name as TypeCar
,MC.Name as Model,
Crs.RegisterSign
,SC.Name as StatusCar
,Crs.ImageMimeType ImageData

  FROM dbo.Cars as Crs  
  

   inner join dbo.TypeCars as TC on Crs.TypeCarID=TC.Id  


   inner join dbo.ModelCars as MC on Crs.ModelCarID=MC.Id  


   inner join dbo.StatusCars as SC on Crs.StatusCarID=SC.Id  
GO
/****** Object:  View [dbo].[DivisionView]    Script Date: 26.05.2022 2:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[DivisionView]  
as   
SELECT Dvs.Id  
,Dvs.Name as Division
,Dvs.Building 



  FROM dbo.Divisions as Dvs  
GO
SET IDENTITY_INSERT [dbo].[Applications] ON 

INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (91, 44, NULL, 1, N'Перевозка пассажиров', 1, CAST(N'2022-05-26T09:01:46.000' AS DateTime), CAST(N'2022-05-26T12:01:46.000' AS DateTime), CAST(N'2022-05-26T00:02:52.500' AS DateTime), 1, 1, NULL, 14, N'Здание 102, НИИАР', N'Соцгород —> Химммаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (92, 47, NULL, 1, N'Перевозка груза', 1, CAST(N'2022-05-26T03:04:46.000' AS DateTime), CAST(N'2022-05-27T04:04:46.000' AS DateTime), CAST(N'2022-05-26T00:06:44.903' AS DateTime), 2, NULL, 200, 28, N'Здание 103, НИИАР', N'ДААЗ —> Олимп', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (93, 50, NULL, 1, N'перевозка участников форума', 1, CAST(N'2022-05-26T04:07:57.000' AS DateTime), CAST(N'2022-05-27T05:07:57.000' AS DateTime), CAST(N'2022-05-26T00:10:36.867' AS DateTime), 1, 25, NULL, 11, N'Здание 105, НИИАР', N'пр. Ленина —> 11 мкр.', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (94, 53, NULL, 1, N'перевозка груза', 1, CAST(N'2022-05-26T03:13:35.000' AS DateTime), CAST(N'2022-05-26T04:13:35.000' AS DateTime), CAST(N'2022-05-26T00:17:34.733' AS DateTime), 2, NULL, 3000, 27, N'Здание 106, НИИАР', N'ул. Ленина —> Химмаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (95, 53, NULL, 1, N'Перевозка пассажиров', 1, CAST(N'2022-05-26T09:01:46.000' AS DateTime), CAST(N'2022-05-26T12:01:46.000' AS DateTime), CAST(N'2022-05-26T00:02:52.500' AS DateTime), 1, 1, NULL, 7, N'Здание 102, НИИАР', N'Соцгород —> Химммаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (96, 50, NULL, 1, N'Перевозка груза', 1, CAST(N'2022-05-26T03:04:46.000' AS DateTime), CAST(N'2022-05-27T04:04:46.000' AS DateTime), CAST(N'2022-05-26T00:06:44.903' AS DateTime), 2, NULL, 200, 29, N'Здание 103, НИИАР', N'ДААЗ —> Олимп', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (97, 47, NULL, 1, N'перевозка участников форума', 1, CAST(N'2022-05-26T04:07:57.000' AS DateTime), CAST(N'2022-05-27T05:07:57.000' AS DateTime), CAST(N'2022-05-26T00:10:36.867' AS DateTime), 1, 25, NULL, 30, N'Здание 105, НИИАР', N'пр. Ленина —> 11 мкр.', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (98, 44, NULL, 1, N'перевозка груза', 1, CAST(N'2022-05-26T03:13:35.000' AS DateTime), CAST(N'2022-05-26T04:13:35.000' AS DateTime), CAST(N'2022-05-26T00:17:34.733' AS DateTime), 2, NULL, 3000, 27, N'Здание 106, НИИАР', N'ул. Ленина —> Химмаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (99, 50, NULL, 1, N'Перевозка пассажиров', 1, CAST(N'2022-05-26T09:01:46.000' AS DateTime), CAST(N'2022-05-26T12:01:46.000' AS DateTime), CAST(N'2022-05-26T00:02:52.500' AS DateTime), 1, 1, NULL, 11, N'Здание 102, НИИАР', N'Соцгород —> Химммаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (100, 53, NULL, 1, N'Перевозка груза', 1, CAST(N'2022-05-26T03:04:46.000' AS DateTime), CAST(N'2022-05-27T04:04:46.000' AS DateTime), CAST(N'2022-05-26T00:06:44.903' AS DateTime), 2, NULL, 200, 28, N'Здание 103, НИИАР', N'ДААЗ —> Олимп', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (101, 44, NULL, 1, N'перевозка участников форума', 1, CAST(N'2022-05-26T04:07:57.000' AS DateTime), CAST(N'2022-05-27T05:07:57.000' AS DateTime), CAST(N'2022-05-26T00:10:36.867' AS DateTime), 1, 25, NULL, 31, N'Здание 105, НИИАР', N'пр. Ленина —> 11 мкр.', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 5, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (102, 47, NULL, 1, N'перевозка груза', 1, CAST(N'2022-05-26T03:13:35.000' AS DateTime), CAST(N'2022-05-26T04:13:35.000' AS DateTime), CAST(N'2022-05-26T00:17:34.733' AS DateTime), 2, NULL, 3000, 27, N'Здание 106, НИИАР', N'ул. Ленина —> Химмаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (103, 50, NULL, 1, N'Перевозка пассажиров', 0, CAST(N'2022-05-26T09:01:46.000' AS DateTime), CAST(N'2022-05-26T12:01:46.000' AS DateTime), CAST(N'2022-05-26T00:02:52.500' AS DateTime), 1, 1, NULL, 32, N'Здание 102, НИИАР', N'Соцгород —> Химммаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (104, 53, NULL, 1, N'Перевозка груза', 0, CAST(N'2022-05-26T03:04:46.000' AS DateTime), CAST(N'2022-05-27T04:04:46.000' AS DateTime), CAST(N'2022-05-26T00:06:44.903' AS DateTime), 2, NULL, 200, 29, N'Здание 103, НИИАР', N'ДААЗ —> Олимп', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 5, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (105, 44, NULL, 1, N'перевозка участников форума', 0, CAST(N'2022-05-26T04:07:57.000' AS DateTime), CAST(N'2022-05-27T05:07:57.000' AS DateTime), CAST(N'2022-05-26T00:10:36.867' AS DateTime), 1, 25, NULL, 30, N'Здание 105, НИИАР', N'пр. Ленина —> 11 мкр.', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 4, NULL, NULL)
INSERT [dbo].[Applications] ([Id], [UserID], [CPC], [IntercityСity], [PurposeUsingTransport], [Days], [StartDate], [EndDate], [DateCreation], [TypeCarID], [QuantityPassengers], [CargoWeight], [CarID], [PlaceSubmission], [Route], [CommentClient], [СommentDirector], [СommentEconomist], [СommentDepartment], [СommentDispatcherNIIAR], [СommentDispatcherATA], [DirectorStatusDoneID], [EconomistStatusDoneID], [DepartmentStatusDoneID], [DispatcherNIIAR_StatusDoneID], [DispatcherATA_StatusDoneID], [SelectionApplicationJoin], [ApplicationJoin]) VALUES (106, 47, NULL, 1, N'перевозка груза', 0, CAST(N'2022-05-26T03:13:35.000' AS DateTime), CAST(N'2022-05-26T04:13:35.000' AS DateTime), CAST(N'2022-05-26T00:17:34.733' AS DateTime), 2, NULL, 3000, 28, N'Здание 106, НИИАР', N'ул. Ленина —> Химмаш', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 5, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Applications] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (1, 1, 1, N'—', 1, NULL)
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (7, 1, 2, N'C456МC 78 RUS', 1, N'Audi_Q8.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (9, 2, 3, N'C456AC 78 RUS', 1, N'Audi_TT.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (11, 1, 33, N'X865OP 78 RUS', 1, N'Audi_A5.png')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (14, 1, 33, N'A482AC 77 RUS', 1, N'Audi_A5_.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (26, 2, 43, N'А678ЕН 73 RUS', 1, N'Volvo_FH16.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (27, 2, 44, N'B786CM 73 RUS', 1, N'Тонар-7502.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (28, 2, 45, N'Х564ТТ 73 RUS', 1, N'ЗИЛ-130.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (29, 1, 46, N'Н784ТА 73 RUS', 1, N'Opel_Grandland_X.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (30, 1, 47, N'H904ТА 73 RUS', 1, N'ЛиАЗ-4292.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (31, 1, 48, N'М783ЕА 73 RUS', 1, N'МАЗ-232.jpg')
INSERT [dbo].[Cars] ([Id], [TypeCarID], [ModelCarID], [RegisterSign], [StatusCarID], [ImageMimeType]) VALUES (32, 1, 49, N'P240ТО 73 RUS', 1, N'Hyundai-H350.jpg')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisions] ON 

INSERT [dbo].[Divisions] ([Id], [Name], [Building]) VALUES (1, N'Департамент бюджетного управления', N'102')
INSERT [dbo].[Divisions] ([Id], [Name], [Building]) VALUES (2, N'Группа специальной информации', N'103')
INSERT [dbo].[Divisions] ([Id], [Name], [Building]) VALUES (5, N'Служба безопасности', N'102')
INSERT [dbo].[Divisions] ([Id], [Name], [Building]) VALUES (6, N'Производственно-технический отдел', N'103')
INSERT [dbo].[Divisions] ([Id], [Name], [Building]) VALUES (10, N'Управление кадров', N'102')
SET IDENTITY_INSERT [dbo].[Divisions] OFF
GO
SET IDENTITY_INSERT [dbo].[ModelCars] ON 

INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (1, N'—')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (2, N'Audi Q8')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (3, N'Audi TT')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (4, N'BMW E46')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (5, N'BMW E90')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (6, N'Chery')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (7, N'Chevrolet')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (8, N'Citroent')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (9, N'Daewoo')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (10, N'Ford')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (11, N'Ford Focus')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (12, N'Honda')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (13, N'Honda Civic')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (14, N'Kia')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (15, N'Land Rover')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (16, N'Lexus')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (17, N'Mazda')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (18, N'Mercedes-Benz')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (19, N'Misubishi')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (20, N'Nissan')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (21, N'Opel')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (22, N'Opel Astra')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (23, N'Peugeot')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (24, N'Renault')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (25, N'Skoda')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (26, N'Skoda Octavia')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (27, N'Ssang Yong')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (28, N'Subaru')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (29, N'Toyota')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (30, N'Volkswagen')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (31, N'Volvo')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (32, N'УАЗ Патриот')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (33, N'Audi')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (43, N'Volvo FH16')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (44, N'Тонар-7502')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (45, N'ЗИЛ-130')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (46, N'Opel Grandland X')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (47, N'ЛиАЗ-4292')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (48, N'МАЗ-232')
INSERT [dbo].[ModelCars] ([Id], [Name]) VALUES (49, N'Hyundai H350')
SET IDENTITY_INSERT [dbo].[ModelCars] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusCars] ON 

INSERT [dbo].[StatusCars] ([Id], [Name]) VALUES (1, N'Доступна')
INSERT [dbo].[StatusCars] ([Id], [Name]) VALUES (2, N'Нет на месте')
SET IDENTITY_INSERT [dbo].[StatusCars] OFF
GO
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (2, N'Клиент')
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (3, N'Руководитель')
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (4, N'Экономист')
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (5, N'Диспетчер НИИАР')
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (6, N'ДИД')
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (7, N'Диспетчер АТА')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusesDone] ON 

INSERT [dbo].[StatusesDone] ([Id], [Name]) VALUES (1, N'Согласовано')
INSERT [dbo].[StatusesDone] ([Id], [Name]) VALUES (2, N'Отклонена')
INSERT [dbo].[StatusesDone] ([Id], [Name]) VALUES (3, N'На рассмотрении')
INSERT [dbo].[StatusesDone] ([Id], [Name]) VALUES (4, N'Исполнено')
INSERT [dbo].[StatusesDone] ([Id], [Name]) VALUES (5, N'Не исполнено')
SET IDENTITY_INSERT [dbo].[StatusesDone] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeCars] ON 

INSERT [dbo].[TypeCars] ([Id], [Name]) VALUES (1, N'Легковые автомобили и автобусы')
INSERT [dbo].[TypeCars] ([Id], [Name]) VALUES (2, N'Грузовые автомобили')
SET IDENTITY_INSERT [dbo].[TypeCars] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (13, N'sergey', N'sergey', N'a.pvrpva@mail.ru', N'Литвинцев', N'Виктор', N'Степанович', N'Главный специалист по технологическому оборудованию', 1, 130, N'+7(309-45)3-52-44', N'+7(309)345-52-44', 2)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (14, N'admin', N'admin', N'admin@yandex.ru', N'Кандаков', N'Сергей', N'Николаевич', N'Администратор', 2, 140, N'+7(309-45)3-12-44', N'+7(309)453-12-44', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (18, N'director', N'director', N'a.pvrpva@mail.ru', N'Астафьев', N'Иван', N'Иванович', N'Начальник ДПУ', 1, 131, N'+7(309-45)3-36-44', N'+7(909)465-48-45', 3)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (22, N'economist', N'economist', N'a.pvrpva@mail.ru', N'Васюткин', N'Пётр', N'Петрович', N'Экономист ДПУ', 1, 132, N'+7(309-45)3-30-44', N'+7(908)654-94-56', 4)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (25, N'dispatcherNIIAR', N'dispatcherNIIAR', N'a.pvrpva@mail.ru', N'Сидоров', N'Семён', N' Петрович', N'Диспетчер НИИАР', 1, 143, N'+7(309-32)3-52-44', N'+7(908)621-91-56', 5)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (32, N'department', N'department', N'a.pvrpva@mail.ru', N'Казанцев', N'Игорь', N'Петрович', N'Главный департамента', 1, 155, N'+7(312-32)3-52-44', N'+7(908)721-93-52', 6)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (34, N'dispatcherATA', N'dispatcherATA', N'a.pvrpva@mail.ru', N'Истомин', N'Василий', N'Григорьевич', N'Диспетчер АТА', 1, 135, N'+7(312-37)3-52-48', N'+7(908)451-12-74', 7)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (42, N'petro-fedorov', N'tyrui7858', N'petro-fedorov@niir.ru', N'Фёдоров ', N'Пётр', N'Николаевич', N'Начальник СБ', 5, 201, N'+7(309-56)5-66-54', N'+7(909)564-66-56', 3)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (43, N'sorokin-evgeniy', N'jnuhn784fd', N'sorokin-evgeniy@niiar.ru', N'Сорокин', N'Евгений', N'Сергеевич', N'Экономист СБ', 5, 205, N'+7(309-85)2-68-98', N'+7(908)454-56-64', 4)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (44, N'ivanov-kirill', N'juodgk785gd', N'ivanov-kirill@niiar.ru', N'Иванов', N'Кирилл', N'Севастьянович', N'Специалист по безопасности', 5, 204, N'+7(309-45)1-56-46', N'+7(908)518-46-51', 2)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (45, N'rogov-david', N'ghjdf67382', N'rogov-david@niiar.ru', N'Рогов', N'Давид', N'Леонтьевич', N'Начальник ПТО', 6, 105, N'+7(312-48)9-49-84', N'+7(902)448-56-58', 3)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (46, N'ovoshnikov-aleksandr', N'hufg4guy', N'ovoshnikov-aleksandr@niiar.ru', N'Овощников', N'Александр', N'Макарович', N'Экономист ПТО', 6, 106, N'+7(312-05)6-46-46', N'+7(904)575-76-78', 4)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (47, N'lubimov-taras', N'guyhr73jhwr', N'lubimov-taras@niiar.ru', N'Любимов', N'Тарас', N'Акимович', N'Инженер', 6, 110, N'+7(312-48)9-46-54', N'+7(908)445-46-45', 2)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (48, N'dudkin-efim', N'nnvndfj4hgf12', N'dudkin-efim@niiar.ru', N'Дудкин', N'Ефим', N'Васильевич', N'Начальник УП', 10, 215, N'+7(312-58)5-98-69', N'+7(908)465-46-46', 3)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (49, N'lunkov-trofim', N'iuiet45eg', N'lunkov-trofim@niiar.ru', N'Луньков', N'Трофим', N'Васильевич', N'Экономист УП', 10, 213, N'+7(312-86)5-86-88', N'+7(909)465-45-35', 4)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (50, N'celobanov-evgeniy', N'ghhgf5rdyfh8', N'celobanov-evgeniy@niiar.ru', N'Целобанов', N'Евгений', N'Прохорович', N'Ведущий специалист УП', 10, 214, N'+7(312-96)5-86-86', N'+7(905)268-99-69', 2)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (51, N'kalugin-gavril', N'gfhg565yt', N'kalugin-gavril@niiar.ru', N'Калугин', N'Гавриил', N'Валерьевич', N'Начальник ГСИ', 2, 301, N'+7(312-58)5-59-69', N'+7(902)568-96-96', 3)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (52, N'krainev-efrem', N'gh5hklgh', N'krainev-efrem@niiar.ru', N'Крайнев', N'Ефрем', N'Лаврентиич', N'Экономист ГСИ', 2, 305, N'+7(312-58)5-89-68', N'+7(902)865-86-98', 4)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [SurName], [Name], [Partonymic], [Post], [DivisionID], [Room], [WorkPhone], [MobilePhone], [StatusID]) VALUES (53, N'tkachev-valeriy', N'fhj54yhjShh', N'tkachev-valeriy@niiar.ru', N'Ткачёв', N'Валерий', N'Константинович', N'Главный редактор', 2, 306, N'+7(312-56)9-55-86', N'+7(905)655-69-85', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_Cars] FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_Cars]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_StatusesDone] FOREIGN KEY([DirectorStatusDoneID])
REFERENCES [dbo].[StatusesDone] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_StatusesDone]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_StatusesDone1] FOREIGN KEY([EconomistStatusDoneID])
REFERENCES [dbo].[StatusesDone] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_StatusesDone1]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_StatusesDone2] FOREIGN KEY([DispatcherNIIAR_StatusDoneID])
REFERENCES [dbo].[StatusesDone] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_StatusesDone2]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_StatusesDone3] FOREIGN KEY([DepartmentStatusDoneID])
REFERENCES [dbo].[StatusesDone] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_StatusesDone3]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_StatusesDone4] FOREIGN KEY([DispatcherATA_StatusDoneID])
REFERENCES [dbo].[StatusesDone] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_StatusesDone4]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_TypeCars] FOREIGN KEY([TypeCarID])
REFERENCES [dbo].[TypeCars] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_TypeCars]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_Users]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_ModelCars] FOREIGN KEY([ModelCarID])
REFERENCES [dbo].[ModelCars] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_ModelCars]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_StatusCars] FOREIGN KEY([StatusCarID])
REFERENCES [dbo].[StatusCars] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_StatusCars]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_TypeCars] FOREIGN KEY([TypeCarID])
REFERENCES [dbo].[TypeCars] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_TypeCars]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Divisions] FOREIGN KEY([DivisionID])
REFERENCES [dbo].[Divisions] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Divisions]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Statuses] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Statuses]
GO
