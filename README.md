# Prueba Técnica - Francisco Gálvez Grilñán

## Project Layout

* FGG_PRUEBA_TECNICA:
  * Controllers : Donde se encuentras los diferentes controladores del proyecto
  * Data: Donde se encuentra la clase que establece conexión con la base de datos
  * Documentacion: Se ecuentra un proyecto realizado a partir de Doxygen para generar la documentación técnica, solo se necita abrir el index.html que se encuentra en esta carpeta
  * Models: Los diferentes modelos del proyecto
  * Views: Las diferentes vistas del proyecto

## Dependencies

- NET CORE 5
- EntityFramework 
- Sql Server

## Configuration

Lo necesario para configurar el proyecto sería tener inicializadas las tablas con los siguientes script de creación:

## Tabla Clientes
```
USE [bbdd]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 20/04/2022 23:17:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[idClientes] [int] IDENTITY(1,1) NOT NULL,
	[CodCliente]  AS (right('000000'+CONVERT([varchar](6),[idClientes]),(6))) PERSISTED,
	[Nombre] [varchar](150) NOT NULL,
	[FechaInicio] [date] NULL,
	[CodigoComercial] [varchar](6) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idClientes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

## Tabla Usuarios
```
USE [bbdd]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/04/2022 23:20:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](200) NULL,
	[FechaAlta] [date] NOT NULL,
	[Clientes_idClientes] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Clientes] FOREIGN KEY([Clientes_idClientes])
REFERENCES [dbo].[Clientes] ([idClientes])
GO

ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Clientes]
GO
```


Una vez creada la base de datos seria suficiente con modificar la conexión a la base de datos en el fichero `appsettings.json`.
