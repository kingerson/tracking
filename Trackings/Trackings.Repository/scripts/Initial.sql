/****** Object:  Database [ArquetipoNetCore]    Script Date: 4/03/2020 18:04:01 ******/
CREATE DATABASE [ArquetipoNetCore]  
CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArquetipoNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ArquetipoNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArquetipoNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ArquetipoNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ArquetipoNetCore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArquetipoNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArquetipoNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArquetipoNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArquetipoNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ArquetipoNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArquetipoNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET RECOVERY FULL 
GO
ALTER DATABASE [ArquetipoNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [ArquetipoNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArquetipoNetCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArquetipoNetCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArquetipoNetCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArquetipoNetCore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ArquetipoNetCore', N'ON'
GO
ALTER DATABASE [ArquetipoNetCore] SET QUERY_STORE = OFF
GO
USE [ArquetipoNetCore]
GO
/****** Object:  Table [dbo].[ItemComponent]    Script Date: 4/03/2020 18:04:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemComponent](
	[itemComponentId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[typeLocalId] [int] NULL,
	[wattsXm2] [decimal](15, 2) NULL,
	[kiloWatts] [decimal](15, 2) NULL,
	[predecessor] [int] NULL,
	[saleReport] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[itemComponentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ItemComponent] ON 
GO
INSERT [dbo].[ItemComponent] ([itemComponentId], [name], [typeLocalId], [wattsXm2], [kiloWatts], [predecessor], [saleReport]) VALUES (1, N'Marketing', 71294, CAST(20.00 AS Decimal(15, 2)), CAST(30.00 AS Decimal(15, 2)), 4, 1)
GO
SET IDENTITY_INSERT [dbo].[ItemComponent] OFF
GO
/****** Object:  StoredProcedure [dbo].[ADV_T_RUBRO_find_all]    Script Date: 4/03/2020 18:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ADV_T_RUBRO_find_all]
(
	@pit_parametrosXML		ntext,
	@pii_paginaActual		int,
	@pii_cantidadMostrar	int,
	@piv_orderBy			varchar(100),
	@poi_totalRegistros		int output
)
As

-- VARIABLES SQL
Declare @sqlBody varchar(6000),@sqlJoin varchar(500),@sqlWhere varchar(1500),@sqlCount nvarchar(MAX);

-- VARIABLES DE FILTRO
Declare @docXML int,@menu_c_iid int;

-- VARIABLES DE PAGINACION
Declare @paginaDesde varchar(10),@paginaHasta varchar(10);

Begin

	--EXECUTE dbo.SGA_T_MENU_find_all '<Record> <menu_c_iid>1</menu_c_iid> </Record>',0,0,'',NULL;

	--INICIALIZO LAS VARIABLES
	Begin

		--INICIALIZO LOS XML
		EXEC sp_xml_preparedocument @docXML output, @pit_parametrosXML;

		--INICIALIZO PAGINACION
		Set @paginaDesde = Cast((((@pii_paginaActual - 1) * @pii_cantidadMostrar) + 1) As varchar);
		Set @paginaHasta = Cast((@pii_paginaActual * @pii_cantidadMostrar) As varchar);

	End;

	--OBTENGO LOS FILTROS
	Begin

		--menu_c_iid
		Begin Try
			Set @menu_c_iid =
			(
				Select rubro_c_yid
				From OpenXML (@docXML, 'Record',2)
				With (rubro_c_yid int)
			);
		End Try
		Begin Catch
			Set @menu_c_iid = 0;
		End Catch;

	End;

	--CONTRUYO LA CONSULTA SQL
	Begin

		--BODY SQL
		Begin
			Set @sqlBody = '
			Select
			db.itemComponentId			[itemComponentId],
			db.name			[name],
			db.typeLocalId			[typeLocalId],
			db.wattsXm2			[wattsXm2],
			db.kiloWatts			[kiloWatts],
			db.predecessor			[predecessor],
			db.saleReport			[saleReport]';

			Set @sqlJoin = '
			From dbo.ItemComponent [db]';
		End;

		--WHERE SQL
		Begin
			Set @sqlWhere = '
			Where (1=1)';

			--menu_c_iid
			If @menu_c_iid > 0
			Begin
				Set @sqlWhere = @sqlWhere + '
				And db.itemComponentId = ' + Cast(@menu_c_iid As Varchar) + ''
			End;
		End;

		--ORDER BY
		Begin
			If @piv_orderBy = ''
			Begin
				Set @piv_orderBy = 'itemComponentId ASC';
			End;

			Set @piv_orderBy = '
			Order By ' + @piv_orderBy;
		End;

	End;

	--EJECUTO LA CONSULTA SQL
	Begin

		--Print(@sqlBody + @sqlJoin + @sqlWhere + @piv_orderBy);

		If @pii_paginaActual > 0 --CONSULTA CON PAGINACION
		Begin

			--OBTENGO EL TOTAL DE REGISTROS
			Set @sqlCount = N'SELECT @COUNT = COUNT(1) ' + @sqlJoin + @sqlWhere;

			Execute sp_executesql @sqlCount,N'@COUNT INT OUTPUT',@COUNT=@poi_totalRegistros OUTPUT;

			Execute('SELECT * FROM (SELECT ROW_NUMBER() OVER (' + @piv_orderBy + ') [ROWNUM],* FROM (' + @sqlBody + @sqlJoin + @sqlWhere + ') [TMP] ) [PAG] WHERE ROWNUM >= ' + @paginaDesde + ' And ROWNUM <= ' + @paginaHasta)

		End
		Else
		Begin

			SET @poi_totalRegistros = 0;

			Execute(@sqlBody + @sqlJoin + @sqlWhere + @piv_orderBy);

		End;

	End;

End;
GO
ALTER DATABASE [ArquetipoNetCore] SET  READ_WRITE 
GO
