USE [master]
GO

/****** Object:  Database [DemoAlquilerGameWinForm]    Script Date: 02/27/2018 00:52:21 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'DemoAlquilerGameWinForm')
DROP DATABASE [DemoAlquilerGameWinForm]
GO

USE [master]
GO

/****** Object:  Database [DemoAlquilerGameWinForm]    Script Date: 02/27/2018 00:52:21 ******/
CREATE DATABASE [DemoAlquilerGameWinForm] ON  PRIMARY 
( NAME = N'DemoAlquilerGameWinForm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\DemoAlquilerGameWinForm.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DemoAlquilerGameWinForm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\DemoAlquilerGameWinForm_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoAlquilerGameWinForm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET ARITHABORT OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET  ENABLE_BROKER 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET  READ_WRITE 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET RECOVERY FULL 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET  MULTI_USER 
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DemoAlquilerGameWinForm] SET DB_CHAINING OFF 
GO

USE [DemoAlquilerGameWinForm]
GO

/****** Object:  Table [dbo].[cliente]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Telefono] [varchar](255) NULL,
	[Correo] [varchar](255) NULL,
	[Direccion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[descuento]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[descuento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
	[PorcentajeDescuento] [float] NULL,
	[Estatus] [int] NULL DEFAULT (0),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[precio]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[precio](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
	[PrecioUnitario] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[marca]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[marca](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[modelo]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[modelo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[categoria]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](255) NULL,
	[Descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[producto]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](255) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[IDMarca] [int] NOT NULL,
	[IDModelo] [int] NOT NULL,
	[IDCategoria] [int] NOT NULL,
	CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([IDMarca]) REFERENCES [dbo].[marca] ([ID]),
	CONSTRAINT [FK_Producto_Modelo] FOREIGN KEY([IDModelo]) REFERENCES [dbo].[modelo] ([ID]),
	CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IDCategoria]) REFERENCES [dbo].[categoria] ([ID]),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[alquiler]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alquiler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NOT NULL,
	[TiempoHora] [varchar](255) NULL,
	[TiempoDia] [varchar](255) NULL,
	[TiempoSemana] [varchar](255) NULL,
	[PrecioEstimado] [float] NULL,
	[Estatus] [int] NOT NULL DEFAULT (0),
	CONSTRAINT [FK_Alquiler_Cliente] FOREIGN KEY([IDCliente]) REFERENCES [dbo].[cliente] ([ID]),
	CONSTRAINT [FK_Alquiler_Producto] FOREIGN KEY([IDProducto]) REFERENCES [dbo].[producto] ([ID]),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PagoCab]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pagoCab](
	[ID] [int] IDENTITY(1,1) NOT NULL,	
	[IDCliente] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,	
	[MontoExento] [float] NULL,
	[Descuento] [float] NULL,
	[MontoTotal] [float] NULL,
	[Estatus] [int] NOT NULL DEFAULT (0),
	CONSTRAINT [FK_PagoCab_Cliente] FOREIGN KEY([IDCliente]) REFERENCES [dbo].[cliente] ([ID]),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PagoDet]    Script Date: 10/25/2016 15:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pagoDet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDPagoCab] [int] NOT NULL,
	[IDAlquiler] [int] NOT NULL,	
	[PrecioUnitario] [float] NULL,
	[Descuento] [float] NULL,
	[PrecioTotal] [float] NULL,
	CONSTRAINT [FK_PagoDet_Alquiler] FOREIGN KEY([IDAlquiler]) REFERENCES [dbo].[alquiler] ([ID]),
	CONSTRAINT [FK_PagoDet_PagoCab] FOREIGN KEY([IDPagoCab]) REFERENCES [dbo].[pagoCab] ([ID]),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  View [dbo].[vw_cantidad_alquiler_por_pagar]    Script Date: 03/04/2018 20:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_producto_descripcion]
AS
SELECT     dbo.producto.ID, dbo.producto.Codigo, dbo.producto.Descripcion AS Producto, dbo.marca.Descripcion AS Marca, dbo.modelo.Descripcion AS Modelo, 
                      dbo.categoria.Descripcion AS Categoria
FROM         dbo.producto INNER JOIN
                      dbo.categoria ON dbo.producto.IDCategoria = dbo.categoria.ID INNER JOIN
                      dbo.marca ON dbo.producto.IDMarca = dbo.marca.ID INNER JOIN
                      dbo.modelo ON dbo.producto.IDModelo = dbo.modelo.ID
GO

/****** Object:  View [dbo].[vw_cantidad_alquiler_por_pagar]    Script Date: 03/04/2018 20:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_cantidad_alquiler_por_pagar]
AS
SELECT     dbo.alquiler.IDCliente, dbo.cliente.Nombre, dbo.cliente.Telefono, dbo.cliente.Correo, dbo.cliente.Direccion, COUNT(*) AS NumAlquiler, 1 AS Estatus
FROM         dbo.alquiler INNER JOIN
                      dbo.cliente ON dbo.alquiler.IDCliente = dbo.cliente.ID
WHERE     (dbo.alquiler.Estatus = 1)
GROUP BY dbo.alquiler.IDCliente, dbo.cliente.Nombre, dbo.cliente.Telefono, dbo.cliente.Correo, dbo.cliente.Direccion
HAVING      (COUNT(dbo.alquiler.IDCliente) >= 1)
GO

/****** Object:  View [dbo].[vw_cantidad_alquiler_pagado]    Script Date: 03/06/2018 01:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_cantidad_alquiler_pagado]
AS
SELECT     dbo.alquiler.IDCliente, dbo.cliente.Nombre, dbo.cliente.Telefono, dbo.cliente.Correo, dbo.cliente.Direccion, COUNT(*) AS NumAlquiler, dbo.pagoCab.Fecha, 
                      dbo.pagoCab.MontoExento, dbo.pagoCab.Descuento, dbo.pagoCab.MontoTotal, dbo.pagoCab.Estatus
FROM         dbo.alquiler INNER JOIN
                      dbo.cliente ON dbo.alquiler.IDCliente = dbo.cliente.ID INNER JOIN
                      dbo.pagoCab ON dbo.cliente.ID = dbo.pagoCab.IDCliente
WHERE     (dbo.alquiler.Estatus = 2)
GROUP BY dbo.alquiler.IDCliente, dbo.cliente.Nombre, dbo.cliente.Telefono, dbo.cliente.Correo, dbo.cliente.Direccion, dbo.pagoCab.Fecha, dbo.pagoCab.MontoExento, 
                      dbo.pagoCab.Descuento, dbo.pagoCab.MontoTotal, dbo.pagoCab.Estatus
HAVING      (COUNT(dbo.alquiler.IDCliente) >= 1)
GO

/****** Object:  View [dbo].[vw_alquiler_por_pagar]    Script Date: 03/04/2018 19:01:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_alquiler_por_pagar]
AS
SELECT     dbo.alquiler.ID, dbo.cliente.Nombre, dbo.cliente.Telefono, dbo.cliente.Correo, dbo.producto.Descripcion AS [Producto], dbo.alquiler.FechaDesde, 
                      dbo.alquiler.FechaHasta, dbo.alquiler.TiempoHora, dbo.alquiler.TiempoDia, dbo.alquiler.TiempoSemana, dbo.alquiler.PrecioEstimado, 
                      dbo.alquiler.Estatus
FROM         dbo.alquiler INNER JOIN
                      dbo.cliente ON dbo.alquiler.IDCliente = dbo.cliente.ID INNER JOIN
                      dbo.producto ON dbo.alquiler.IDProducto = dbo.producto.ID
WHERE     (dbo.alquiler.Estatus = 1)
GO

/****** Object:  View [dbo].[vw_alquiler_pagado]    Script Date: 03/04/2018 19:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_alquiler_pagado]
AS
SELECT     dbo.alquiler.ID, dbo.cliente.Nombre, dbo.cliente.Telefono, dbo.cliente.Correo, dbo.producto.Descripcion AS [Producto], dbo.alquiler.FechaDesde, 
                      dbo.alquiler.FechaHasta, dbo.alquiler.TiempoHora, dbo.alquiler.TiempoDia, dbo.alquiler.TiempoSemana, dbo.alquiler.PrecioEstimado, 
                      dbo.pagoCab.MontoExento, dbo.pagoCab.Descuento, dbo.pagoCab.MontoTotal, dbo.alquiler.Estatus
FROM         dbo.alquiler INNER JOIN
                      dbo.producto ON dbo.alquiler.IDProducto = dbo.producto.ID INNER JOIN
                      dbo.cliente ON dbo.alquiler.IDCliente = dbo.cliente.ID INNER JOIN
                      dbo.pagoCab ON dbo.cliente.ID = dbo.pagoCab.IDCliente
WHERE     (dbo.alquiler.Estatus = 2)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCCLIENTE]    Script Date: 02/23/2018 16:11:21 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCCLIENTE]
( 
  @VNOMBRE AS VARCHAR(100), @VTELEFONO AS VARCHAR(50), @VCORREO AS VARCHAR(200), @VDIRECCION AS VARCHAR(200)
 )
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

  IF EXISTS (
              SELECT *
              FROM [DemoAlquilerGameWinForm].[dbo].[cliente] WITH (NOLOCK)
              WHERE [Correo] = @VCORREO
            )
    BEGIN
    
      SET @ERRORMESSAGE = 'El correo que esta intentando registrar ya se encuentra asignado a otro cliente'
      SET @ERRORSEVERITY = 16 
      SET @ERRORSTATE = 1     
      GOTO ERROR
    
    END
    
  ELSE
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[cliente]
          (Nombre, Telefono, Correo, Direccion)
        VALUES
          (@VNOMBRE, @VTELEFONO, @VCORREO, @VDIRECCION)
      
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODCLIENTE]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODCLIENTE]
( 
  @ICLIENTE AS INT, @VNOMBRE AS VARCHAR(100), @VTELEFONO AS VARCHAR(50), @VCORREO AS VARCHAR(200), @VDIRECCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET A1.Nombre = @VNOMBRE,
          A1.Telefono = @VTELEFONO,
          A1.Correo = @VCORREO, 
          A1.Direccion = @VDIRECCION
      FROM [DemoAlquilerGameWinForm].[dbo].[cliente] A1
      WHERE A1.ID = @ICLIENTE
    
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELICLIENTE]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELICLIENTE]
( 
  @ICLIENTE AS INT, @VNOMBRE AS VARCHAR(100), @VTELEFONO AS VARCHAR(50), @VCORREO AS VARCHAR(200), @VDIRECCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] WITH (NOLOCK)          
              WHERE [IDCliente] = @ICLIENTE        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El cliente que esta intentando eliminar ya se encuentra en uso en otra tabla.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[cliente] WHERE [ID] = @ICLIENTE  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCDESCUENTO]    Script Date: 02/23/2018 17:20:56 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCDESCUENTO]
(           
  @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @FPORCENTAJEDESCUENTO AS FLOAT, @IESTATUS AS INT
)
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WITH (NOLOCK)          
              WHERE [Codigo] = @VCODIGO
            )
    BEGIN          
            
      SET @ERRORMESSAGE = 'El codigo del descuento que esta intentando registrar ya se encuentra en uso'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[descuento]
          (Codigo, Descripcion, PorcentajeDescuento, Estatus)
        VALUES
          (@VCODIGO, @VDESCRIPCION, @FPORCENTAJEDESCUENTO, @IESTATUS)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODDESCUENTO]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODDESCUENTO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @FPORCENTAJEDESCUENTO AS FLOAT, @IESTATUS AS INT
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET	A1.Codigo = @VCODIGO,
			A1.Descripcion = @VDESCRIPCION,
			A1.PorcentajeDescuento = @FPORCENTAJEDESCUENTO,
			A1.Estatus = @IESTATUS
      FROM [DemoAlquilerGameWinForm].[dbo].[descuento] A1
      WHERE A1.ID = @IID
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELIDESCUENTO]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELIDESCUENTO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @FPORCENTAJEDESCUENTO AS FLOAT, @IESTATUS AS INT
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WITH (NOLOCK) WHERE [ID] = @IID          
              AND ([Descripcion] LIKE '%Cabecera%' OR [Descripcion] LIKE '%Linea%') 
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'Ningun descuento de Cabecera o de Linea puede ser eliminado.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WHERE [ID] = @IID  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCPRECIO]    Script Date: 02/23/2018 17:20:56 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCPRECIO]
(           
  @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @FPRECIO AS FLOAT
)
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[precio] WITH (NOLOCK)          
              WHERE [Codigo] = @VCODIGO
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El codigo del precio que esta intentando registrar ya se encuentra en uso'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[precio]
          (Codigo, Descripcion, PrecioUnitario)
        VALUES
          (@VCODIGO, @VDESCRIPCION, @FPRECIO)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODDPRECIO]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODPRECIO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @FPRECIO AS FLOAT
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET	A1.Codigo = @VCODIGO,
			A1.Descripcion = @VDESCRIPCION,
			A1.PrecioUnitario = @FPRECIO
      FROM [DemoAlquilerGameWinForm].[dbo].[precio] A1
      WHERE A1.ID = @IID
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELIPRECIO]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELIPRECIO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @FPRECIO AS FLOAT
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[precio] WITH (NOLOCK) WHERE [ID] = @IID  
              AND ([Descripcion] LIKE '%Hora%' OR [Descripcion] LIKE '%Dia%' OR [Descripcion] LIKE '%Semana%') 
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'Ningun precio por hora, dia o semana puede ser eliminado.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [ID] = @IID  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCMARCA]    Script Date: 02/23/2018 17:20:56 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCMARCA]
(           
  @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[marca] WITH (NOLOCK)          
              WHERE [Codigo] = @VCODIGO        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El codigo de la marca del producto que esta intentando registrar ya se encuentra en uso'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[marca]
          (Codigo, Descripcion)
        VALUES
          (@VCODIGO, @VDESCRIPCION)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODMARCA]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODMARCA]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET	A1.Codigo = @VCODIGO,
			A1.Descripcion = @VDESCRIPCION
      FROM [DemoAlquilerGameWinForm].[dbo].[marca] A1
      WHERE A1.ID = @IID
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELIMARCA]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELIMARCA]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[producto] WITH (NOLOCK)          
              WHERE [IDMarca] = @IID        
            )          
    BEGIN
            
      SET @ERRORMESSAGE = 'La marca del producto que esta intentando eliminar ya se encuentra en uso en otra tabla.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[marca] WHERE [ID] = @IID  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCMODELO]    Script Date: 02/23/2018 17:20:56 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCMODELO]
(           
  @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[modelo] WITH (NOLOCK)          
              WHERE [Codigo] = @VCODIGO        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El codigo del modelo del producto que esta intentando registrar ya se encuentra en uso'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[modelo]
          (Codigo, Descripcion)
        VALUES
          (@VCODIGO, @VDESCRIPCION)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODMODELO]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODMODELO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET	A1.Codigo = @VCODIGO,
			A1.Descripcion = @VDESCRIPCION
      FROM [DemoAlquilerGameWinForm].[dbo].[modelo] A1
      WHERE A1.ID = @IID
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELIMODELO]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELIMODELO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[producto] WITH (NOLOCK)          
              WHERE [IDModelo] = @IID        
            )          
    BEGIN
            
      SET @ERRORMESSAGE = 'El modelo del producto que esta intentando eliminar ya se encuentra en uso en otra tabla.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[modelo] WHERE [ID] = @IID  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCCATEGORIA]    Script Date: 02/23/2018 17:20:56 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCCATEGORIA]
(           
  @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[categoria] WITH (NOLOCK)          
              WHERE [Codigo] = @VCODIGO        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El codigo de la categoria del producto que esta intentando registrar ya se encuentra en uso'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[categoria]
          (Codigo, Descripcion)
        VALUES
          (@VCODIGO, @VDESCRIPCION)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODCATEGORIA]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODCATEGORIA]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET	A1.Codigo = @VCODIGO,
			A1.Descripcion = @VDESCRIPCION
      FROM [DemoAlquilerGameWinForm].[dbo].[categoria] A1
      WHERE A1.ID = @IID
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELICATEGORIA]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELICATEGORIA]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[producto] WITH (NOLOCK)          
              WHERE [IDCategoria] = @IID        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El categoria del producto que esta intentando eliminar ya se encuentra en uso en otra tabla.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[categoria] WHERE [ID] = @IID  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCPRODUCTO]    Script Date: 02/23/2018 17:20:56 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCPRODUCTO]
(           
  @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @IMARCA AS INT, @IMODELO AS INT, @ICATEGORIA AS INT
)          
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoAlquilerGameWinForm].[dbo].[producto]
          (Codigo, Descripcion, IDMarca, IDModelo, IDCategoria)
        VALUES
          (@VCODIGO, @VDESCRIPCION, @IMARCA, @IMODELO, @ICATEGORIA)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODPRODUCTO]    Script Date: 02/23/2018 16:20:47 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODPRODUCTO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @IMARCA AS INT, @IMODELO AS INT, @ICATEGORIA AS INT
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET	A1.Codigo = @VCODIGO,
			A1.Descripcion = @VDESCRIPCION, 
			A1.IDMarca = @IMARCA, 
			A1.IDModelo = @IMODELO, 
			A1.IDCategoria = @ICATEGORIA 
      FROM [DemoAlquilerGameWinForm].[dbo].[producto] A1
      WHERE A1.ID = @IID
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_ELIPRODUCTO]    Script Date: 03/03/2018 01:56:59 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_ELIPRODUCTO]
( 
  @IID AS INT, @VCODIGO AS VARCHAR(200), @VDESCRIPCION AS VARCHAR(200), @IMARCA AS INT, @IMODELO AS INT, @ICATEGORIA AS INT
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] WITH (NOLOCK)          
              WHERE [IDProducto] = @IID        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El producto que esta intentando eliminar ya se encuentra en uso en otra tabla.'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        DELETE FROM [DemoAlquilerGameWinForm].[dbo].[producto] WHERE [ID] = @IID  
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCALQUILER]    Script Date: 02/23/2018 17:50:05 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCALQUILER] 
(   
  @ICLIENTE AS INT, @IPRODUCTO AS INT, @DFECHADESDE AS DATETIME, 
  @DFECHAHASTA AS DATETIME, @VTIEMPOHOR AS VARCHAR(100)=NULL, @VTIEMPODIA AS VARCHAR(100)=NULL, 
  @VTIEMPOSEM AS VARCHAR(100)=NULL, @IESTATUS INT = 0
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @ITIEMPOHOR INT, @ITIEMPODIA INT, @ITIEMPOSEM INT
DECLARE @NTIEMPO NUMERIC(19,2), @NTIEMPOHOR NUMERIC(19,2), @NTIEMPODIA NUMERIC(19,2), @NTIEMPOSEM NUMERIC(19,2)
DECLARE @NPRECIO NUMERIC(19,2), @NPRECIOHOR NUMERIC(19,2), @NPRECIODIA NUMERIC(19,2), @NPRECIOSEM NUMERIC(19,2)

BEGIN TRY
  
    BEGIN  
      
      BEGIN TRAN
		
		--SE OBTIENE EL TIEMPO EN HORA DE LA DIFERENCIA ENTRE LAS 2 FECHAS
		SET @ITIEMPOHOR = DATEDIFF(HOUR, @DFECHADESDE,@DFECHAHASTA) - CASE WHEN DATEADD(HOUR, DATEDIFF(HOUR, @DFECHADESDE, @DFECHAHASTA), @DFECHADESDE) > @DFECHAHASTA THEN 1 ELSE 0 END
		--SE OBTIENE EL TIEMPO EN DIA DE LA DIFERENCIA ENTRE LAS 2 FECHAS
		SET @ITIEMPODIA = DATEDIFF(DAY, @DFECHADESDE,@DFECHAHASTA) - CASE WHEN DATEADD(DAY, DATEDIFF(DAY, @DFECHADESDE, @DFECHAHASTA), @DFECHADESDE) > @DFECHAHASTA THEN 1 ELSE 0 END
		--SE OBTIENE EL TIEMPO EN SEMANA DE LA DIFERENCIA ENTRE LAS 2 FECHAS
		SET @ITIEMPOSEM = DATEDIFF(WEEK, @DFECHADESDE,@DFECHAHASTA) - CASE WHEN DATEADD(WEEK, DATEDIFF(WEEK, @DFECHADESDE, @DFECHAHASTA), @DFECHADESDE) > @DFECHAHASTA THEN 1 ELSE 0 END
		
		--SE OBTIENE EL TIEMPO EN DIA DIVIDIENDO POR 24 HRS
		SET @NTIEMPO = @ITIEMPOHOR / 24.00 
		
		--SE HACE LA BIFURCACION PARA OBTENER EL VALOR EN HORA-DIA-SEMANA
		IF @NTIEMPO >= 1
			BEGIN
				SET @NTIEMPOHOR = @NTIEMPO - @ITIEMPODIA
				SET @NTIEMPOHOR = @NTIEMPOHOR * 24.00
				SET @NTIEMPO = @ITIEMPODIA / 7.00

				IF @NTIEMPO >= 1
					BEGIN
						SET @NTIEMPODIA = @NTIEMPO - @ITIEMPOSEM
						SET @NTIEMPODIA = @NTIEMPODIA * 7.00
						SET @NTIEMPOSEM = @ITIEMPOSEM
						SET @NTIEMPOHOR = ROUND(@NTIEMPOHOR, 0)
					END
				ELSE
					BEGIN
						SET @NTIEMPOSEM = @NTIEMPO
						SET @NTIEMPODIA = @ITIEMPODIA
						SET @NTIEMPOHOR = ROUND(@NTIEMPOHOR, 0)
					END
			END
		ELSE
			BEGIN
				SET @NTIEMPOHOR = @ITIEMPOHOR
				SET @NTIEMPODIA = @ITIEMPODIA
				SET @NTIEMPOSEM = @ITIEMPOSEM
			END
			
		--SE REDONDEA HACIA ARRIBA EL VALOR DE TIEMPO HORA	
		SET @VTIEMPOHOR = CASE WHEN @NTIEMPOHOR > 24 THEN ROUND(@NTIEMPOHOR, 0) ELSE @NTIEMPOHOR END
		--SE REDONDEA HACIA ARRIBA EL VALOR DE TIEMPO DIA
		SET @VTIEMPODIA = ROUND(@NTIEMPODIA, 0)
		--SE REDONDEA HACIA ARRIBA EL VALOR DE TIEMPO SEMANA
		SET @VTIEMPOSEM = CASE WHEN @NTIEMPOSEM >= 1 THEN ROUND(@NTIEMPOSEM, 0) ELSE @ITIEMPOSEM END
		
		--SE OBTIENE EL PRECIO DEL ALQILER POR HORA
		SET @NPRECIOHOR = (SELECT TOP 1 [PrecioUnitario] FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [Descripcion] LIKE '%Hora%') * 1.00
		--SE OBTIENE EL PRECIO DEL ALQILER POR DIA
		SET @NPRECIODIA = (SELECT TOP 1 [PrecioUnitario] FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [Descripcion] LIKE '%Dia%') * 1.00
		--SE OBTIENE EL PRECIO DEL ALQILER POR SEMANA
		SET @NPRECIOSEM = (SELECT TOP 1 [PrecioUnitario] FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [Descripcion] LIKE '%Semana%') * 1.00
		
		SET @NPRECIOHOR = CAST(@VTIEMPOHOR AS NUMERIC(19,2)) * @NPRECIOHOR * 1.00
		SET @NPRECIODIA = CAST(@VTIEMPODIA AS NUMERIC(19,2)) * @NPRECIODIA * 1.00
		SET @NPRECIOSEM = CAST(@VTIEMPOSEM AS NUMERIC(19,2)) * @NPRECIOSEM * 1.00
		
		--SE CALCULA EL PRECIO ESTIMADO DEL ALQUILER
		SET @NPRECIO = CAST((@NPRECIOHOR + @NPRECIODIA + @NPRECIOSEM) AS NUMERIC(19,2)) * 1.00
		
		--EL ESTATUS DEL ALQUILER ES '0' - ALQUILER PROPUESTO
		SET @IESTATUS = 0
		
		--SE INCLUYE EL ALQUILER
		INSERT INTO [DemoAlquilerGameWinForm].[dbo].[alquiler]
          (IDCliente, IDProducto, FechaDesde, FechaHasta, TiempoHora, TiempoDia, TiempoSemana, PrecioEstimado, Estatus)
        VALUES  
          (@ICLIENTE, @IPRODUCTO, @DFECHADESDE, @DFECHAHASTA, @VTIEMPOHOR, @VTIEMPODIA, @VTIEMPOSEM, @NPRECIO, @IESTATUS) 
        
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODALQUILER]    Script Date: 02/23/2018 17:50:05 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODALQUILER]
(   
  @IID AS INT, @ICLIENTE AS INT, @IPRODUCTO AS INT, @DFECHADESDE AS DATETIME, 
  @DFECHAHASTA AS DATETIME, @VTIEMPOHOR AS VARCHAR(100)=NULL, @VTIEMPODIA AS VARCHAR(100)=NULL, 
  @VTIEMPOSEM AS VARCHAR(100)=NULL, @IESTATUS INT = 1
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @ITIEMPOHOR INT, @ITIEMPODIA INT, @ITIEMPOSEM INT
DECLARE @NTIEMPO NUMERIC(19,2), @NTIEMPOHOR NUMERIC(19,2), @NTIEMPODIA NUMERIC(19,2), @NTIEMPOSEM NUMERIC(19,2)
DECLARE @NPRECIO NUMERIC(19,2), @NPRECIOHOR NUMERIC(19,2), @NPRECIODIA NUMERIC(19,2), @NPRECIOSEM NUMERIC(19,2)

BEGIN TRY
  
    BEGIN  
      
      BEGIN TRAN
		
		--SE OBTIENE EL TIEMPO EN HORA DE LA DIFERENCIA ENTRE LAS 2 FECHAS
		SET @ITIEMPOHOR = DATEDIFF(HOUR, @DFECHADESDE,@DFECHAHASTA) - CASE WHEN DATEADD(HOUR, DATEDIFF(HOUR, @DFECHADESDE, @DFECHAHASTA), @DFECHADESDE) > @DFECHAHASTA THEN 1 ELSE 0 END
		--SE OBTIENE EL TIEMPO EN DIA DE LA DIFERENCIA ENTRE LAS 2 FECHAS
		SET @ITIEMPODIA = DATEDIFF(DAY, @DFECHADESDE,@DFECHAHASTA) - CASE WHEN DATEADD(DAY, DATEDIFF(DAY, @DFECHADESDE, @DFECHAHASTA), @DFECHADESDE) > @DFECHAHASTA THEN 1 ELSE 0 END
		--SE OBTIENE EL TIEMPO EN SEMANA DE LA DIFERENCIA ENTRE LAS 2 FECHAS
		SET @ITIEMPOSEM = DATEDIFF(WEEK, @DFECHADESDE,@DFECHAHASTA) - CASE WHEN DATEADD(WEEK, DATEDIFF(WEEK, @DFECHADESDE, @DFECHAHASTA), @DFECHADESDE) > @DFECHAHASTA THEN 1 ELSE 0 END
		
		--SE OBTIENE EL TIEMPO EN DIA DIVIDIENDO POR 24 HRS
		SET @NTIEMPO = @ITIEMPOHOR / 24.00 
		
		--SE HACE LA BIFURCACION PARA OBTENER EL VALOR EN HORA-DIA-SEMANA
		IF @NTIEMPO >= 1
			BEGIN
				SET @NTIEMPOHOR = @NTIEMPO - @ITIEMPODIA
				SET @NTIEMPOHOR = @NTIEMPOHOR * 24.00
				SET @NTIEMPO = @ITIEMPODIA / 7.00

				IF @NTIEMPO >= 1
					BEGIN
						SET @NTIEMPODIA = @NTIEMPO - @ITIEMPOSEM
						SET @NTIEMPODIA = @NTIEMPODIA * 7.00
						SET @NTIEMPOSEM = @ITIEMPOSEM
						SET @NTIEMPOHOR = ROUND(@NTIEMPOHOR, 0)
					END
				ELSE
					BEGIN
						SET @NTIEMPOSEM = @NTIEMPO
						SET @NTIEMPODIA = @ITIEMPODIA
						SET @NTIEMPOHOR = ROUND(@NTIEMPOHOR, 0)
					END
			END
		ELSE
			BEGIN
				SET @NTIEMPOHOR = @ITIEMPOHOR
				SET @NTIEMPODIA = @ITIEMPODIA
				SET @NTIEMPOSEM = @ITIEMPOSEM
			END
		
		--SE REDONDEA HACIA ARRIBA EL VALOR DE TIEMPO HORA	
		SET @VTIEMPOHOR = CASE WHEN @NTIEMPOHOR > 24 THEN ROUND(@NTIEMPOHOR, 0) ELSE @NTIEMPOHOR END
		--SE REDONDEA HACIA ARRIBA EL VALOR DE TIEMPO DIA
		SET @VTIEMPODIA = ROUND(@NTIEMPODIA, 0)
		--SE REDONDEA HACIA ARRIBA EL VALOR DE TIEMPO SEMANA
		SET @VTIEMPOSEM = CASE WHEN @NTIEMPOSEM >= 1 THEN ROUND(@NTIEMPOSEM, 0) ELSE @ITIEMPOSEM END
		
		--SE OBTIENE EL PRECIO DEL ALQILER POR HORA
		SET @NPRECIOHOR = (SELECT TOP 1 [PrecioUnitario] FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [Descripcion] LIKE '%Hora%') * 1.00
		--SE OBTIENE EL PRECIO DEL ALQILER POR DIA
		SET @NPRECIODIA = (SELECT TOP 1 [PrecioUnitario] FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [Descripcion] LIKE '%Dia%') * 1.00
		--SE OBTIENE EL PRECIO DEL ALQILER POR SEMANA
		SET @NPRECIOSEM = (SELECT TOP 1 [PrecioUnitario] FROM [DemoAlquilerGameWinForm].[dbo].[precio] WHERE [Descripcion] LIKE '%Semana%') * 1.00
		
		SET @NPRECIOHOR = CAST(@VTIEMPOHOR AS NUMERIC(19,2)) * @NPRECIOHOR * 1.00
		SET @NPRECIODIA = CAST(@VTIEMPODIA AS NUMERIC(19,2)) * @NPRECIODIA * 1.00
		SET @NPRECIOSEM = CAST(@VTIEMPOSEM AS NUMERIC(19,2)) * @NPRECIOSEM * 1.00
		
		--SE CALCULA EL PRECIO ESTIMADO DEL ALQUILER
		SET @NPRECIO = CAST((@NPRECIOHOR + @NPRECIODIA + @NPRECIOSEM) AS NUMERIC(19,2)) * 1.00
		
		--EL ESTATUS DEL ALQUILER ES '1' - ALQUILADO
		SET @IESTATUS = 1
		
		--SE ACTUALIZA EL ALQUILER
        UPDATE A1
		SET	A1.IDCliente = @ICLIENTE,
			A1.IDProducto = @IPRODUCTO,
			A1.FechaDesde = @DFECHADESDE,
			A1.FechaHasta = @DFECHAHASTA,
			A1.TiempoHora = @VTIEMPOHOR,
			A1.TiempoDia = @VTIEMPODIA,
			A1.TiempoSemana = @VTIEMPOSEM,
			A1.PrecioEstimado = @NPRECIO,
			A1.Estatus = @IESTATUS
		FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1
		WHERE A1.ID = @IID
        
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_XMLPAGODET]    Script Date: 02/27/2018 14:07:00 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_XMLPAGODET]
(   
  @ALQUILERES AS XML, @IID AS INT, @ITIPO AS INT
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 

BEGIN TRY 

CREATE TABLE #ALQUILERES
(
	IDPagoCab INT, IDAlquiler INT, PrecioUnitario FLOAT, Descuento FLOAT, PrecioTotal FLOAT
)

INSERT INTO #ALQUILERES
SELECT DISTINCT
IDPagoCab = R.x.value('@IDPagoCab[1]', 'INT'),
IDAlquiler = R.x.value('@IDAlquiler[1]', 'INT'),
PrecioUnitario = R.x.value('@PrecioUnitario[1]', 'FLOAT'),
Descuento = R.x.value('@Descuento[1]', 'FLOAT'),
PrecioTotal = R.x.value('@PrecioTotal[1]', 'FLOAT')
FROM
@ALQUILERES.nodes('ALQUILERES/ALQUILER') AS R(x)

BEGIN TRAN

	DECLARE @INUMERO INT 
	DECLARE @IDPagoCab INT
	DECLARE @IDAlquiler INT
	DECLARE @FPRECIOUNIT FLOAT
	DECLARE @FDESCUENTO FLOAT
	DECLARE @FPRECIOTOTAL FLOAT
	
	--SE ES '0' SE MODIFICA - SI ES '1' SE INCLUYE
	IF (@ITIPO = 0) 
	BEGIN
		DELETE [DemoAlquilerGameWinForm].[dbo].[pagoDet] WHERE IDPagoCab = @IID
	END
	
    DECLARE ALQUILERES_CURSOR CURSOR FOR 
	SELECT IDPagoCab,IDAlquiler,PrecioUnitario,Descuento,PrecioTotal FROM #ALQUILERES
	OPEN ALQUILERES_CURSOR  
    FETCH NEXT FROM ALQUILERES_CURSOR INTO @IDPagoCab,@IDAlquiler,@FPRECIOUNIT,@FDESCUENTO,@FPRECIOTOTAL
    WHILE @@FETCH_STATUS = 0  
    BEGIN
		
		/* 
		 ' ESTE SP SE ENCARGA DE REGISTRAR EL PAGO DETALLE ES SOLO LLAMADO DEL SP DE PAGO CABECERA
		 ' ES LLAMADO SOLO DEL USP_INCPAGOCAB Y DEL USP_MODPAGOCAB
		*/
		
		--SE INSERTA EL PAGO DETALLE
		INSERT INTO [DemoAlquilerGameWinForm].[dbo].[pagoDet] 
			(IDPagoCab, IDAlquiler, PrecioUnitario, Descuento, PrecioTotal) 
		VALUES
			(@IDPagoCab, @IDAlquiler, @FPRECIOUNIT, @FDESCUENTO, @FPRECIOTOTAL)
		
		--SE ES '0' SE MODIFICA POR LO TANTO EL ALQUILER YA ESTA PAGADO
		IF (@ITIPO = 0) 
		BEGIN
			--SE ACTUALIZA EL ESTATUS DEL ALQUILER '2' - ALQUILADO PAGADO
			UPDATE A1 SET A1.Estatus = 2 FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WHERE A1.ID = @IDAlquiler
		END

	    FETCH NEXT FROM ALQUILERES_CURSOR INTO @IDPagoCab,@IDAlquiler,@FPRECIOUNIT,@FDESCUENTO,@FPRECIOTOTAL
    END  
    CLOSE ALQUILERES_CURSOR 
    DEALLOCATE ALQUILERES_CURSOR  
COMMIT TRAN

END TRY  
  
BEGIN CATCH  
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()  
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()    
  GOTO ERROR  
  
END CATCH  
  
SET NOCOUNT OFF  
  
RETURN  
ERROR:  
  IF XACT_STATE() <> 0 ROLLBACK TRAN  
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_INCPAGOCAB]    Script Date: 02/23/2018 17:50:05 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_INCPAGOCAB] 
(   
  @ICLIENTE AS INT, @DFECHA AS DATETIME, @FMONTOEXTO AS FLOAT=0.00, 
  @FMONTODESC AS FLOAT=NULL, @FMONTOTAL AS FLOAT=NULL, @IESTATUS AS INT = 0
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @INUMEROFILA INT = 0, @INUMERO INT = 0, @IID INT = 0
DECLARE @NDESCAB NUMERIC(19,2), @NDESDET NUMERIC(19,2)

BEGIN TRY
  
    BEGIN  
      
      BEGIN TRAN
		
		--SE OBTIENE EL DESCUENTO POR CABECERA - 30% 
		SET @NDESCAB = (SELECT TOP 1 [PorcentajeDescuento] FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WHERE [Descripcion] LIKE '%Cabecera%' AND [Estatus] = 1) * 1.00
		--SE OBTIENE EL DESCUENTO POR LINEA - 0%
		SET @NDESDET = (SELECT TOP 1 [PorcentajeDescuento] FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WHERE [Descripcion] LIKE '%Linea%' AND [Estatus] = 1) * 1.00
		
		--SE OBTIENE EL NUMERO DE FILAS PARA EL CALCULO DE TRANSACIONES PARA EL DESCUENTO CUANDO EL ESTATUS DEL ALQUILER SEA '1' - ALQUILADO
		SET @INUMEROFILA = (SELECT COUNT(*) AS INUMEROFILA FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] WHERE [Estatus] = 1 AND [IDCliente] = @ICLIENTE)
		
		--SE SE COMPARA EL NUMERO DE TRANSACION PARA APLICAR LA PROMOCION FAMILY RENTAL - DE 3 A 5 ALQUILERES
		SET @INUMERO = (SELECT 1 WHERE @INUMEROFILA BETWEEN 3 AND 5)
		SET @INUMERO = ISNULL(@INUMERO, 0)
		
		IF @INUMERO >= 1
		BEGIN
			--SE OBTIENE Y SE CALCULAN LOS MONTOS CON EL DESCUENTO APLICADO DE CABECERA - 30%
			SET @FMONTOEXTO = (SELECT CAST(SUM(A1.PrecioEstimado * 1.00) AS NVARCHAR(30)) AS PrecioUnitario 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK)	WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = (SELECT CAST((SUM(@NDESDET * A1.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS Descuento 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTOTAL = (SELECT CAST((SUM(A1.PrecioEstimado - (@NDESDET * A1.PrecioEstimado)) * 1.00) AS NVARCHAR(30)) AS PrecioTotal
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = @NDESCAB * @FMONTOEXTO
			SET @FMONTOTAL = @FMONTOEXTO - @FMONTODESC
		END
		ELSE
		BEGIN
			--SE OBTIENE Y SE CALCULAN LOS MONTOS CON EL DESCUENTO - 0% - EN ESTE CASO SE APLICA UN DESCUENTO DE '0%'
			SET @FMONTOEXTO = (SELECT CAST(SUM(A1.PrecioEstimado * 1.00) AS NVARCHAR(30)) AS PrecioUnitario 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK)	WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = (SELECT CAST((SUM(@NDESDET * A1.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS Descuento 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTOTAL = (SELECT CAST((SUM(A1.PrecioEstimado - (@NDESDET * A1.PrecioEstimado)) * 1.00) AS NVARCHAR(30)) AS PrecioTotal
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = @NDESDET * @FMONTOEXTO
			SET @FMONTOTAL = @FMONTOEXTO - @FMONTODESC
		END
		
		--SE SETEA EL ESTATUS EN '0' EL PAGO ESTA INICIADO
		SET @IESTATUS = 0
		
		-- INSERTA EL PAGO CABECERA
		INSERT INTO [DemoAlquilerGameWinForm].[dbo].[pagoCab]
          (IDCliente, Fecha, MontoExento, Descuento, MontoTotal, Estatus)
        VALUES
          (@ICLIENTE, @DFECHA, @FMONTOEXTO, @FMONTODESC, @FMONTOTAL, @IESTATUS)		
		
		--OBTIENE EL ULTIMO ID DEL REGISTRO INSERTADO
		SET @IID = (SELECT TOP 1 ID FROM [DemoAlquilerGameWinForm].[dbo].[pagoCab] WHERE [IDCliente] = @ICLIENTE ORDER BY ID DESC)
		
		--CREA XML PARA INSERTAR EL PAGO DETALLE
		DECLARE @XML_ALQUILERES AS XML = NULL		
		SET @XML_ALQUILERES = (SELECT @IID AS IDPagoCab, ALQUILER.ID AS IDAlquiler, ALQUILER.IDCliente, ALQUILER.IDProducto, 
				ALQUILER.FechaDesde, ALQUILER.FechaHasta, ALQUILER.TiempoHora, ALQUILER.TiempoDia, ALQUILER.TiempoSemana, 
				CAST((ALQUILER.PrecioEstimado * 1.00) AS NVARCHAR(30)) AS PrecioUnitario, 
				CAST(((@NDESDET * ALQUILER.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS Descuento, 
				CAST((ALQUILER.PrecioEstimado - (@NDESDET * ALQUILER.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS PrecioTotal, 
				ALQUILER.Estatus 
		FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] ALQUILER WITH (NOLOCK)
		WHERE ALQUILER.Estatus = 1 AND ALQUILER.IDCliente = @ICLIENTE FOR XML AUTO, ROOT ('ALQUILERES'))
		
		--REGISTRA EL DETALLE - ESTE SP ES SOLO LLAMADO DEL SP DE PAGO
		EXEC [DemoAlquilerGameWinForm].[dbo].[USP_XMLPAGODET] @XML_ALQUILERES, @IID, 1
		                 
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_MODPAGOCAB]    Script Date: 02/23/2018 17:50:05 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_MODPAGOCAB] 
(   
  @IID AS INT, @ICLIENTE AS INT, @DFECHA AS DATETIME, @FMONTOEXTO AS FLOAT=0.00, 
  @FMONTODESC AS FLOAT=NULL, @FMONTOTAL AS FLOAT=NULL, @IESTATUS AS INT = 1
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @INUMEROFILA INT= 0, @INUMERO INT= 0
DECLARE @NDESCAB NUMERIC(19,2), @NDESDET NUMERIC(19,2)

BEGIN TRY
  
    BEGIN  
      
      BEGIN TRAN
		
		--SE OBTIENE EL DESCUENTO POR CABECERA - 30% 
		SET @NDESCAB = (SELECT TOP 1 [PorcentajeDescuento] FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WHERE [Descripcion] LIKE '%Cabecera%' AND [Estatus] = 1) * 1.00
		--SE OBTIENE EL DESCUENTO POR LINEA - 0%
		SET @NDESDET = (SELECT TOP 1 [PorcentajeDescuento] FROM [DemoAlquilerGameWinForm].[dbo].[descuento] WHERE [Descripcion] LIKE '%Linea%' AND [Estatus] = 1) * 1.00
		
		--SE OBTIENE EL NUMERO DE FILAS PARA EL CALCULO DE TRANSACIONES PARA EL DESCUENTO CUANDO EL ESTATUS DEL ALQUILER SEA '1' - ALQUILADO
		SET @INUMEROFILA = (SELECT COUNT(*) AS INUMEROFILA FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] WHERE [Estatus] = 1 AND [IDCliente] = @ICLIENTE)
		
		--SE SE COMPARA EL NUMERO DE TRANSACION PARA APLICAR LA PROMOCION FAMILY RENTAL - DE 3 A 5 ALQUILERES
		SET @INUMERO = (SELECT 1 WHERE @INUMEROFILA BETWEEN 3 AND 5)
		SET @INUMERO = ISNULL(@INUMERO, 0)
		
		IF @INUMERO >= 1
		BEGIN
			--SE OBTIENE Y SE CALCULAN LOS MONTOS CON EL DESCUENTO APLICADO DE CABECERA - 30%
			SET @FMONTOEXTO = (SELECT CAST(SUM(A1.PrecioEstimado * 1.00) AS NVARCHAR(30)) AS PrecioUnitario 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK)	WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = (SELECT CAST((SUM(@NDESDET * A1.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS Descuento 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTOTAL = (SELECT CAST((SUM(A1.PrecioEstimado - (@NDESDET * A1.PrecioEstimado)) * 1.00) AS NVARCHAR(30)) AS PrecioTotal
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = @NDESCAB * @FMONTOEXTO
			SET @FMONTOTAL = @FMONTOEXTO - @FMONTODESC
		END
		ELSE
		BEGIN
			--SE OBTIENE Y SE CALCULAN LOS MONTOS CON EL DESCUENTO - 0% - EN ESTE CASO SE APLICA UN DESCUENTO DE '0%'
			SET @FMONTOEXTO = (SELECT CAST(SUM(A1.PrecioEstimado * 1.00) AS NVARCHAR(30)) AS PrecioUnitario 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK)	WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = (SELECT CAST((SUM(@NDESDET * A1.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS Descuento 
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTOTAL = (SELECT CAST((SUM(A1.PrecioEstimado - (@NDESDET * A1.PrecioEstimado)) * 1.00) AS NVARCHAR(30)) AS PrecioTotal
			FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] A1 WITH (NOLOCK) WHERE A1.Estatus = 1 AND A1.IDCliente = @ICLIENTE)
			
			SET @FMONTODESC = @NDESDET * @FMONTOEXTO
			SET @FMONTOTAL = @FMONTOEXTO - @FMONTODESC
		END
		
		--SE SETEA EL ESTATUS EN '1' EL PAGO ESTA PROCESADO
		SET @IESTATUS = 1
		
		--CREA XML PARA INSERTAR EL PAGO DETALLE
		DECLARE @XML_ALQUILERES AS XML = NULL		
		SET @XML_ALQUILERES = (SELECT @IID AS IDPagoCab, ALQUILER.ID AS IDAlquiler, ALQUILER.IDCliente, ALQUILER.IDProducto, 
				ALQUILER.FechaDesde, ALQUILER.FechaHasta, ALQUILER.TiempoHora, ALQUILER.TiempoDia, ALQUILER.TiempoSemana, 
				CAST((ALQUILER.PrecioEstimado * 1.00) AS NVARCHAR(30)) AS PrecioUnitario, 
				CAST(((@NDESDET * ALQUILER.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS Descuento, 
				CAST((ALQUILER.PrecioEstimado - (@NDESDET * ALQUILER.PrecioEstimado) * 1.00) AS NVARCHAR(30)) AS PrecioTotal, 
				ALQUILER.Estatus 
		FROM [DemoAlquilerGameWinForm].[dbo].[alquiler] ALQUILER WITH (NOLOCK)
		WHERE ALQUILER.Estatus = 1 AND ALQUILER.IDCliente = @ICLIENTE FOR XML AUTO, ROOT ('ALQUILERES'))
        
        UPDATE A1
		SET	A1.IDCliente = @ICLIENTE,
			A1.Fecha = @DFECHA,
			A1.MontoExento = @FMONTOEXTO,
			A1.Descuento = @FMONTODESC,
			A1.MontoTotal = @FMONTOTAL,
			A1.Estatus = @IESTATUS
		FROM [DemoAlquilerGameWinForm].[dbo].[pagoCab] A1
		WHERE A1.ID = @IID
		
		--REGISTRA EL DETALLE - ESTE SP ES SOLO LLAMADO DEL SP DE PAGO
		EXEC [DemoAlquilerGameWinForm].[dbo].[USP_XMLPAGODET] @XML_ALQUILERES, @IID, 0
        
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

/****** Object:  StoredProcedure [dbo].[USP_PAGOCAB]    Script Date: 02/23/2018 17:50:05 ******/
SET QUOTED_IDENTIFIER ON
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT ON;
GO
CREATE PROCEDURE [dbo].[USP_PAGOCAB] 
(   
  @ICLIENTE AS INT, @DFECHA AS DATETIME, @FMONTOEXTO AS FLOAT=0.00, 
  @FMONTODESC AS FLOAT=NULL, @FMONTOTAL AS FLOAT=NULL, @IESTATUS AS INT = 0
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @INUMEROFILA INT = 0, @INUMERO INT = 0, @IID INT = 0
DECLARE @NDESCAB NUMERIC(19,2), @NDESDET NUMERIC(19,2)

BEGIN TRY
  
    BEGIN  
      
      BEGIN TRAN
		
		--SE REGISTRA EL PAGO CON ESTATUS - 0
		EXEC [DemoAlquilerGameWinForm].[dbo].[USP_INCPAGOCAB] @ICLIENTE, @DFECHA, @FMONTOEXTO, @FMONTODESC, @FMONTOTAL, @IESTATUS
		SET @INUMERO = (SELECT TOP 1 [ID] FROM [DemoAlquilerGameWinForm].[dbo].[pagoCab] ORDER BY [ID] DESC)
		--SE ACTUALIZA EL PAGO CON ESTATUS - 1
		EXEC [DemoAlquilerGameWinForm].[dbo].[USP_MODPAGOCAB] @INUMERO, @ICLIENTE, @DFECHA, @FMONTOEXTO, @FMONTODESC, @FMONTOTAL, @IESTATUS
		
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[cliente] ([Nombre],[Telefono],[Correo], [Direccion])
VALUES	('Tyrion Lannister','0234-2313098','tyrion@gmail.com', 'Los Cortijos'), 
		('Arya Stark','0424-5308590','aryagot@hotmail.com', 'Sabana Grande'), 
		('Jon Snow','0254-8004554','jonsnow@gmail.com', 'Urb. Altamira'),
		('Jaime Lannister','0409-8902368','jaime@gmail.com', 'Plaza Venezuela'),
		('Sansa Stark','090-2368450','sansagot@gmail.com', 'Plaza Bolivar')
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[precio] ([Codigo],[Descripcion],[PrecioUnitario])
VALUES	('PRE1', 'Por Hora', 5.00), 
		('PRE2', 'Por Dia', 20.00), 
		('PRE3', 'Por Semana', 60.00)
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[descuento] ([Codigo],[Descripcion],[PorcentajeDescuento],[Estatus])
VALUES	('DEC1', 'Por Cabecera', 0.30, 1), 
		('DEC2', 'Por Linea', 0.00, 1)
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[marca] ([Codigo],[Descripcion])
VALUES	('MAC1', 'EA'), 
		('MAC2', 'Activiccion'), 
		('MAC3', 'Microsoft Game'), 
		('MAC4', 'Nintendo'), 
		('MAC5', 'Mojang AB'), 
		('MAC6', 'Konami'), 
		('MAC7', 'Sonny'), 
		('MAC8', 'Square Enix') 
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[modelo] ([Codigo],[Descripcion])
VALUES	('MOD1', 'PC'), 
		('MOD2', 'PSP'), 
		('MOD3', 'PSP2'), 
		('MOD4', 'Nintendo'), 
		('MOD5', 'DS')
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[categoria] ([Codigo],[Descripcion])
VALUES	('CAT1', 'Simulaci�n'), 
		('CAT2', 'RPG'), 
		('CAT3', 'Aventura'), 
		('CAT4', 'Terror')
GO

INSERT INTO [DemoAlquilerGameWinForm].[dbo].[producto] ([Codigo],[Descripcion],[IDMarca],[IDModelo],[IDCategoria])
VALUES	('JUE1', 'Los Sims', 1, 1, 1), ('JUE2', 'Final Fantasy III', 2, 4, 2), ('JUE3', 'Minecraft', 5, 1, 3), ('JUE4', 'Silent Hill', 6, 1, 4), 
		('JUE5', 'Los Sims 2', 1, 1, 1), ('JUE6', 'Final Fantasy VI', 2, 4, 2), ('JUE7', 'Super Mario Bros', 4, 4, 3), ('JUE8', 'The Evil Within', 7, 1, 4), 
		('JUE9', 'Microsoft Flight Simulator', 3, 1, 1), ('JUE10', 'Final Fantasy VIII', 2, 4, 2), ('JUE11', 'Tomb Raider Survivor', 8, 1, 3), ('JUE12', 'Dead Space', 1, 1, 4)
GO

DECLARE @DFECHADESDE AS DATETIME, @DFECHAHASTA AS DATETIME
SET @DFECHADESDE = GETDATE()
SET @DFECHAHASTA = DATEADD(HOUR, 90, GETDATE())
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_INCALQUILER] 1, 1, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, 0
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_MODALQUILER] 1, 1, 1, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, NULL, 1
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_INCALQUILER] 1, 2, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, 0
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_MODALQUILER] 2, 1, 2, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, NULL, 1
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_INCALQUILER] 1, 3, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, 0
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_MODALQUILER] 3, 1, 3, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, NULL, 1
SET @DFECHAHASTA = DATEADD(HOUR, 193, GETDATE())
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_INCALQUILER] 2, 4, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, 0
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_MODALQUILER] 4, 2, 4, @DFECHADESDE, @DFECHAHASTA, NULL, NULL, NULL, 1
SET @DFECHAHASTA = DATEADD(HOUR, 90, GETDATE())
EXEC [DemoAlquilerGameWinForm].[dbo].[USP_PAGOCAB] 1, @DFECHADESDE, 0

GO
