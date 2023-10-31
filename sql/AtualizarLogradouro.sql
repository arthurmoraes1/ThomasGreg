USE [CadastroClientes]
GO

/****** Object:  StoredProcedure [dbo].[AtualizarLogradouro]    Script Date: 31/10/2023 11:38:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[AtualizarLogradouro]
    @Id UNIQUEIDENTIFIER,
    @Logradouro NVARCHAR(255),
    @ClienteId UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE Enderecos
    SET Logradouro = @Logradouro,
		ClienteId = @ClienteId,
        UpdateAt = GETDATE() 
    WHERE Id = @Id
END
GO


