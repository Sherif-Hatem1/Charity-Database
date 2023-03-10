USE [CharityDB]
GO
/****** Object:  UserDefinedFunction [dbo].[CapitalAmount]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE FUNCTION [dbo].[CapitalAmount](@num INT)
RETURNS INT
AS
  BEGIN
      RETURN
        (SELECT SUM(Finance.Monetary_Amount)
         FROM   Finance,Project
        WHERE  Finance.Project_Code = Project.Project_Num AND Finance.Project_Code=@num)
  END

--ALTER TABLE dbo.Project
--ADD Project_Capital AS dbo.CapitalAmount(Project.Project_Num)
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Dep_Number] [int] IDENTITY(1,1) NOT NULL,
	[Dep_Name] [varchar](100) NULL,
	[Dep_Location] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Dep_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Employee_id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](100) NULL,
	[Last_Name] [varchar](100) NULL,
	[Phone_Number] [varchar](15) NULL,
	[Birth_Date] [date] NULL,
	[Gender] [varchar](6) NULL,
	[Employee_Address] [varchar](100) NULL,
	[Department_No] [int] NULL,
	[Emp_Password] [varchar](200) NULL,
	[Username] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Finance]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Finance](
	[Transaction_No] [int] IDENTITY(1,1) NOT NULL,
	[Issue_Date] [date] NULL,
	[Monetary_Amount] [int] NULL,
	[Transaction_Type] [varchar](50) NULL,
	[Project_Code] [int] NULL,
	[Volunteer_ID] [int] NULL,
 CONSTRAINT [PK__Finance__9A8CAEAABBF1F381] PRIMARY KEY CLUSTERED 
(
	[Transaction_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory_Site]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory_Site](
	[Site_No] [int] IDENTITY(1,1) NOT NULL,
	[No_Of_Items] [int] NULL,
	[Supply_Type] [varchar](100) NULL,
	[Site_Address] [varchar](100) NULL,
	[Employee_Num] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Site_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Project_Num] [int] IDENTITY(1,1) NOT NULL,
	[Project_Name] [varchar](100) NULL,
	[Project_City] [varchar](50) NULL,
	[Project_Start_Date] [date] NULL,
	[Project_End_Date] [date] NULL,
	[Project_Status] [varchar](20) NULL,
	[Points_If_joined] [int] NULL,
	[Employee_Id] [int] NULL,
	[Project_Capital]  AS ([dbo].[CapitalAmount]([Project].[Project_Num])),
	[supply_type] [varchar](50) NULL,
	[supply_quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Project_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipient]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipient](
	[Recipient_id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](100) NULL,
	[Last_Name] [varchar](100) NULL,
	[Gender] [varchar](6) NULL,
	[Birth_Date] [date] NULL,
	[Recipient_Address] [varchar](100) NULL,
	[Phone_Number] [varchar](15) NULL,
	[Feedback_Rating] [int] NULL,
	[Project_No] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Recipient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Request_No] [int] IDENTITY(1,1) NOT NULL,
	[Request_Type] [varchar](50) NULL,
	[Date_Issued] [date] NULL,
	[Request_Status] [varchar](50) NULL,
	[Project_key] [int] NULL,
	[Volunteer_Code] [int] NULL,
	[Department_No] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Request_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rewards]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewards](
	[Reward_No] [int] IDENTITY(1,1) NOT NULL,
	[Date_Taken] [date] NULL,
	[Reward_Type] [varchar](50) NULL,
	[Affiliate] [varchar](50) NULL,
	[Volunteer_No] [int] NULL,
	[Reward_Points] [int] NULL,
	[Phone_Number] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Reward_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Supplier_id] [int] IDENTITY(1,1) NOT NULL,
	[Phone_Number] [varchar](15) NULL,
	[Supplied_Product] [varchar](100) NULL,
	[Contract_Start_Date] [date] NULL,
	[Contract_End_Date] [date] NULL,
	[Quantity_Availble] [int] NULL,
	[Supplier_Name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplies_Project]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplies_Project](
	[Number_Of_Items] [int] NULL,
	[Site_No] [int] NOT NULL,
	[Project_Num] [int] NOT NULL,
	[Transfer_Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Supplies_Project] PRIMARY KEY CLUSTERED 
(
	[Transfer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplies_Site]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplies_Site](
	[Number_Of_Items] [int] NOT NULL,
	[Site_No] [int] NOT NULL,
	[Supplier_Num] [int] NOT NULL,
	[Transfer_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Supplies_Site] PRIMARY KEY CLUSTERED 
(
	[Transfer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteer]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer](
	[Volunteer_id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](100) NULL,
	[Last_Name] [varchar](100) NULL,
	[Birth_Date] [date] NULL,
	[Gender] [varchar](6) NULL,
	[Volunteer_Address] [varchar](100) NULL,
	[Last_Donation_Date] [date] NULL,
	[Donated_Amount] [int] NULL,
	[Phone_Number] [varchar](15) NULL,
	[Points] [int] NULL,
	[Username] [varchar](100) NULL,
	[Vol_Password] [varchar](200) NULL,
 CONSTRAINT [PK__Voluntee__FE1D4DD54412A4F3] PRIMARY KEY CLUSTERED 
(
	[Volunteer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteer_Participated_In]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer_Participated_In](
	[Project_Num] [int] NOT NULL,
	[Volunteer_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Volunteer_ID] ASC,
	[Project_Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Dep_Number], [Dep_Name], [Dep_Location]) VALUES (1, N'Head', N'Giza')
INSERT [dbo].[Department] ([Dep_Number], [Dep_Name], [Dep_Location]) VALUES (2, N'Finance', N'Cairo')
INSERT [dbo].[Department] ([Dep_Number], [Dep_Name], [Dep_Location]) VALUES (3, N'Public Relations', N'Giza')
INSERT [dbo].[Department] ([Dep_Number], [Dep_Name], [Dep_Location]) VALUES (4, N'Human Resources', N'Tanta')
INSERT [dbo].[Department] ([Dep_Number], [Dep_Name], [Dep_Location]) VALUES (5, N'Logistics', N'Cairo')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (1, N'Osama', N'Mohamed', N'01022020337', CAST(N'1975-12-12' AS Date), N'Male', N'Cairo', 1, N'$MYHASH$V1$10000$YxsB91oVYiicAk6mTHmvBb8DGxnkC7y6q9ByJGwfL4RAHUz3', N'Osama')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (4, N'Momtaz', N'Baher', N'01022020320', CAST(N'2001-12-26' AS Date), N'Male', N'Cairo', 5, N'$MYHASH$V1$10000$Ytmw/UN3xR4EoOfmr7ZcIdfhnjQYrH0kW2KaQtNIu8vtUdaU', N'MomtazBaher')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (6, N'Gaber', N'Baher', N'01022020129', CAST(N'2001-12-26' AS Date), N'Male', N'Cairo', 5, N'$MYHASH$V1$10000$d0plHCA5dtdbtqsLarBa9M+JVED4aIqDsTWPpEm+Qu3V4RNk', N'GaberBaher')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (8, N'Hussein', N'Hadidy', N'01021020128', CAST(N'2002-12-26' AS Date), N'Male', N'Giza', 5, N'$MYHASH$V1$10000$ny1sUTFO0S/TC1FEBneAzq+00pQcQLDKzvAHj392YhasWWil', N'HusseinHadidy')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (18, N'Dina', N'Medhat', N'01123122159', CAST(N'2001-12-26' AS Date), N'Female', N'Qena', 5, N'$MYHASH$V1$10000$QgNK3XwoQya5akPGQNu3sQJZGxoaOIsSnwgdMG6cJ6GInmpn', N'DinaMedhat')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (20, N'Hossam', N'Mohsen', N'01022020331', CAST(N'2001-12-26' AS Date), N'Male', N'Cairo', 2, N'$MYHASH$V1$10000$cii6fffcSNazabDPOveNQIOkgKqVntECBjbPAYWzzRW39aFX', N'HossamMohsen')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (21, N'Momtaz', N'Mohsen', N'01022020330', CAST(N'2001-12-26' AS Date), N'Male', N'Cairo', 3, N'$MYHASH$V1$10000$gCRMRw3qjHouzXh0ueDZo9dVUG0iDclWykDvCUdmKBWGtde5', N'MomtazMohsen')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (25, N'Gaber', N'Yassin', N'01021020129', CAST(N'2002-12-26' AS Date), N'Male', N'Tanta', 3, N'$MYHASH$V1$10000$J4RqGj6Eh7i5Dz3K/ZwdsFn08ha4Qss5gWMF6Gos372+m3IV', N'GaberYassin')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (27, N'Sherif', N'Hatem', N'01521020158', CAST(N'2002-12-26' AS Date), N'Male', N'Cairo', 5, N'$MYHASH$V1$10000$fvD40cuHum1KgLwUVLZSlGONOZFxuhLdgJ0tqq2nWXe5E0IA', N'SherifHatem')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (28, N'Salma', N'Osama', N'01521022158', CAST(N'2001-12-26' AS Date), N'Female', N'Giza', 2, N'$MYHASH$V1$10000$mB8LT9Cc2zAi3oTjDPD/f+3dj6tuXbByXE0oR/BMUGGdVk9/', N'SalmaOsama')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (29, N'Habiba', N'Hisham', N'01523022158', CAST(N'2001-12-26' AS Date), N'Female', N'Giza', 3, N'$MYHASH$V1$10000$2liayrkrc6gxB0VTrCIcJfiTtOIulJI+OTQ0pTTqBGLWINiI', N'HabibaHisham')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (31, N'Omar', N'Hatem', N'01123022151', CAST(N'2001-12-26' AS Date), N'Male', N'Giza', 5, N'$MYHASH$V1$10000$bNgI/rvnyZ1mbjo2DbLj1nzAbfdILNf+mj9P66MPiiomTD8o', N'OmarHatem')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (32, N'Arthus', N'Hatem', N'01123022150', CAST(N'2001-12-26' AS Date), N'Male', N'Giza', 2, N'$MYHASH$V1$10000$K+GlnhCIp6gFhqMOFkkGFmmlga8J22Ap5LyMrqJCBtpZdofw', N'ArthusHatem')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (33, N'Salma', N'Omar', N'01123029150', CAST(N'2001-12-26' AS Date), N'Female', N'Aswan', 3, N'$MYHASH$V1$10000$SUob3rPaRteb1xWRAZ2dkNR/H2kZQGwZcmPOSPaB/GQC6PnS', N'SalmaOmar')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (34, N'Fatma', N'Hisham', N'01123022154', CAST(N'2001-12-26' AS Date), N'Female', N'Luxor', 4, N'$MYHASH$V1$10000$VZB666YKJuo1n8t03K87PMxfsL4lm9Ctbqb6zUhhOL4Eqg2j', N'FatmaHisham')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (35, N'Dina', N'Hisham', N'01123122154', CAST(N'2001-12-26' AS Date), N'Female', N'Qena', 5, N'$MYHASH$V1$10000$JJYCopTvBCUHTI03QwR3lMfbIZfxRW0TFKz39lBo4840XysO', N'DinaHisham')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (37, N'Karem', N'Fady', N'01022520337', CAST(N'2001-12-26' AS Date), N'Male', N'Giza', 2, N'$MYHASH$V1$10000$ztmDWlUVGzI2pc41rkhp+LmBfDDcpCd0UUbndXdhFQ6A5A9H', N'KaremFady')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (38, N'Karem', N'Osama', N'01022520333', CAST(N'2001-12-26' AS Date), N'Male', N'Giza', 5, N'$MYHASH$V1$10000$x0HqSH8DKIjMcPjk7yUaJjS7+KAwZdHpFJG/B7lkV1eT4SLn', N'KaremOsama')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (39, N'Mohsen', N'Osama', N'01522590333', CAST(N'2001-12-26' AS Date), N'Male', N'Giza', 5, N'$MYHASH$V1$10000$QoirSZ+CV2BU0HB+xMuWFlU0dZ6dpIdanVyUDgNrcRugFB1O', N'MohsenOsama')
INSERT [dbo].[Employee] ([Employee_id], [First_Name], [Last_Name], [Phone_Number], [Birth_Date], [Gender], [Employee_Address], [Department_No], [Emp_Password], [Username]) VALUES (40, N'Ahmed', N'Shenawy', N'01452293918', CAST(N'2004-12-26' AS Date), N'Male', N'Tanta', 4, N'$MYHASH$V1$10000$F9LPcq2Ama4yACoApv11Stm5Tn5T8jPUk02LA+rqTniYZupv', N'Shenawy')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Finance] ON 

INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (1, CAST(N'2022-12-26' AS Date), 1000, N'Donation', NULL, 2)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (2, CAST(N'2022-12-26' AS Date), 30000, N'Donation', NULL, 7)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (3, CAST(N'2022-12-26' AS Date), 9000, N'Donation', NULL, 7)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (4, CAST(N'2022-12-26' AS Date), 3000, N'Donation', NULL, 7)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (5, CAST(N'2022-12-26' AS Date), 5000, N'Donation', NULL, 7)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (6, CAST(N'2022-12-26' AS Date), 50000, N'Donation', NULL, 2)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (7, CAST(N'2022-12-26' AS Date), 9000, N'Donation', NULL, 2)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (8, CAST(N'2022-12-26' AS Date), 2000, N'Donation', NULL, 4)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (9, CAST(N'2022-12-26' AS Date), 10000, N'Donation', NULL, 4)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (10, CAST(N'2022-12-26' AS Date), 2000, N'Project', 1, NULL)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (11, CAST(N'2022-12-26' AS Date), 50000, N'Project', 2, NULL)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (12, CAST(N'2022-12-26' AS Date), 30000, N'Project', 3, NULL)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (13, CAST(N'2022-12-26' AS Date), 300, N'Project', 4, NULL)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (14, CAST(N'2022-12-26' AS Date), 900, N'Project', 18, NULL)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (15, CAST(N'2022-12-26' AS Date), 2000, N'Project', 20, NULL)
INSERT [dbo].[Finance] ([Transaction_No], [Issue_Date], [Monetary_Amount], [Transaction_Type], [Project_Code], [Volunteer_ID]) VALUES (16, CAST(N'2022-12-26' AS Date), 10000, N'Project', 5, NULL)
SET IDENTITY_INSERT [dbo].[Finance] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory_Site] ON 

INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (1, 800, N'Food', N'Dokki', 29)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (2, 1440, N'Medicine', N'Sheikh Zayed', 34)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (3, 605, N'Shelter', N'Mohandessin', 1)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (4, 700, N'Medicine', N'Dokki', 20)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (5, 1500, N'Food', N'October', 32)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (6, 0, N'Food', N'Maadi', 38)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (7, 0, N'Shelter', N'Nasr City', 37)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (8, 0, N'Shelter', N'5th settlement', 27)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (9, 0, N'Food', N'Dokki', 37)
INSERT [dbo].[Inventory_Site] ([Site_No], [No_Of_Items], [Supply_Type], [Site_Address], [Employee_Num]) VALUES (10, 0, N'Medicine', N'Maadi', 39)
SET IDENTITY_INSERT [dbo].[Inventory_Site] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (1, N'Roofs For Veterans', N'Giza', CAST(N'2022-12-22' AS Date), CAST(N'2022-12-29' AS Date), N'active', 100, 25, N'Shelter', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (2, N'Roofs For Kids', N'Giza', CAST(N'2022-12-22' AS Date), CAST(N'2022-12-30' AS Date), N'active', 200, 4, N'Shelter', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (3, N'Roofs For Family', N'Cairo', CAST(N'2022-12-22' AS Date), CAST(N'2023-01-01' AS Date), N'active', 300, 8, N'Shelter', 300)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (4, N'Medicine For 57357', N'Tanta', CAST(N'2022-12-22' AS Date), CAST(N'2023-01-01' AS Date), N'active', 400, 6, N'Medicine', 90)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (5, N'Food For Disabled', N'Cairo', CAST(N'2022-12-22' AS Date), CAST(N'2023-01-01' AS Date), N'active', 100, 8, N'Food', 200)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (6, N'Food For Elderly', N'Giza', CAST(N'2017-12-22' AS Date), CAST(N'2020-01-01' AS Date), N'active', 100, 6, N'Food', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (7, N'Shelter For Elderly', N'Giza', CAST(N'2017-12-22' AS Date), CAST(N'2033-01-01' AS Date), N'active', 800, 18, N'Shelter', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (8, N'Medicine For Elderly', N'Giza', CAST(N'2017-12-22' AS Date), CAST(N'2033-01-01' AS Date), N'active', 500, 20, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (9, N'Medicine For Refugees', N'Cairo', CAST(N'2017-12-22' AS Date), CAST(N'2018-01-01' AS Date), N'active', 50, 21, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (10, N'Shelter For Refugees', N'Cairo', CAST(N'2001-12-22' AS Date), CAST(N'2009-01-01' AS Date), N'active', 100, 25, N'Shelter', 100)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (11, N'Medicine For Demerdash', N'Giza', CAST(N'2001-12-22' AS Date), CAST(N'2004-01-01' AS Date), N'active', 100, 27, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (12, N'Medicine For KasrAiny', N'Qena', CAST(N'2001-12-22' AS Date), CAST(N'2004-01-01' AS Date), N'active', 100, 28, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (13, N'Medicine For Baheya', N'Qena', CAST(N'2001-12-22' AS Date), CAST(N'2025-01-01' AS Date), N'active', 250, 29, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (14, N'Food For FoodBank', N'Qena', CAST(N'2001-12-22' AS Date), CAST(N'2004-01-01' AS Date), N'active', 500, 31, N'Food', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (15, N'Meals For Primary', N'Qena', CAST(N'2001-12-22' AS Date), CAST(N'2026-01-01' AS Date), N'active', 1000, 32, N'Food', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (16, N'Medicine For Primary', N'Luxor', CAST(N'2001-12-22' AS Date), CAST(N'2026-01-01' AS Date), N'active', 1500, 33, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (17, N'Medicine For AbuReesh', N'Luxor', CAST(N'2001-12-22' AS Date), CAST(N'2026-01-01' AS Date), N'active', 2000, 34, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (18, N'Ramadan Meals ', N'Giza', CAST(N'2001-12-22' AS Date), CAST(N'2007-01-01' AS Date), N'active', 400, 35, N'Food', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (19, N'COVID Vaccines', N'Giza', CAST(N'2001-12-22' AS Date), CAST(N'2007-01-01' AS Date), N'active', 750, 4, N'Medicine', 0)
INSERT [dbo].[Project] ([Project_Num], [Project_Name], [Project_City], [Project_Start_Date], [Project_End_Date], [Project_Status], [Points_If_joined], [Employee_Id], [supply_type], [supply_quantity]) VALUES (20, N'Painting 57357', N'Luxor', CAST(N'2001-12-22' AS Date), CAST(N'2029-01-01' AS Date), N'active', 50, 6, N'Shelter', 0)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipient] ON 

INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (2, N'Mohamed', N'Samir', N'Male', CAST(N'2002-12-26' AS Date), N'Cairo', N'01010076453', 4, 7)
INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (3, N'Mohamed', N'Jim', N'Male', CAST(N'2001-12-19' AS Date), N'Cairo', N'01022020893', 1, 7)
INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (4, N'Karim', N'Gaber', N'Male', CAST(N'2000-12-01' AS Date), N'Giza', N'01022020983', 3, 1)
INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (5, N'Hussein', N'Omar', N'Male', CAST(N'1999-01-01' AS Date), N'Tanta', N'01021001013', 4, 4)
INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (6, N'Gamil', N'Hassan', N'Male', CAST(N'1990-01-03' AS Date), N'Luxor', N'01023010301', 2, 5)
INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (7, N'Samira', N'Mohsen', N'Female', CAST(N'1989-12-12' AS Date), N'Aswan', N'01591290912', 5, 4)
INSERT [dbo].[Recipient] ([Recipient_id], [First_Name], [Last_Name], [Gender], [Birth_Date], [Recipient_Address], [Phone_Number], [Feedback_Rating], [Project_No]) VALUES (8, N'Gamila', N'Karem', N'Female', CAST(N'1989-12-11' AS Date), N'Giza', N'01122012038', 5, 5)
SET IDENTITY_INSERT [dbo].[Recipient] OFF
GO
SET IDENTITY_INSERT [dbo].[Request] ON 

INSERT [dbo].[Request] ([Request_No], [Request_Type], [Date_Issued], [Request_Status], [Project_key], [Volunteer_Code], [Department_No]) VALUES (1, N'Employee_Request', CAST(N'2022-12-26' AS Date), N'Rejected', NULL, 2, 4)
INSERT [dbo].[Request] ([Request_No], [Request_Type], [Date_Issued], [Request_Status], [Project_key], [Volunteer_Code], [Department_No]) VALUES (2, N'Employee_Request', CAST(N'2022-12-26' AS Date), N'Rejected', NULL, 2, 1)
INSERT [dbo].[Request] ([Request_No], [Request_Type], [Date_Issued], [Request_Status], [Project_key], [Volunteer_Code], [Department_No]) VALUES (3, N'Employee_Request', CAST(N'2022-12-26' AS Date), N'Accepted', NULL, 9, 4)
INSERT [dbo].[Request] ([Request_No], [Request_Type], [Date_Issued], [Request_Status], [Project_key], [Volunteer_Code], [Department_No]) VALUES (4, N'Employee_Request', CAST(N'2022-12-26' AS Date), N'Pending', NULL, 9, 5)
INSERT [dbo].[Request] ([Request_No], [Request_Type], [Date_Issued], [Request_Status], [Project_key], [Volunteer_Code], [Department_No]) VALUES (5, N'Project_Join_Request', CAST(N'2022-12-26' AS Date), N'Accepted', 4, 2, NULL)
INSERT [dbo].[Request] ([Request_No], [Request_Type], [Date_Issued], [Request_Status], [Project_key], [Volunteer_Code], [Department_No]) VALUES (6, N'Project_Join_Request', CAST(N'2022-12-26' AS Date), N'Accepted', 6, 7, NULL)
SET IDENTITY_INSERT [dbo].[Request] OFF
GO
SET IDENTITY_INSERT [dbo].[Rewards] ON 

INSERT [dbo].[Rewards] ([Reward_No], [Date_Taken], [Reward_Type], [Affiliate], [Volunteer_No], [Reward_Points], [Phone_Number]) VALUES (1, CAST(N'2022-12-26' AS Date), N'T-Shirt', N'Nike', 7, 80, N'01022920331')
INSERT [dbo].[Rewards] ([Reward_No], [Date_Taken], [Reward_Type], [Affiliate], [Volunteer_No], [Reward_Points], [Phone_Number]) VALUES (2, NULL, N'Shoes', N'Puma', NULL, 100, N'01022920331')
INSERT [dbo].[Rewards] ([Reward_No], [Date_Taken], [Reward_Type], [Affiliate], [Volunteer_No], [Reward_Points], [Phone_Number]) VALUES (3, CAST(N'2022-12-26' AS Date), N'Sneakers', N'Addidas', 2, 300, N'01012120331')
INSERT [dbo].[Rewards] ([Reward_No], [Date_Taken], [Reward_Type], [Affiliate], [Volunteer_No], [Reward_Points], [Phone_Number]) VALUES (4, NULL, N'Laptop', N'Dell', NULL, 10000, N'01012120331')
INSERT [dbo].[Rewards] ([Reward_No], [Date_Taken], [Reward_Type], [Affiliate], [Volunteer_No], [Reward_Points], [Phone_Number]) VALUES (5, NULL, N'Wallet', N'Mont Blanc', NULL, 10000, N'01012120331')
INSERT [dbo].[Rewards] ([Reward_No], [Date_Taken], [Reward_Type], [Affiliate], [Volunteer_No], [Reward_Points], [Phone_Number]) VALUES (6, NULL, N'TV', N'LG', NULL, 10000, N'01012120331')
SET IDENTITY_INSERT [dbo].[Rewards] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (1, N'1022020337', N'Food', CAST(N'2021-12-02' AS Date), CAST(N'2022-10-10' AS Date), 200, N'Mohamed')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (2, N'1022020338', N'Medicine', CAST(N'2021-12-22' AS Date), CAST(N'2022-10-12' AS Date), 1970, N'Tarek')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (3, N'1022020339', N'Shelter', CAST(N'2021-12-09' AS Date), CAST(N'2022-10-13' AS Date), 0, N'Hossam')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (4, N'1022520337', N'Food', CAST(N'2021-12-10' AS Date), CAST(N'2022-10-15' AS Date), 1500, N'Hussein')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (5, N'1022620329', N'Medicine', CAST(N'2021-12-19' AS Date), CAST(N'2022-10-16' AS Date), 0, N'Sherif')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (6, N'1022720317', N'Shelter', CAST(N'2021-12-11' AS Date), CAST(N'2022-10-03' AS Date), 300, N'Fady')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (7, N'1022820337', N'Food', CAST(N'2021-12-11' AS Date), CAST(N'2022-10-18' AS Date), 0, N'Mohsen')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (8, N'1012820337', N'Medicine', CAST(N'2021-12-12' AS Date), CAST(N'2022-10-12' AS Date), 2200, N'Tawfik')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (9, N'1112820337', N'Medicine', CAST(N'2021-12-12' AS Date), CAST(N'2022-10-12' AS Date), 1000, N'Yassin')
INSERT [dbo].[Supplier] ([Supplier_id], [Phone_Number], [Supplied_Product], [Contract_Start_Date], [Contract_End_Date], [Quantity_Availble], [Supplier_Name]) VALUES (10, N'1512820337', N'Shelter', CAST(N'2021-12-07' AS Date), CAST(N'2022-10-06' AS Date), 150, N'Gaber')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplies_Project] ON 

INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (10, 2, 4, 3)
INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (40, 2, 4, 4)
INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (40, 2, 4, 5)
INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (40, 9, 5, 6)
INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (160, 9, 5, 7)
INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (100, 8, 10, 9)
INSERT [dbo].[Supplies_Project] ([Number_Of_Items], [Site_No], [Project_Num], [Transfer_Id]) VALUES (300, 3, 3, 11)
SET IDENTITY_INSERT [dbo].[Supplies_Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplies_Site] ON 

INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (30, 2, 2, 1)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (5, 3, 6, 2)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (500, 4, 5, 3)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (50, 4, 5, 5)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (50, 4, 5, 7)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (60, 4, 5, 8)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (40, 4, 5, 9)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (50, 9, 7, 11)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (150, 9, 7, 12)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (100, 8, 6, 13)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (900, 3, 3, 14)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (1500, 5, 4, 16)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (1500, 2, 9, 17)
INSERT [dbo].[Supplies_Site] ([Number_Of_Items], [Site_No], [Supplier_Num], [Transfer_id]) VALUES (800, 1, 1, 19)
SET IDENTITY_INSERT [dbo].[Supplies_Site] OFF
GO
SET IDENTITY_INSERT [dbo].[Volunteer] ON 

INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (1, N'Osama', N'Fathy', CAST(N'1990-12-26' AS Date), N'Male', N'Cairo', NULL, 0, N'01203744447', 0, N'OsamaFathy', N'$MYHASH$V1$10000$3AQUeONs+sxAr08kgCZXpFsLgF/lWhIJj7NjWoj14Vsl0Qd2')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (2, N'Salma', N'Osama', CAST(N'2002-12-26' AS Date), N'Female', N'Cairo', CAST(N'2022-12-26' AS Date), 60000, N'01012996919', 5800, N'SalmaOsama', N'$MYHASH$V1$10000$f4P6lC9ScUOHdmsApmODFZJNAE/4jWksTQRIAkuc0q2FxoDK')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (3, N'Rana', N'Hatem', CAST(N'2002-12-26' AS Date), N'Female', N'Giza', NULL, 0, N'01012996912', 0, N'RanaHatem', N'$MYHASH$V1$10000$KiD/OCOL6ipVZU2OIMpbKNjwJ+w9zRBfguRztdsnOa488jA8')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (4, N'Jana', N'Hatem', CAST(N'2001-12-26' AS Date), N'Female', N'Giza', CAST(N'2022-12-26' AS Date), 12000, N'01052996912', 1200, N'JanaHatem', N'$MYHASH$V1$10000$XqQ1zS6i5h8xCMqDFYmIk1xT6CtKQm0m8A0CpTtrre2xOOko')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (5, N'Dina', N'Omar', CAST(N'2000-12-26' AS Date), N'Female', N'Giza', NULL, 0, N'01452996912', 0, N'DinaOmar', N'$MYHASH$V1$10000$s7HsWlgSp3I/YDaAKiEjPxYQKMYiQKUF6WIWd1Lpcml/TU+u')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (6, N'Dina', N'Jaber', CAST(N'1999-12-26' AS Date), N'Female', N'Cairo', NULL, 0, N'01452296912', 0, N'DinaJaber', N'$MYHASH$V1$10000$fvknoqXRIOTmNIeVcuwqgDnbv4987sSvVy8kGjcfNkvXexgz')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (7, N'Ahmed', N'Mansy', CAST(N'2000-12-26' AS Date), N'Male', N'Cairo', CAST(N'2022-12-26' AS Date), 47000, N'01452297912', 4720, N'AhmedMansy', N'$MYHASH$V1$10000$kP3LJq1kCsdPML5TNzeFN4yCQ2m5Az7EJHoL1fkZ9Lgtc4Vn')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (8, N'Saad', N'Samir', CAST(N'2004-12-26' AS Date), N'Male', N'Giza', NULL, 0, N'01452293912', 0, N'SaadSamir', N'$MYHASH$V1$10000$JcU1ARMY+Ocz02Wu09ZWH+X7BpgV5YvCRTwjMGi/uf/pbNGV')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (9, N'Ahmed', N'Shenawy', CAST(N'2004-12-26' AS Date), N'Male', N'Tanta', NULL, 0, N'01452293918', 0, N'AhmedShenawy', N'$MYHASH$V1$10000$F9LPcq2Ama4yACoApv11Stm5Tn5T8jPUk02LA+rqTniYZupv')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (10, N'Ahmed', N'Medhat', CAST(N'2001-12-26' AS Date), N'Male', N'Qena', NULL, 0, N'01452493918', 0, N'AhmedMedhat', N'$MYHASH$V1$10000$W9x/DgVA5enDoCKVl6XpIJejMnRyP7OTA5gxowjKBx4AK19N')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (11, N'Sayed', N'Mooad', CAST(N'2000-12-25' AS Date), N'Male', N'Luxor', NULL, 0, N'01452493978', 0, N'SayedMooad', N'$MYHASH$V1$10000$DbupusFAvp/ZtQ/q1gyBamTxJIrPFisc0xa5VAV2bl1lsZSj')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (12, N'Mohamed', N'Barakat', CAST(N'2000-12-25' AS Date), N'Male', N'Luxor', NULL, 0, N'01452493970', 0, N'MohamedBarakat', N'$MYHASH$V1$10000$wAbagZgakftyzhxPX96d5eMwoqv6fv9obSTSSM5u+VT9ecyx')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (13, N'Hussein', N'Hadidy', CAST(N'2000-12-25' AS Date), N'Male', N'Giza', NULL, 0, N'01492493970', 0, N'HusseinHadidy', N'$MYHASH$V1$10000$oAcWQDENQzl0n8sRhkubfVzNCaDOAzCAnN5bLeXGcnFQRUuj')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (14, N'Sylvanas', N'WindRunner', CAST(N'2000-12-25' AS Date), N'Female', N'Cairo', NULL, 0, N'01292493970', 0, N'SylvanasWindRunner', N'$MYHASH$V1$10000$Js6cbz/QSmxSvfE0H5VF0jDQ2gY5aSolLpl6GGAMxpGIk+1r')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (15, N'Youssef', N'Emad', CAST(N'1998-12-25' AS Date), N'Male', N'Cairo', NULL, 0, N'01298493970', 0, N'YoussefEmad', N'$MYHASH$V1$10000$gUwynwm7LqavgPf2Aqj7Yvfcu6Sr4b4d5x6gbjEHCe31wINr')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (16, N'Youssef', N'Zaki', CAST(N'2002-12-25' AS Date), N'Male', N'Tanta', NULL, 0, N'01208493970', 0, N'YoussefZaki', N'$MYHASH$V1$10000$Y8vEVFtVsEcoqBEayEfnT55ZBqfjJeGBdwipdapikTa3xL+Q')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (17, N'Mostafa', N'Metwally', CAST(N'2002-12-25' AS Date), N'Male', N'Tanta', NULL, 0, N'01278493970', 0, N'MostafaMetwally', N'$MYHASH$V1$10000$nBtLNR4xrlN9qsxoiijxzxMBv9RKIRnFTSeqc3QFQQcUY89T')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (18, N'Randa', N'Metwally', CAST(N'2004-12-25' AS Date), N'Female', N'Luxor', NULL, 0, N'01278494970', 0, N'RandaMetwally', N'$MYHASH$V1$10000$05IrEyUU9YV4QJeCSTn3HWoPo1dkSrAh2Hq4m5u0oHJ5CvOW')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (19, N'Randa', N'Omar', CAST(N'2004-12-25' AS Date), N'Female', N'Cairo', NULL, 0, N'01278495970', 0, N'RandaOmar', N'$MYHASH$V1$10000$QC4Y0KOYeYBFhjPG/veXBz8R5TycXV5OKNqv3F3s9/TR8dFC')
INSERT [dbo].[Volunteer] ([Volunteer_id], [First_Name], [Last_Name], [Birth_Date], [Gender], [Volunteer_Address], [Last_Donation_Date], [Donated_Amount], [Phone_Number], [Points], [Username], [Vol_Password]) VALUES (20, N'Tawfik', N'ElHakim', CAST(N'1980-12-25' AS Date), N'Male', N'Giza', NULL, 0, N'01278495979', 0, N'TawfikElHakim', N'$MYHASH$V1$10000$7OKM3Jn36QaSDTYB76sbZLqC1d0QdZ45ZIeBzHgcXjC9OxPq')
SET IDENTITY_INSERT [dbo].[Volunteer] OFF
GO
INSERT [dbo].[Volunteer_Participated_In] ([Project_Num], [Volunteer_ID]) VALUES (4, 2)
INSERT [dbo].[Volunteer_Participated_In] ([Project_Num], [Volunteer_ID]) VALUES (6, 7)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__BD75427931BFF61D]    Script Date: 12/26/2022 6:31:30 AM ******/
ALTER TABLE [dbo].[Department] ADD UNIQUE NONCLUSTERED 
(
	[Dep_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Employee]    Script Date: 12/26/2022 6:31:30 AM ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[Phone_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__536C85E4D76C9897]    Script Date: 12/26/2022 6:31:30 AM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Volunteer]    Script Date: 12/26/2022 6:31:30 AM ******/
ALTER TABLE [dbo].[Volunteer] ADD  CONSTRAINT [IX_Volunteer] UNIQUE NONCLUSTERED 
(
	[Phone_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Voluntee__536C85E449A375C8]    Script Date: 12/26/2022 6:31:30 AM ******/
ALTER TABLE [dbo].[Volunteer] ADD  CONSTRAINT [UQ__Voluntee__536C85E449A375C8] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD  DEFAULT ('Active') FOR [Project_Status]
GO
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_Points_If_joined]  DEFAULT ((0)) FOR [Points_If_joined]
GO
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_supply_quantity]  DEFAULT ((0)) FOR [supply_quantity]
GO
ALTER TABLE [dbo].[Request] ADD  DEFAULT ('Pending') FOR [Request_Status]
GO
ALTER TABLE [dbo].[Rewards] ADD  DEFAULT (NULL) FOR [Volunteer_No]
GO
ALTER TABLE [dbo].[Volunteer] ADD  CONSTRAINT [DF_Volunteer_Donated_Amount]  DEFAULT ((0)) FOR [Donated_Amount]
GO
ALTER TABLE [dbo].[Volunteer] ADD  CONSTRAINT [DF_Volunteer_Points]  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Department_No])
REFERENCES [dbo].[Department] ([Dep_Number])
GO
ALTER TABLE [dbo].[Finance]  WITH CHECK ADD  CONSTRAINT [FK__Finance__Project__3A81B327] FOREIGN KEY([Project_Code])
REFERENCES [dbo].[Project] ([Project_Num])
GO
ALTER TABLE [dbo].[Finance] CHECK CONSTRAINT [FK__Finance__Project__3A81B327]
GO
ALTER TABLE [dbo].[Finance]  WITH CHECK ADD  CONSTRAINT [FK__Finance__Volunte__398D8EEE] FOREIGN KEY([Volunteer_ID])
REFERENCES [dbo].[Volunteer] ([Volunteer_id])
GO
ALTER TABLE [dbo].[Finance] CHECK CONSTRAINT [FK__Finance__Volunte__398D8EEE]
GO
ALTER TABLE [dbo].[Inventory_Site]  WITH CHECK ADD FOREIGN KEY([Employee_Num])
REFERENCES [dbo].[Employee] ([Employee_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([Employee_Id])
REFERENCES [dbo].[Employee] ([Employee_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Recipient]  WITH CHECK ADD FOREIGN KEY([Project_No])
REFERENCES [dbo].[Project] ([Project_Num])
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD FOREIGN KEY([Department_No])
REFERENCES [dbo].[Department] ([Dep_Number])
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD FOREIGN KEY([Project_key])
REFERENCES [dbo].[Project] ([Project_Num])
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK__Request__Volunte__4316F928] FOREIGN KEY([Volunteer_Code])
REFERENCES [dbo].[Volunteer] ([Volunteer_id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK__Request__Volunte__4316F928]
GO
ALTER TABLE [dbo].[Rewards]  WITH CHECK ADD  CONSTRAINT [FK__Rewards__Volunte__3E52440B] FOREIGN KEY([Volunteer_No])
REFERENCES [dbo].[Volunteer] ([Volunteer_id])
GO
ALTER TABLE [dbo].[Rewards] CHECK CONSTRAINT [FK__Rewards__Volunte__3E52440B]
GO
ALTER TABLE [dbo].[Supplies_Project]  WITH CHECK ADD  CONSTRAINT [FK__Supplies___Proje__4BAC3F29] FOREIGN KEY([Project_Num])
REFERENCES [dbo].[Project] ([Project_Num])
GO
ALTER TABLE [dbo].[Supplies_Project] CHECK CONSTRAINT [FK__Supplies___Proje__4BAC3F29]
GO
ALTER TABLE [dbo].[Supplies_Project]  WITH CHECK ADD  CONSTRAINT [FK__Supplies___Site___4AB81AF0] FOREIGN KEY([Site_No])
REFERENCES [dbo].[Inventory_Site] ([Site_No])
GO
ALTER TABLE [dbo].[Supplies_Project] CHECK CONSTRAINT [FK__Supplies___Site___4AB81AF0]
GO
ALTER TABLE [dbo].[Supplies_Site]  WITH CHECK ADD  CONSTRAINT [FK__Supplies___Site___4E88ABD4] FOREIGN KEY([Site_No])
REFERENCES [dbo].[Inventory_Site] ([Site_No])
GO
ALTER TABLE [dbo].[Supplies_Site] CHECK CONSTRAINT [FK__Supplies___Site___4E88ABD4]
GO
ALTER TABLE [dbo].[Supplies_Site]  WITH CHECK ADD  CONSTRAINT [FK__Supplies___Suppl__4F7CD00D] FOREIGN KEY([Supplier_Num])
REFERENCES [dbo].[Supplier] ([Supplier_id])
GO
ALTER TABLE [dbo].[Supplies_Site] CHECK CONSTRAINT [FK__Supplies___Suppl__4F7CD00D]
GO
ALTER TABLE [dbo].[Volunteer_Participated_In]  WITH CHECK ADD FOREIGN KEY([Project_Num])
REFERENCES [dbo].[Project] ([Project_Num])
GO
ALTER TABLE [dbo].[Volunteer_Participated_In]  WITH CHECK ADD  CONSTRAINT [FK__Volunteer__Volun__46E78A0C] FOREIGN KEY([Volunteer_ID])
REFERENCES [dbo].[Volunteer] ([Volunteer_id])
GO
ALTER TABLE [dbo].[Volunteer_Participated_In] CHECK CONSTRAINT [FK__Volunteer__Volun__46E78A0C]
GO
/****** Object:  StoredProcedure [dbo].[addDonation]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[addDonation]
	-- Add the parameters for the stored procedure here
	@Date  date, 
	@montamount decimal(10, 2),
	@transactiontype varchar(50) , 
	@volID int
AS
BEGIN
INSERT INTO Finance(Issue_Date,Monetary_Amount,Transaction_Type,Volunteer_ID)
Values (@Date,@montamount,@transactiontype,@volID)
END

GO
/****** Object:  StoredProcedure [dbo].[AddProjectFunding]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddProjectFunding]
	-- Add the parameters for the stored procedure here
	 @projectnum int,
	 @amount int,
	 @date Date
AS
BEGIN
INSERT INTO Finance(Issue_Date,Monetary_Amount,Transaction_Type,Project_Code)
values(@date,@amount,'Project',@projectnum)
END
GO
/****** Object:  StoredProcedure [dbo].[addVolunteertoProject]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[addVolunteertoProject]
	-- Add the parameters for the stored procedure here
	 @projectnum int,
	 @Volunteerid int
AS
BEGIN
INSERT INTO Volunteer_Participated_In(Project_Num,Volunteer_ID)
Values (@projectnum,@Volunteerid)
END
GO
/****** Object:  StoredProcedure [dbo].[daysRemaining]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[daysRemaining]
	-- Add the parameters for the stored procedure here
	 @currDate date
AS
BEGIN
Select Project.Project_Name,DATEDIFF(day,Project.Project_End_Date, @currDate) AS date_difference
from Project
where Project_End_Date < @currDate AND Project.Project_Status='Active'
END
GO
/****** Object:  StoredProcedure [dbo].[FindAvailableFunds]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindAvailableFunds]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
SELECT ((SELECT SUM(Monetary_Amount) From Finance where Transaction_Type='Donation') - (SELECT SUM(Monetary_Amount) From Finance where Transaction_Type='Project'))
END
GO
/****** Object:  StoredProcedure [dbo].[GetAffiliateNumber]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAffiliateNumber]
	-- Add the parameters for the stored procedure here
	@Affiliate varchar(50)
AS
BEGIN
SELECT distinct Phone_Number
FROM Rewards
where Affiliate=@Affiliate
END
GO
/****** Object:  StoredProcedure [dbo].[GetAffiliates]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAffiliates]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
SELECT distinct Affiliate, Phone_Number
FROM Rewards
END
GO
/****** Object:  StoredProcedure [dbo].[getEmployeeDepartment]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getEmployeeDepartment]
	-- Add the parameters for the stored procedure here
	 @empId int
AS
BEGIN
Select Department.Dep_Name 
From Department, Employee
where Department.Dep_Number=Employee.Department_No AND Employee.Employee_id=@empId
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecipients]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRecipients]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
SELECT  Recipient_id,First_Name,Last_Name, Phone_Number
FROM Recipient
END
GO
/****** Object:  StoredProcedure [dbo].[insertReward]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertReward]
	-- Add the parameters for the stored procedure here
	@Reward_Type  varchar(50), 
	@Affiliate varchar(50),
	@Phone_Number varchar(50), 
	@Reward_Points int
AS
BEGIN
INSERT INTO Rewards(Reward_Type,Affiliate,Reward_Points,Phone_Number)
Values (@Reward_Type,@Affiliate,@Reward_Points,@Phone_Number)
END
GO
/****** Object:  StoredProcedure [dbo].[requestsVolunteertoProject]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[requestsVolunteertoProject]

AS
BEGIN
Select Request.Request_No,Request.Volunteer_Code,Request.Project_key,Request.Date_Issued,First_Name, Project.Project_Name from Request,Volunteer,Project where Request.Project_key=Project.Project_Num AND Request.Volunteer_Code=Volunteer.Volunteer_id AND Request.Request_Status='Pending' AND Request_Type='Project_Join_Request' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectActiveProjects]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectActiveProjects]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
SELECT Project_Num,Project_Name,Project_Start_Date,Project_End_Date,Project_Capital From Project where Project_Status='active'
END
GO
/****** Object:  StoredProcedure [dbo].[SetFeedback]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetFeedback]
	-- Add the parameters for the stored procedure here
	 
	@Recipient_id int,
	@Feedback_Rating int
AS
BEGIN
UPDATE Recipient
SET Feedback_Rating=@Feedback_Rating
WHERE Recipient_id=@Recipient_id
END
GO
/****** Object:  StoredProcedure [dbo].[SetProjectInactive]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetProjectInactive]
	-- Add the parameters for the stored procedure here
	 @projectnum int
	 
AS
BEGIN
Update Project
Set Project_Status='inactive' where Project_Num=@projectnum
END
GO
/****** Object:  Trigger [dbo].[incPointsDueToDon_Trigger]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[incPointsDueToDon_Trigger]
ON [dbo].[Finance] after insert as
declare @Vol_id int;
declare @monamount int;
declare @type varchar(50)
set @monamount=(select Monetary_Amount from inserted)
set @Vol_id=(select Volunteer_ID  from inserted)
set @type=(select Transaction_Type  from inserted)
begin
UPDATE Volunteer
SET Volunteer.Points = Volunteer.Points + (0.1 * @monamount)
Where Volunteer.Volunteer_id=@Vol_id AND @type='Donation'
end
GO
ALTER TABLE [dbo].[Finance] ENABLE TRIGGER [incPointsDueToDon_Trigger]
GO
/****** Object:  Trigger [dbo].[incrementDonationAmount_Trigger]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[incrementDonationAmount_Trigger]
ON [dbo].[Finance] after insert as
declare @Vol_id int;
declare @type varchar(50);
declare @monamount int
set @Vol_id=(select Volunteer_ID  from inserted)
set @monamount=(select Monetary_Amount  from inserted)
set @type=(select Transaction_Type  from inserted)
begin
UPDATE Volunteer
SET Donated_Amount = Donated_Amount+@monamount
Where Volunteer.Volunteer_id=@Vol_id AND @type='Donation'
end
GO
ALTER TABLE [dbo].[Finance] ENABLE TRIGGER [incrementDonationAmount_Trigger]
GO
/****** Object:  Trigger [dbo].[updateDonationDate_Trigger]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[updateDonationDate_Trigger]
ON [dbo].[Finance] after insert as
declare @Vol_id int;
declare @date date;
declare @type varchar(50);
set @Vol_id=(select Volunteer_ID  from inserted)
set @date=(select Issue_Date  from inserted)
set @type=(select Transaction_Type  from inserted)
begin
UPDATE Volunteer
SET Last_Donation_Date = @date
Where Volunteer.Volunteer_id=@Vol_id AND @type='Donation'
end
GO
ALTER TABLE [dbo].[Finance] ENABLE TRIGGER [updateDonationDate_Trigger]
GO
/****** Object:  Trigger [dbo].[Points_Due_to_Rewards_up]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Points_Due_to_Rewards_up]
ON [dbo].[Rewards] after update as
declare @Vol_id int;
declare @Rew_Points int;
set @Rew_Points=(select Reward_Points from inserted)
set @Vol_id=(select Volunteer_No from inserted)
begin
UPDATE Volunteer
SET Volunteer.Points = Volunteer.Points - @Rew_Points
Where Volunteer.Volunteer_id=@Vol_id
end
GO
ALTER TABLE [dbo].[Rewards] ENABLE TRIGGER [Points_Due_to_Rewards_up]
GO
/****** Object:  Trigger [dbo].[Update_project_Trigger]    Script Date: 12/26/2022 6:31:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Update_project_Trigger]
ON [dbo].[Supplies_Project] after insert as
declare @numitems int;
declare @projectid int;
set @numitems=(select Number_Of_Items from inserted)
set @projectid=(select Project_Num from inserted)
begin
UPDATE Project
SET Project.supply_quantity = Project.supply_quantity + @numitems
Where Project.Project_Num = @projectid
end
GO
ALTER TABLE [dbo].[Supplies_Project] ENABLE TRIGGER [Update_project_Trigger]
GO
/****** Object:  Trigger [dbo].[Update_Sites_Trigger2]    Script Date: 12/26/2022 6:31:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Update_Sites_Trigger2]
ON [dbo].[Supplies_Project] after insert as
declare @numitems int;
declare @siteid int;
set @numitems=(select Number_Of_Items from inserted)
set @siteid=(select Site_No from inserted)
begin
UPDATE Inventory_Site
SET Inventory_Site.No_Of_Items = Inventory_Site.No_Of_Items - @numitems
Where Inventory_Site.Site_No=@siteid
end
GO
ALTER TABLE [dbo].[Supplies_Project] ENABLE TRIGGER [Update_Sites_Trigger2]
GO
/****** Object:  Trigger [dbo].[Update_Sites_Trigger]    Script Date: 12/26/2022 6:31:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Update_Sites_Trigger]
ON [dbo].[Supplies_Site] after insert as
declare @numitems int;
declare @siteid int;
set @numitems=(select Number_Of_Items from inserted)
set @siteid=(select Site_No from inserted)
begin
UPDATE Inventory_Site
SET Inventory_Site.No_Of_Items = Inventory_Site.No_Of_Items + @numitems
Where Inventory_Site.Site_No=@siteid
end
GO
ALTER TABLE [dbo].[Supplies_Site] ENABLE TRIGGER [Update_Sites_Trigger]
GO
/****** Object:  Trigger [dbo].[Update_Supplier_Trigger]    Script Date: 12/26/2022 6:31:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Update_Supplier_Trigger]
ON [dbo].[Supplies_Site] after insert as
declare @numitems int;
declare @supplierid int;
set @numitems=(select Number_Of_Items from inserted)
set @supplierid=(select Supplier_Num from inserted)
begin
UPDATE Supplier
SET Supplier.Quantity_Availble = Supplier.Quantity_Availble  - @numitems
Where Supplier.Supplier_id=@supplierid
end
GO
ALTER TABLE [dbo].[Supplies_Site] ENABLE TRIGGER [Update_Supplier_Trigger]
GO
/****** Object:  Trigger [dbo].[incPointsDueToJoinProj_Trigger]    Script Date: 12/26/2022 6:31:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[incPointsDueToJoinProj_Trigger]
ON [dbo].[Volunteer_Participated_In] after insert as
declare @Vol_id int;
declare @proj_id int;
set @proj_id=(select Project_Num from inserted)
set @Vol_id=(select Volunteer_ID  from inserted)
begin
UPDATE Volunteer
SET Volunteer.Points = Volunteer.Points +(Select Project.Points_If_joined from Project where Project_Num=1)
Where Volunteer.Volunteer_id=@Vol_id
end
GO
ALTER TABLE [dbo].[Volunteer_Participated_In] ENABLE TRIGGER [incPointsDueToJoinProj_Trigger]
GO
