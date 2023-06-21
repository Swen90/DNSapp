USE [DNS_my_ASS]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 21.06.2023 23:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CreatedAt] [date] NOT NULL,
	[ProductCount] [int] NULL,
	[Price] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCatalog]    Script Date: 21.06.2023 23:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatalog](
	[id] [int] NOT NULL,
	[Category] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[Price] [money] NOT NULL,
	[ProductCount] [int] NULL,
 CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userInfo]    Script Date: 21.06.2023 23:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userInfo](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[SecondName] [nvarchar](20) NULL,
	[PhoneNumber] [int] NULL,
 CONSTRAINT [PK_userInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [ProductId], [CustomerId], [CreatedAt], [ProductCount], [Price]) VALUES (2, 6666666, 1000004, CAST(N'2017-07-11' AS Date), 2, 15000.0000)
GO
INSERT [dbo].[Orders] ([Id], [ProductId], [CustomerId], [CreatedAt], [ProductCount], [Price]) VALUES (3, 6969696, 1000005, CAST(N'2017-07-13' AS Date), 1, 5000.0000)
GO
INSERT [dbo].[Orders] ([Id], [ProductId], [CustomerId], [CreatedAt], [ProductCount], [Price]) VALUES (4, 1010101, 1000002, CAST(N'2017-07-11' AS Date), 1, 15000.0000)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (1000001, N'Бытовая техника     ', N'Juice', 6500.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (1010101, N'Комплектующие       ', N'Процессор           ', 15000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (1111111, N'Бытовая техника     ', N'Стиральная машина   ', 45000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (1234567, N'Цифровая техника    ', N'PC                  ', 60000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (2323232, N'Бытовая техника     ', N'Пылесос             ', 10000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (3333333, N'Бытовая техника     ', N'Мясорубка           ', 11000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (6666666, N'Комплектующие       ', N'Кулер               ', 4500.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (6819467, N'Бытовая техника', N'Холодильник', 50000.0000, 2)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (6969696, N'Бытовая техника     ', N'Блендер             ', 5000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (7654321, N'Цифровая техника    ', N'Ноутбук             ', 55000.0000, NULL)
GO
INSERT [dbo].[ProductCatalog] ([id], [Category], [Product], [Price], [ProductCount]) VALUES (9090909, N'Комплектующие       ', N'Видеокарта          ', 40000.0000, NULL)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000001, N'John', N'Mass', 965323284)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000002, N'Otari', N'Toliashvili', 987523032)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000003, N'Max', N'Payne', 965413012)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000004, N'John', N'Wick', 987451201)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000005, N'Kay', N'Dee', 965054580)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000006, N'Tom', N'Hanks', 777777777)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (1000007, N'Alice', N'Fox', NULL)
GO
INSERT [dbo].[userInfo] ([Id], [FirstName], [SecondName], [PhoneNumber]) VALUES (7239402, N'Александр', N'Разенбаун', 987456321)
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((1)) FOR [ProductCount]
GO
ALTER TABLE [dbo].[ProductCatalog] ADD  DEFAULT ((0)) FOR [ProductCount]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[userInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductCatalog] ([id])
ON DELETE CASCADE
GO
