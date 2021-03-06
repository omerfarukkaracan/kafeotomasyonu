USE [kafe]
GO
/****** Object:  Table [dbo].[category]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] NULL,
	[category] [nchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[k_giris]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[k_giris](
	[id] [nchar](10) NOT NULL,
	[kullanici_adi] [nchar](15) NULL,
	[kullanici_sifre] [nchar](50) NULL,
 CONSTRAINT [PK_k_giris] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[masa_deger]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[masa_deger](
	[id] [int] NOT NULL,
	[masa_deger] [nvarchar](max) NULL,
	[masa_adi] [nvarchar](max) NULL,
 CONSTRAINT [PK_masa_deger] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[masa_durum]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[masa_durum](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masa_durum] [int] NULL,
	[masa_adi] [nvarchar](max) NULL,
 CONSTRAINT [PK_masa_durum] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[masa_tutar]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[masa_tutar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masa_adi] [nvarchar](10) NULL,
	[masa_deger] [nvarchar](max) NULL,
	[masa_tutar] [nvarchar](12) NULL,
	[tarih] [nvarchar](max) NULL,
 CONSTRAINT [PK_masa_tutar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[masa_urunler]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[masa_urunler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masa_adi] [nchar](10) NULL,
	[product_name] [nchar](50) NULL,
	[product_category] [nchar](30) NULL,
	[masa_deger] [int] NULL,
	[product_adet] [int] NULL,
	[product_price] [int] NULL,
	[product_image] [nvarchar](max) NULL,
	[tarih] [nvarchar](50) NULL,
 CONSTRAINT [PK_masa_urunler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_add]    Script Date: 29.04.2022 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_add](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nchar](25) NULL,
	[product_category] [nchar](25) NULL,
	[product_price] [nchar](25) NULL,
	[product_weight] [nchar](25) NULL,
	[product_cost] [nchar](25) NULL,
	[product_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_product_add] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
