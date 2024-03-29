USE [RedMusical]
GO
/****** Object:  Table [dbo].[Aciertos]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aciertos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FechaCreado] [datetime] NULL,
	[TipoAcierto] [int] NULL,
	[PuntoApostado] [int] NULL,
	[PuntoGanar] [int] NULL,
	[EstadoAcierto] [int] NULL,
	[ResultadoFinal] [bit] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Audits]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[KeyValues] [nvarchar](max) NULL,
	[OldValues] [nvarchar](max) NULL,
	[NewValues] [nvarchar](max) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Audits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoriaFutbol]    Script Date: 8/02/2022 11:45:27 ******/
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
/****** Object:  Table [dbo].[ConfiguracionCorreo]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfiguracionCorreo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Asunto] [varchar](250) NOT NULL,
	[Cuerpo] [varchar](max) NULL,
	[Activo] [bit] NOT NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeporteResultados]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeporteResultados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeporteId] [int] NULL,
	[TextoTipo] [varchar](20) NULL,
	[PuntoResultado] [decimal](7, 2) NULL,
	[TipoResultado] [int] NULL,
	[Resultado] [bit] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Deportes]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Deportes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hora] [varchar](8) NULL,
	[FechaHora] [datetime] NULL,
	[EquiposReviales] [varchar](200) NULL,
	[EquipoA] [varchar](12) NULL,
	[EquipoB] [varchar](12) NULL,
	[PuntoA] [decimal](7, 2) NULL,
	[PuntoB] [decimal](7, 2) NULL,
	[EmpateTexto] [varchar](12) NULL,
	[EmpatePunto] [decimal](7, 2) NULL,
	[Gol1Text] [varchar](12) NULL,
	[PuntoGol1] [decimal](7, 2) NULL,
	[Gol2Text] [varchar](12) NULL,
	[PuntoGol2] [decimal](7, 2) NULL,
	[Gol3Text] [varchar](12) NULL,
	[PuntoGol3] [decimal](7, 2) NULL,
	[Gol4Text] [varchar](12) NULL,
	[PuntoGol4] [decimal](7, 2) NULL,
	[Gol_1Text] [varchar](12) NULL,
	[PuntoGol_1] [decimal](7, 2) NULL,
	[Gol_2Text] [varchar](12) NULL,
	[PuntoGol_2] [decimal](7, 2) NULL,
	[Gol_3Text] [varchar](12) NULL,
	[PuntoGol_3] [decimal](7, 2) NULL,
	[Gol_4Text] [varchar](12) NULL,
	[PuntoGol_4] [decimal](7, 2) NULL,
	[LocalEmpateTexto] [varchar](12) NULL,
	[LocalEmpatePunto] [decimal](7, 2) NULL,
	[EmpateVisitaTexto] [varchar](12) NULL,
	[EmpateVisitaPunto] [decimal](7, 2) NULL,
	[GolColSiTexto] [varchar](12) NULL,
	[GolColSiPunto] [decimal](7, 2) NULL,
	[GolColNoTexto] [varchar](12) NULL,
	[GolColNoPunto] [decimal](7, 2) NULL,
	[EstadoJuego] [int] NULL,
	[TotalCorners] [decimal](7, 2) NULL,
	[TotalTarjetas] [decimal](7, 2) NULL,
	[TotalGoles] [decimal](7, 2) NULL,
	[Estado] [bit] NULL,
	[LigaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleAciertos]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleAciertos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeporteId] [int] NULL,
	[TipoApuestaId] [int] NULL,
	[TipoApuestaTexto] [varchar](80) NULL,
	[PuntoGanar] [decimal](7, 2) NULL,
	[EquiposRivales] [varchar](100) NULL,
	[ResultadoFinal] [bit] NULL,
	[EstadoProceso] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FutbolSubCagoria]    Script Date: 8/02/2022 11:45:27 ******/
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
/****** Object:  Table [dbo].[Ligas]    Script Date: 8/02/2022 11:45:27 ******/
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
	[FutbolSubCagoriaId] [int] NULL,
	[Destacado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Maestro]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Maestro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Descripcion] [varchar](300) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaestroDetalle]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[MaestroDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Valor] [varchar](max) NULL,
	[Descripcion] [varchar](300) NULL,
	[Activo] [bit] NULL,
	[IdMaestro] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Membresia]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[FechaActivacion] [datetime] NULL,
	[FechaFinMembresia] [datetime] NULL,
	[EstadoMembresia] [bit] NULL,
	[MontoPagado] [decimal](7, 2) NULL,
	[MedioPago] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PagoCompras]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PagoCompras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagosIzipay]    Script Date: 8/02/2022 11:45:27 ******/
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
/****** Object:  Table [dbo].[Premios]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Premios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](500) NULL,
	[EstadoPremio] [int] NULL,
	[PuntoCanje] [numeric](18, 0) NULL,
	[FechaEntrega] [datetime] NULL,
	[EstadoWeb] [bit] NULL,
	[TipoPremio] [int] NULL,
	[CategoriaPremio] [int] NULL,
	[Periodo] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PremiosAuditoria]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PremiosAuditoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[PremioId] [int] NULL,
	[FechaEntrega] [datetime] NULL,
	[PuntosUsarioId] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PuntosPaquete]    Script Date: 8/02/2022 11:45:27 ******/
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
/****** Object:  Table [dbo].[TokenTarjetaPago]    Script Date: 8/02/2022 11:45:27 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/02/2022 11:45:27 ******/
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
	[Departamento] [varchar](80) NULL,
	[Provincia] [varchar](80) NULL,
	[CiudadRecidencia] [varchar](80) NULL,
	[FechaNacimiento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPunto]    Script Date: 8/02/2022 11:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPunto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Periodo] [int] NULL,
	[UsuarioId] [int] NULL,
	[PuntosMembresia] [decimal](18, 2) NULL,
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
SET IDENTITY_INSERT [dbo].[Audits] ON 

GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (1, N'Usuario', CAST(N'2022-02-01 04:00:04.087' AS DateTime), N'{"Id":5}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"v8/jOWnEA2hyQNFeEETXIw==","CodigoInvitacion":"001","CodigoReferencia":null,"DNI":"74595336","Departamento":"LIMA","Email":"socio.aoera@gmail.com","Estado":true,"FechaNacimiento":"1995-07-25T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"lima","Telefono":"974563218","UserName":"PAMPURA29"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (2, N'Usuario', CAST(N'2022-02-01 04:01:21.243' AS DateTime), N'{"Id":6}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"v8/jOWnEA2hyQNFeEETXIw==","CodigoInvitacion":"001","CodigoReferencia":null,"DNI":"74595336","Departamento":"LIMA","Email":"socio.aoera@gmail.com","Estado":true,"FechaNacimiento":"1995-07-25T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"lima","Telefono":"974563218","UserName":"PAMPURA29"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (3, N'Usuario', CAST(N'2022-02-01 04:12:19.483' AS DateTime), N'{"Id":7}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"v8/jOWnEA2hyQNFeEETXIw==","CodigoInvitacion":"001","CodigoReferencia":null,"DNI":"74595332","Departamento":"LIMA","Email":"david@gmail.com","Estado":true,"FechaNacimiento":"1995-07-25T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"lima","Telefono":"974563218","UserName":"PAMPURA21"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (4, N'Usuario', CAST(N'2022-02-01 04:19:10.367' AS DateTime), N'{"Id":8}', NULL, N'{"Apellidos":"MORALES LIMA","CiudadRecidencia":null,"Clave":"K/Z72Z0CFWcGpAeVZu4CnQ==","CodigoInvitacion":"","CodigoReferencia":null,"DNI":"31584769","Departamento":"LIMA","Email":"alex@gmail.com","Estado":true,"FechaNacimiento":"1995-03-15T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"ALEX","Provincia":"LIMA","Telefono":"987456654","UserName":"alex21"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (5, N'Usuario', CAST(N'2022-02-01 05:44:07.767' AS DateTime), N'{"Id":9}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":null,"DNI":"74595366","Departamento":"lima","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-03-09T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"david","Provincia":"Lima","Telefono":"985632147","UserName":"pampura29"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (6, N'Usuario', CAST(N'2022-02-01 05:49:44.897' AS DateTime), N'{"Id":10}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":null,"DNI":"74595366","Departamento":"lima","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-03-09T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"david","Provincia":"Lima","Telefono":"985632147","UserName":"pampura29"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (7, N'Usuario', CAST(N'2022-02-01 05:51:31.120' AS DateTime), N'{"Id":11}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":null,"DNI":"74595366","Departamento":"lima","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-03-09T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"david","Provincia":"Lima","Telefono":"985632147","UserName":"pampura29"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (8, N'Usuario', CAST(N'2022-02-01 05:56:34.840' AS DateTime), N'{"Id":12}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":null,"DNI":"74595366","Departamento":"lima","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-03-09T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"david","Provincia":"Lima","Telefono":"985632147","UserName":"pampura29"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (9, N'Usuario', CAST(N'2022-02-01 06:04:43.187' AS DateTime), N'{"Id":13}', NULL, N'{"Apellidos":"WALTER DAVILA","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"","CodigoReferencia":null,"DNI":"32658974","Departamento":"AYACUCHO","Email":"socio.aoera@gmail.com","Estado":true,"FechaNacimiento":"1983-08-04T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"MIGUEL","Provincia":"LIMA","Telefono":"958746321","UserName":"MIGUEL01"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (10, N'Usuario', CAST(N'2022-02-02 00:59:59.437' AS DateTime), N'{"Id":14}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":null,"DNI":"74595366","Departamento":"LIMA","Email":"socio.aoera@gmail.com","Estado":true,"FechaNacimiento":"1995-07-06T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"Lima","Telefono":"987456321","UserName":"DAVID10"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (11, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":8}', NULL, N'{"EmpatePunto":4.0,"EmpateTexto":"E","EmpateVisitaPunto":2.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Benfica & Ajax","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-23T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":6.0,"GolColNoTexto":"NO","GolColSiPunto":2.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":3.0,"LocalEmpateTexto":"LE","PuntoA":3.0,"PuntoB":2.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":4.0,"PuntoGol4":6.0,"PuntoGol_1":10.0,"PuntoGol_2":7.0,"PuntoGol_3":5.0,"PuntoGol_4":2.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (12, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":7}', NULL, N'{"EmpatePunto":4.0,"EmpateTexto":"E","EmpateVisitaPunto":3.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Atle. Madrid & M. United","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-23T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":4.0,"GolColNoTexto":"NO","GolColSiPunto":2.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":2.0,"LocalEmpateTexto":"LE","PuntoA":2.0,"PuntoB":3.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":6.0,"PuntoGol4":9.0,"PuntoGol_1":7.0,"PuntoGol_2":5.0,"PuntoGol_3":3.0,"PuntoGol_4":2.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (13, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":6}', NULL, N'{"EmpatePunto":4.0,"EmpateTexto":"E","EmpateVisitaPunto":3.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Villarreal & Juventus","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-22T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":6.0,"GolColNoTexto":"NO","GolColSiPunto":3.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":2.0,"LocalEmpateTexto":"LE","PuntoA":3.0,"PuntoB":4.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":6.0,"PuntoGol4":9.0,"PuntoGol_1":8.0,"PuntoGol_2":5.0,"PuntoGol_3":3.0,"PuntoGol_4":2.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (14, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":5}', NULL, N'{"EmpatePunto":5.0,"EmpateTexto":"E","EmpateVisitaPunto":3.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Chelsea & Lille","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-22T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":3.0,"GolColNoTexto":"NO","GolColSiPunto":6.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":2.0,"LocalEmpateTexto":"LE","PuntoA":2.0,"PuntoB":8.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":4.0,"PuntoGol4":6.0,"PuntoGol_1":15.0,"PuntoGol_2":9.0,"PuntoGol_3":7.0,"PuntoGol_4":4.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (15, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":4}', NULL, N'{"EmpatePunto":3.0,"EmpateTexto":"E","EmpateVisitaPunto":2.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Inter Milan & Liverpool","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-16T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":5.0,"GolColNoTexto":"NO","GolColSiPunto":3.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":3.0,"LocalEmpateTexto":"LE","PuntoA":3.0,"PuntoB":2.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":5.0,"PuntoGol4":7.0,"PuntoGol_1":10.0,"PuntoGol_2":7.0,"PuntoGol_3":5.0,"PuntoGol_4":3.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (16, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":3}', NULL, N'{"EmpatePunto":5.0,"EmpateTexto":"E","EmpateVisitaPunto":2.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"FC Salzburgo & B. Muchen","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-16T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":2.0,"GolColNoTexto":"NO","GolColSiPunto":5.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":5.0,"LocalEmpateTexto":"LE","PuntoA":8.0,"PuntoB":2.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":4.0,"PuntoGol4":6.0,"PuntoGol_1":25.0,"PuntoGol_2":17.0,"PuntoGol_3":12.0,"PuntoGol_4":8.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (17, N'Deportes', CAST(N'2022-02-04 08:28:31.503' AS DateTime), N'{"Id":2}', NULL, N'{"EmpatePunto":5.0,"EmpateTexto":"E","EmpateVisitaPunto":2.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Sport Lisboa & Manch City","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-15T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":2.0,"GolColNoTexto":"NO","GolColSiPunto":5.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":5.0,"LocalEmpateTexto":"LE","PuntoA":8.0,"PuntoB":2.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":4.0,"PuntoGol4":6.0,"PuntoGol_1":22.0,"PuntoGol_2":15.0,"PuntoGol_3":10.0,"PuntoGol_4":7.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (18, N'Deportes', CAST(N'2022-02-04 08:28:31.443' AS DateTime), N'{"Id":1}', NULL, N'{"EmpatePunto":4.0,"EmpateTexto":"E","EmpateVisitaPunto":3.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"PSG & Real Madrid","Estado":false,"EstadoJuego":0,"FechaHora":"2022-02-15T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":5.0,"GolColNoTexto":"NO","GolColSiPunto":2.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":2.0,"LocalEmpateTexto":"LE","PuntoA":2.0,"PuntoB":3.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":5.0,"PuntoGol4":6.0,"PuntoGol_1":15.0,"PuntoGol_2":10.0,"PuntoGol_3":7.0,"PuntoGol_4":4.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 14)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (19, N'MaestroDetalle', CAST(N'2022-02-04 21:54:47.087' AS DateTime), N'{"Id":1}', N'{"Valor":"00000000"}', N'{"Valor":"1"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (20, N'Usuario', CAST(N'2022-02-04 21:54:47.403' AS DateTime), N'{"Id":15}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"","CodigoReferencia":"0001","DNI":"74595366","Departamento":"LIMA","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-07-29T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"LIMA","Telefono":"974241001","UserName":"DAVID10"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (21, N'MaestroDetalle', CAST(N'2022-02-04 22:42:45.627' AS DateTime), N'{"Id":1}', N'{"Valor":"1"}', N'{"Valor":"2"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (22, N'MaestroDetalle', CAST(N'2022-02-04 22:44:27.543' AS DateTime), N'{"Id":1}', N'{"Valor":"2"}', N'{"Valor":"3"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (23, N'MaestroDetalle', CAST(N'2022-02-04 22:55:22.207' AS DateTime), N'{"Id":1}', N'{"Valor":"3"}', N'{"Valor":"4"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (24, N'MaestroDetalle', CAST(N'2022-02-04 23:03:04.020' AS DateTime), N'{"Id":1}', N'{"Valor":"4"}', N'{"Valor":"5"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (25, N'MaestroDetalle', CAST(N'2022-02-04 23:04:34.397' AS DateTime), N'{"Id":1}', N'{"Valor":"5"}', N'{"Valor":"6"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (26, N'UsuarioPunto', CAST(N'2022-02-04 23:04:39.647' AS DateTime), N'{"Id":1}', NULL, N'{"Estado":true,"Periodo":2,"PuntosAcumulados":null,"PuntosMembresia":50.0,"PuntosPerdidos":null,"PuntosRecarga":null,"UsuarioId":20}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (27, N'Usuario', CAST(N'2022-02-04 23:04:39.643' AS DateTime), N'{"Id":20}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":"000000006","DNI":"74595366","Departamento":"LIMA","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-07-29T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"Lima","Telefono":"974241001","UserName":"DAVID10"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (28, N'MaestroDetalle', CAST(N'2022-02-04 23:12:13.437' AS DateTime), N'{"Id":1}', N'{"Valor":"6"}', N'{"Valor":"7"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (29, N'UsuarioPunto', CAST(N'2022-02-04 23:12:17.127' AS DateTime), N'{"Id":2}', NULL, N'{"Estado":true,"Periodo":2,"PuntosAcumulados":null,"PuntosMembresia":50.0,"PuntosPerdidos":null,"PuntosRecarga":null,"UsuarioId":21}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (30, N'Usuario', CAST(N'2022-02-04 23:12:17.127' AS DateTime), N'{"Id":21}', NULL, N'{"Apellidos":"MORALES HUAMANI","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"07001","CodigoReferencia":"US000007","DNI":"74595366","Departamento":"LIMA","Email":"davidnh2992@gmail.com","Estado":true,"FechaNacimiento":"1995-07-12T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"DAVID","Provincia":"Lima","Telefono":"987456321","UserName":"DAVID10"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (31, N'MaestroDetalle', CAST(N'2022-02-05 00:47:56.427' AS DateTime), N'{"Id":1}', N'{"Valor":"7"}', N'{"Valor":"8"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (32, N'UsuarioPunto', CAST(N'2022-02-05 00:47:57.187' AS DateTime), N'{"Id":3}', NULL, N'{"Estado":true,"Periodo":2,"PuntosAcumulados":0.0,"PuntosMembresia":50.0,"PuntosPerdidos":0.0,"PuntosRecarga":0.0,"UsuarioId":22}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (33, N'Usuario', CAST(N'2022-02-05 00:47:57.180' AS DateTime), N'{"Id":22}', NULL, N'{"Apellidos":"BLAS","CiudadRecidencia":null,"Clave":"xujrOJyWltALTN3wveJNZA==","CodigoInvitacion":"","CodigoReferencia":"US000008","DNI":"32659874","Departamento":"LIMA","Email":"sblaslopez@gmail.com","Estado":true,"FechaNacimiento":"1998-06-11T05:00:00Z","ImagenOriginal":null,"KeyImagen":null,"Nombre":"SAUL","Provincia":"LIMA","Telefono":"987456321","UserName":"sblas10"}', NULL)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (34, N'Deportes', CAST(N'2022-02-05 01:34:20.750' AS DateTime), N'{"Id":10}', NULL, N'{"EmpatePunto":4.0,"EmpateTexto":"E","EmpateVisitaPunto":2.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"UTC & Boys","Estado":true,"EstadoJuego":0,"FechaHora":"2022-02-04T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":2.0,"GolColNoTexto":"NO","GolColSiPunto":5.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":5.0,"LocalEmpateTexto":"LE","PuntoA":1.8,"PuntoB":3.5,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":4.0,"PuntoGol4":6.0,"PuntoGol_1":22.0,"PuntoGol_2":15.0,"PuntoGol_3":10.0,"PuntoGol_4":7.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 22)
GO
INSERT [dbo].[Audits] ([Id], [TableName], [DateTime], [KeyValues], [OldValues], [NewValues], [UserId]) VALUES (35, N'Deportes', CAST(N'2022-02-05 01:34:20.750' AS DateTime), N'{"Id":9}', NULL, N'{"EmpatePunto":4.0,"EmpateTexto":"E","EmpateVisitaPunto":3.0,"EmpateVisitaTexto":"EV","EquipoA":"L","EquipoB":"V","EquiposReviales":"Alianza & A Grau","Estado":true,"EstadoJuego":0,"FechaHora":"2022-02-04T00:00:00","Gol1Text":"+0.5","Gol2Text":"+1.5","Gol3Text":"+2.5","Gol4Text":"+3.5","GolColNoPunto":5.0,"GolColNoTexto":"NO","GolColSiPunto":2.0,"GolColSiTexto":"SI","Gol_1Text":"-0.5","Gol_2Text":"-1.5","Gol_3Text":"-2.5","Gol_4Text":"-3.5","Hora":"15:00","LigaId":1,"LocalEmpatePunto":2.0,"LocalEmpateTexto":"LE","PuntoA":1.6,"PuntoB":8.0,"PuntoGol1":2.0,"PuntoGol2":3.0,"PuntoGol3":5.0,"PuntoGol4":6.0,"PuntoGol_1":15.0,"PuntoGol_2":10.0,"PuntoGol_3":7.0,"PuntoGol_4":4.0,"TotalCorners":0.0,"TotalGoles":0.0,"TotalTarjetas":0.0}', 22)
GO
SET IDENTITY_INSERT [dbo].[Audits] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoriaFutbol] ON 

GO
INSERT [dbo].[CategoriaFutbol] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Fútbol', N'Fútbol', 1)
GO
INSERT [dbo].[CategoriaFutbol] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (3, N'Baloncesto', N'Baloncesto', 1)
GO
INSERT [dbo].[CategoriaFutbol] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (4, N'Hockey', N'Hockey', 1)
GO
INSERT [dbo].[CategoriaFutbol] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (5, N'Béisbol', N'Béisbol', 1)
GO
INSERT [dbo].[CategoriaFutbol] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (6, N'Voleibol', N'Voleibol', 1)
GO
SET IDENTITY_INSERT [dbo].[CategoriaFutbol] OFF
GO
SET IDENTITY_INSERT [dbo].[ConfiguracionCorreo] ON 

GO
INSERT [dbo].[ConfiguracionCorreo] ([Id], [Nombre], [Descripcion], [Asunto], [Cuerpo], [Activo]) VALUES (1, N'EMAIL_USER_REGISTER', N'Correo de registro de usuario', N'CONFIRMACION DE USUARIO', N'
<table width="600" height="365" bgcolor="#FFFFFF" align="center" border="0" cellpadding="0" cellspacing="0">
    <tbody>
        <tr>
            <td rowspan="2" bgcolor="#ed600e" width="65" height="106" alt=""></td>
            <td bgcolor="#ed600e" width="470" height="53" alt=""></td>
            <td rowspan="2" bgcolor="#ed600e" width="65" height="106" alt=""></td>
        </tr>
        <tr>
            <td> <img
                    src="https://ci3.googleusercontent.com/proxy/BT-vj6sOVXv1yw5AZwkiW376MM_tO6ZwtoJkEvPiKGT6p2Fe9BHLUIE0fSz-cSOB8Y7kDC_pZxDVpgCImRUOMfvTMzu7hHeTu_DBIcZEqntk=s0-d-e1-ft#https://www.latinka.com.pe/latinka/mailing-sale/logo_tinka.gif"
                    width="470" height="53" alt="DONATO BET"
                    style="display:block;color:#5a5a5a;text-align:left;font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:18px"
                    class="CToWUd"></td>
        </tr>
        <tr>
            <td rowspan="6" bgcolor="#B5ADAF" width="65" height="283" alt=""></td>
            <td bgcolor="#ffffff" width="470" height="38" alt=""></td>
            <td rowspan="6" bgcolor="#B5ADAF" width="65" height="283" alt=""></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" width="470" height="44" alt=""
                style="color:#5a5a5a;text-align:center;font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:22px">
                <strong>¡Hola @Model.Nombre!</strong></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" width="470" height="33" alt=""
                style="color:#5a5a5a;text-align:center;font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:14px">
                Tu nombre de usuario es :</td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" width="470" height="43" align="center"
                style="display:block;color:#126639;text-align:center;font-family:Open Sans,Arial,Helvetica,sans-serif;font-size:22px">
                <strong>@Model.UserName</strong></td>
        </tr>
        <tr>
            <td>
                <div style="padding:10px 20px;font-size:14px">
                    <div style="display:flex;margin-bottom:10px; ">
                        <div style="width:40%;color:#969695">Codigo Referencia:</div>
                        <div style="width:40%">@Model.CodigoReferencia</div>
                    </div>
                    <div style="display:flex;margin-bottom:10px; ">
                        <div style="width:40%;color:#969695">Email:</div>
                        <div style="width:40%">@Model.Email</div>
                    </div>
                    <div style="display:flex;margin-bottom:10px; ">
                        <div style="width:40%;color:#969695">Celular:</div>
                        <div style="width:40%">@Model.Telefono</div>
                    </div>
                    <div style="display:flex;margin-bottom:10px; ">
                        <div style="width:40%;color:#969695">N° Documento:</div>
                        <div style="width:40%">@Model.DNI</div>
                    </div>
                </div>
                <div style="text-align: center;">
                    <a href="http://www.google.com" target="_blank">Click aqui para confirmar usuario ...</a>
                </div>
            </td>
        </tr>
      
        <tr>
            <td bgcolor="#ffffff" width="470" height="49" alt=""></td>
        </tr>
       
        <tr>
            <td colspan="3" bgcolor="#B5ADAF" width="600" height="117" alt=""></td>
        </tr>
    </tbody>
</table>
', 1)
GO
SET IDENTITY_INSERT [dbo].[ConfiguracionCorreo] OFF
GO
SET IDENTITY_INSERT [dbo].[Deportes] ON 

GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (1, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'PSG & Real Madrid', N'L', N'V', CAST(2.00 AS Decimal(7, 2)), CAST(3.00 AS Decimal(7, 2)), N'E', CAST(4.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(5.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(15.00 AS Decimal(7, 2)), N'-1.5', CAST(10.00 AS Decimal(7, 2)), N'-2.5', CAST(7.00 AS Decimal(7, 2)), N'-3.5', CAST(4.00 AS Decimal(7, 2)), N'LE', CAST(2.00 AS Decimal(7, 2)), N'EV', CAST(3.00 AS Decimal(7, 2)), N'SI', CAST(2.00 AS Decimal(7, 2)), N'NO', CAST(5.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (2, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Sport Lisboa & Manch City', N'L', N'V', CAST(8.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(7, 2)), N'E', CAST(5.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(4.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(22.00 AS Decimal(7, 2)), N'-1.5', CAST(15.00 AS Decimal(7, 2)), N'-2.5', CAST(10.00 AS Decimal(7, 2)), N'-3.5', CAST(7.00 AS Decimal(7, 2)), N'LE', CAST(5.00 AS Decimal(7, 2)), N'EV', CAST(2.00 AS Decimal(7, 2)), N'SI', CAST(5.00 AS Decimal(7, 2)), N'NO', CAST(2.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (3, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'FC Salzburgo & B. Muchen', N'L', N'V', CAST(8.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(7, 2)), N'E', CAST(5.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(4.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(25.00 AS Decimal(7, 2)), N'-1.5', CAST(17.00 AS Decimal(7, 2)), N'-2.5', CAST(12.00 AS Decimal(7, 2)), N'-3.5', CAST(8.00 AS Decimal(7, 2)), N'LE', CAST(5.00 AS Decimal(7, 2)), N'EV', CAST(2.00 AS Decimal(7, 2)), N'SI', CAST(5.00 AS Decimal(7, 2)), N'NO', CAST(2.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (4, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Inter Milan & Liverpool', N'L', N'V', CAST(3.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(7, 2)), N'E', CAST(3.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(5.00 AS Decimal(7, 2)), N'+3.5', CAST(7.00 AS Decimal(7, 2)), N'-0.5', CAST(10.00 AS Decimal(7, 2)), N'-1.5', CAST(7.00 AS Decimal(7, 2)), N'-2.5', CAST(5.00 AS Decimal(7, 2)), N'-3.5', CAST(3.00 AS Decimal(7, 2)), N'LE', CAST(3.00 AS Decimal(7, 2)), N'EV', CAST(2.00 AS Decimal(7, 2)), N'SI', CAST(3.00 AS Decimal(7, 2)), N'NO', CAST(5.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (5, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Chelsea & Lille', N'L', N'V', CAST(2.00 AS Decimal(7, 2)), CAST(8.00 AS Decimal(7, 2)), N'E', CAST(5.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(4.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(15.00 AS Decimal(7, 2)), N'-1.5', CAST(9.00 AS Decimal(7, 2)), N'-2.5', CAST(7.00 AS Decimal(7, 2)), N'-3.5', CAST(4.00 AS Decimal(7, 2)), N'LE', CAST(2.00 AS Decimal(7, 2)), N'EV', CAST(3.00 AS Decimal(7, 2)), N'SI', CAST(6.00 AS Decimal(7, 2)), N'NO', CAST(3.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (6, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Villarreal & Juventus', N'L', N'V', CAST(3.00 AS Decimal(7, 2)), CAST(4.00 AS Decimal(7, 2)), N'E', CAST(4.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(6.00 AS Decimal(7, 2)), N'+3.5', CAST(9.00 AS Decimal(7, 2)), N'-0.5', CAST(8.00 AS Decimal(7, 2)), N'-1.5', CAST(5.00 AS Decimal(7, 2)), N'-2.5', CAST(3.00 AS Decimal(7, 2)), N'-3.5', CAST(2.00 AS Decimal(7, 2)), N'LE', CAST(2.00 AS Decimal(7, 2)), N'EV', CAST(3.00 AS Decimal(7, 2)), N'SI', CAST(3.00 AS Decimal(7, 2)), N'NO', CAST(6.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (7, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Atle. Madrid & M. United', N'L', N'V', CAST(2.00 AS Decimal(7, 2)), CAST(3.00 AS Decimal(7, 2)), N'E', CAST(4.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(6.00 AS Decimal(7, 2)), N'+3.5', CAST(9.00 AS Decimal(7, 2)), N'-0.5', CAST(7.00 AS Decimal(7, 2)), N'-1.5', CAST(5.00 AS Decimal(7, 2)), N'-2.5', CAST(3.00 AS Decimal(7, 2)), N'-3.5', CAST(2.00 AS Decimal(7, 2)), N'LE', CAST(2.00 AS Decimal(7, 2)), N'EV', CAST(3.00 AS Decimal(7, 2)), N'SI', CAST(2.00 AS Decimal(7, 2)), N'NO', CAST(4.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (8, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Benfica & Ajax', N'L', N'V', CAST(3.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(7, 2)), N'E', CAST(4.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(4.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(10.00 AS Decimal(7, 2)), N'-1.5', CAST(7.00 AS Decimal(7, 2)), N'-2.5', CAST(5.00 AS Decimal(7, 2)), N'-3.5', CAST(2.00 AS Decimal(7, 2)), N'LE', CAST(3.00 AS Decimal(7, 2)), N'EV', CAST(2.00 AS Decimal(7, 2)), N'SI', CAST(2.00 AS Decimal(7, 2)), N'NO', CAST(6.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (9, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'Alianza & A Grau', N'L', N'V', CAST(1.60 AS Decimal(7, 2)), CAST(8.00 AS Decimal(7, 2)), N'E', CAST(4.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(5.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(15.00 AS Decimal(7, 2)), N'-1.5', CAST(10.00 AS Decimal(7, 2)), N'-2.5', CAST(7.00 AS Decimal(7, 2)), N'-3.5', CAST(4.00 AS Decimal(7, 2)), N'LE', CAST(2.00 AS Decimal(7, 2)), N'EV', CAST(3.00 AS Decimal(7, 2)), N'SI', CAST(2.00 AS Decimal(7, 2)), N'NO', CAST(5.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
INSERT [dbo].[Deportes] ([Id], [Hora], [FechaHora], [EquiposReviales], [EquipoA], [EquipoB], [PuntoA], [PuntoB], [EmpateTexto], [EmpatePunto], [Gol1Text], [PuntoGol1], [Gol2Text], [PuntoGol2], [Gol3Text], [PuntoGol3], [Gol4Text], [PuntoGol4], [Gol_1Text], [PuntoGol_1], [Gol_2Text], [PuntoGol_2], [Gol_3Text], [PuntoGol_3], [Gol_4Text], [PuntoGol_4], [LocalEmpateTexto], [LocalEmpatePunto], [EmpateVisitaTexto], [EmpateVisitaPunto], [GolColSiTexto], [GolColSiPunto], [GolColNoTexto], [GolColNoPunto], [EstadoJuego], [TotalCorners], [TotalTarjetas], [TotalGoles], [Estado], [LigaId]) VALUES (10, N'15:00', CAST(N'2022-02-07 18:03:03.103' AS DateTime), N'UTC & Boys', N'L', N'V', CAST(1.80 AS Decimal(7, 2)), CAST(3.50 AS Decimal(7, 2)), N'E', CAST(4.00 AS Decimal(7, 2)), N'+0.5', CAST(2.00 AS Decimal(7, 2)), N'+1.5', CAST(3.00 AS Decimal(7, 2)), N'+2.5', CAST(4.00 AS Decimal(7, 2)), N'+3.5', CAST(6.00 AS Decimal(7, 2)), N'-0.5', CAST(22.00 AS Decimal(7, 2)), N'-1.5', CAST(15.00 AS Decimal(7, 2)), N'-2.5', CAST(10.00 AS Decimal(7, 2)), N'-3.5', CAST(7.00 AS Decimal(7, 2)), N'LE', CAST(5.00 AS Decimal(7, 2)), N'EV', CAST(2.00 AS Decimal(7, 2)), N'SI', CAST(5.00 AS Decimal(7, 2)), N'NO', CAST(2.00 AS Decimal(7, 2)), 0, CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), CAST(0.00 AS Decimal(7, 2)), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Deportes] OFF
GO
SET IDENTITY_INSERT [dbo].[FutbolSubCagoria] ON 

GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (2, 2, N'Mundo', N'todos', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (3, 2, N'Europa', N'continente', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (4, 2, N'Americas', N'continente', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (5, 2, N'Inglaterra', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (6, 2, N'Portugal', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (7, 2, N'España', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (8, 2, N'Alemani', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (9, 2, N'Francia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (10, 2, N'Peru', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (11, 2, N'Italia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (12, 2, N'Turquia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (13, 2, N'Costa Rica', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (14, 2, N'Asia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (15, 2, N'Dinamarca', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (16, 2, N'Belgica', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (17, 2, N'Colombia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (18, 2, N'Brasil', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (19, 2, N'Paraguay', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (20, 2, N'Paises Bajos', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (21, 2, N'Estados Unidos', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (22, 2, N'Mexivo', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (23, 2, N'Austria', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (24, 2, N'Grecia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (25, 2, N'Republica Checa', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (26, 2, N'Paraguay', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (27, 2, N'Escocia', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (28, 2, N'Suiza', N'país', 1)
GO
INSERT [dbo].[FutbolSubCagoria] ([Id], [CategoriaFutbolId], [Nombre], [Descripcion], [Estado]) VALUES (29, 2, N'Nigeria', N'país', 1)
GO
SET IDENTITY_INSERT [dbo].[FutbolSubCagoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Ligas] ON 

GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (1, N'UEFA Champions League', N'Europa', 1, 3, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (2, N'UEFA Nations League, Europa', N'Europa', 1, 3, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (3, N'UEFA Europa League, Europa', N'Europa', 1, 3, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (4, N'UEFA Europa Conference League', N'Europa', 1, 3, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (5, N'Elim. Europa - QATAR 2.022', N'Europa', 1, 3, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (6, N'Copa Sudamericana', N'America', 1, 4, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (7, N'Copa Libertadores', N'America', 1, 4, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (8, N'Elim. CONMEBOL - QATAR 2.022', N'America', 1, 4, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (9, N'Elim. CONCACAF - QATAR 2022', N'America', 1, 4, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (10, N'Premier League', N'Inglaterra', 1, 5, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (11, N'La Liga', N'España', 1, 7, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (12, N'Bundesliga', N'Alemania', 1, 8, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (13, N'Ligue 1', N'Francia', 1, 9, 1)
GO
INSERT [dbo].[Ligas] ([Id], [Nombre], [Descripcion], [Estado], [FutbolSubCagoriaId], [Destacado]) VALUES (14, N'Serie A', N'Italia', 1, 11, 1)
GO
SET IDENTITY_INSERT [dbo].[Ligas] OFF
GO
SET IDENTITY_INSERT [dbo].[Maestro] ON 

GO
INSERT [dbo].[Maestro] ([Id], [Clave], [Descripcion], [Activo]) VALUES (1, N'REFERENCE_CODE_USER', N'codigo referencia usuario', 1)
GO
SET IDENTITY_INSERT [dbo].[Maestro] OFF
GO
SET IDENTITY_INSERT [dbo].[MaestroDetalle] ON 

GO
INSERT [dbo].[MaestroDetalle] ([Id], [Clave], [Valor], [Descripcion], [Activo], [IdMaestro]) VALUES (1, N'0', N'8', N'codigo referencia usuario', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[MaestroDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [DNI], [Telefono], [Email], [UserName], [Clave], [ImagenOriginal], [KeyImagen], [CodigoReferencia], [CodigoInvitacion], [Estado], [Departamento], [Provincia], [CiudadRecidencia], [FechaNacimiento]) VALUES (21, N'DAVID', N'MORALES HUAMANI', N'74595366', N'987456321', N'davidnh2992@gmail.com', N'DAVID10', N'xujrOJyWltALTN3wveJNZA==', NULL, NULL, N'US000007    ', N'07001       ', 1, N'LIMA', N'Lima', NULL, CAST(N'1995-07-12 05:00:00.000' AS DateTime))
GO
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [DNI], [Telefono], [Email], [UserName], [Clave], [ImagenOriginal], [KeyImagen], [CodigoReferencia], [CodigoInvitacion], [Estado], [Departamento], [Provincia], [CiudadRecidencia], [FechaNacimiento]) VALUES (22, N'SAUL', N'BLAS', N'32659874', N'987456321', N'sblaslopez@gmail.com', N'sblas10', N'xujrOJyWltALTN3wveJNZA==', NULL, NULL, N'US000008    ', N'            ', 1, N'LIMA', N'LIMA', NULL, CAST(N'1998-06-11 05:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioPunto] ON 

GO
INSERT [dbo].[UsuarioPunto] ([Id], [Periodo], [UsuarioId], [PuntosMembresia], [PuntosRecarga], [PuntosPerdidos], [PuntosAcumulados], [Estado]) VALUES (2, 2, 21, CAST(50.00 AS Decimal(18, 2)), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[UsuarioPunto] ([Id], [Periodo], [UsuarioId], [PuntosMembresia], [PuntosRecarga], [PuntosPerdidos], [PuntosAcumulados], [Estado]) VALUES (3, 2, 22, CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[UsuarioPunto] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Configur__75E3EFCF4A1E50CD]    Script Date: 8/02/2022 11:45:27 ******/
ALTER TABLE [dbo].[ConfiguracionCorreo] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Maestro__E8181E11C29E6B15]    Script Date: 8/02/2022 11:45:27 ******/
ALTER TABLE [dbo].[Maestro] ADD UNIQUE NONCLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Clave_IdMaestro]    Script Date: 8/02/2022 11:45:27 ******/
ALTER TABLE [dbo].[MaestroDetalle] ADD  CONSTRAINT [UQ__Clave_IdMaestro] UNIQUE NONCLUSTERED 
(
	[Clave] ASC,
	[IdMaestro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aciertos]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[DeporteResultados]  WITH CHECK ADD FOREIGN KEY([DeporteId])
REFERENCES [dbo].[Deportes] ([Id])
GO
ALTER TABLE [dbo].[Deportes]  WITH CHECK ADD FOREIGN KEY([LigaId])
REFERENCES [dbo].[Ligas] ([Id])
GO
ALTER TABLE [dbo].[DetalleAciertos]  WITH CHECK ADD FOREIGN KEY([DeporteId])
REFERENCES [dbo].[Deportes] ([Id])
GO
ALTER TABLE [dbo].[FutbolSubCagoria]  WITH CHECK ADD FOREIGN KEY([CategoriaFutbolId])
REFERENCES [dbo].[CategoriaFutbol] ([Id])
GO
ALTER TABLE [dbo].[Ligas]  WITH CHECK ADD FOREIGN KEY([FutbolSubCagoriaId])
REFERENCES [dbo].[FutbolSubCagoria] ([Id])
GO
ALTER TABLE [dbo].[MaestroDetalle]  WITH CHECK ADD  CONSTRAINT [fk_MaestroDetalle_IdMaestro] FOREIGN KEY([IdMaestro])
REFERENCES [dbo].[Maestro] ([Id])
GO
ALTER TABLE [dbo].[MaestroDetalle] CHECK CONSTRAINT [fk_MaestroDetalle_IdMaestro]
GO
ALTER TABLE [dbo].[Membresia]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[PremiosAuditoria]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPunto]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
