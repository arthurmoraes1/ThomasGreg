USE [CadastroClientes]
GO

/****** Object:  StoredProcedure [dbo].[InserirCliente]    Script Date: 31/10/2023 11:36:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[InserirCliente]
    @Id UNIQUEIDENTIFIER,
    @Nome NVARCHAR(255),
    @Email NVARCHAR(255),
    @Logotipo NVARCHAR(255)
AS
BEGIN
    INSERT INTO Clientes (Id, Nome, Email, Logotipo, CreateAt)
    VALUES (@Id, @Nome, @Email, @Logotipo, GETDATE())
END
GO


