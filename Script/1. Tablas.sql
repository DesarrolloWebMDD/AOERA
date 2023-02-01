USE [RedMusical]
GO
/****** Object:  Table [dbo].[CategoriaFutbol]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriaFutbol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Descripcion] [varchar](500) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FutbolSubCagoria]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FutbolSubCagoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaFutbolId] [int] NULL,
	[Nombre] [varchar](150) NULL,
	[Descripcion] [varchar](500) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ligas]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ligas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Descripcion] [varchar](500) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagoCompras]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PagoCompras](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdTienda] [char](8) NULL,
	[NumTransaccion] [varchar](6) NULL,
	[NumAutorizacion] [varchar](6) NULL,
	[NumOrden] [varchar](12) NOT NULL,
	[RefUnicaTransaccion] [char](32) NULL,
	[NumTransaccionExterna] [varchar](6) NULL,
	[CodigoCliente] [varchar](14) NOT NULL,
	[NombreCliente] [varchar](30) NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[TotalPago] [numeric](12, 2) NOT NULL,
	[Moneda] [char](1) NOT NULL,
	[CanalPago] [char](1) NOT NULL,
	[TipoTarjeta] [varchar](10) NULL,
	[PanTarjeta] [char](16) NULL,
	[IdUser] [varchar](128) NULL,
	[EstadoPago] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagosIzipay]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[PagosIzipay](
	[shopId] [varchar](20) NOT NULL,
	[orderCycle] [varchar](20) NULL,
	[orderStatus] [varchar](20) NULL,
	[serverDate] [datetime] NULL,
	[orderTotalAmount] [decimal](10, 2) NULL,
	[orderCurrency] [char](3) NULL,
	[orderId] [varchar](20) NULL,
	[address] [varchar](100) NULL,
	[cellPhoneNumber] [varchar](12) NULL,
	[uuid] [varchar](100) NULL,
	[amount] [decimal](10, 2) NULL,
	[currency] [char](3) NULL,
	[paymentMethodType] [varchar](10) NULL,
	[paymentMethodToken] [varchar](10) NULL,
	[operationType] [varchar](10) NULL,
	[pan] [varchar](16) NULL,
	[expiryMonth] [int] NULL,
	[expiryYear] [int] NULL,
	[country] [char](2) NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoRegistro] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[shopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PuntosPaquete]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntosPaquete](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PuntosOferta] [decimal](18, 2) NULL,
	[Valor] [decimal](18, 2) NULL,
	[PuntosAcumulados] [decimal](18, 2) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TokenTarjetaPago]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TokenTarjetaPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [varchar](70) NULL,
	[Token] [varchar](40) NULL,
	[PanTarjeta] [char](16) NULL,
	[FechaRegistro] [datetime] NULL,
	[EstadoTarjeta] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[DNI] [char](8) NULL,
	[Telefono] [varchar](12) NULL,
	[Email] [varchar](80) NULL,
	[UserName] [varchar](50) NULL,
	[Clave] [varchar](150) NULL,
	[ImagenOriginal] [varchar](150) NULL,
	[KeyImagen] [varchar](150) NULL,
	[CodigoReferencia] [char](12) NULL,
	[CodigoInvitacion] [char](12) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPunto]    Script Date: 18/01/2022 23:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPunto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[PuntosRecarga] [decimal](18, 2) NULL,
	[PuntosPerdidos] [decimal](18, 2) NULL,
	[PuntosAcumulados] [decimal](18, 2) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FutbolSubCagoria]  WITH CHECK ADD FOREIGN KEY([CategoriaFutbolId])
REFERENCES [dbo].[CategoriaFutbol] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPunto]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
