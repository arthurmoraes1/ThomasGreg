USE [CadastroClientes]
GO

/****** Object:  StoredProcedure [dbo].[InserirLogradouro]    Script Date: 31/10/2023 11:38:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[InserirLogradouro]
    @Id UNIQUEIDENTIFIER,
    @Logradouro NVARCHAR(255),
    @ClienteId UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO Enderecos (Id, Logradouro, ClienteId, CreateAt)
    VALUES (@Id, @Logradouro, @ClienteId, GETDATE())
END
GO


