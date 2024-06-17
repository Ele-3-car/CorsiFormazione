/****** Object:  Table [dbo].[CalendarioLezioni]    Script Date: 15/06/2024 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarioLezioni](
	[NomeCorso] [varchar](50) NOT NULL,
	[DataOraInizio] [datetime] NOT NULL,
	[DataOraFine] [datetime] NOT NULL,
	[Luogo] [varchar](50) NOT NULL,
	[ModoErogazione] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCorso] ASC,
	[DataOraInizio] ASC,
	[DataOraFine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corso]    Script Date: 15/06/2024 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corso](
	[NomeCorso] [varchar](50) NOT NULL,
	[NumeroOre] [int] NOT NULL,
	[Docente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCorso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente]    Script Date: 15/06/2024 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[NomeDocente] [varchar](50) NOT NULL,
	[CognomeDocente] [varchar](50) NOT NULL,
	[idDocente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presenza]    Script Date: 15/06/2024 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presenza](
	[Corso] [varchar](50) NOT NULL,
	[NomeAlunno] [varchar](50) NOT NULL,
	[CognomeAlunno] [varchar](50) NOT NULL,
	[DataOraIngresso] [datetime] NOT NULL,
	[DataOraUscita] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Corso] ASC,
	[NomeAlunno] ASC,
	[CognomeAlunno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 15/06/2024 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[UtenteEmail] [varchar](50) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[UtenteEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO