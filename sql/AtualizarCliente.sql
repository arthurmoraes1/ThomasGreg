USE [CadastroClientes]
GO

/****** Object:  StoredProcedure [dbo].[AtualizarCliente]    Script Date: 31/10/2023 11:37:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AtualizarCliente]
    @Id UNIQUEIDENTIFIER,
    @Nome NVARCHAR(255),
    @Email NVARCHAR(255),
    @Logotipo NVARCHAR(255)
AS
BEGIN
    UPDATE Clientes
    SET Nome = @Nome,
        Email = @Email,
        Logotipo = @Logotipo,
        UpdateAt = GETDATE() 
    WHERE Id = @Id
END
GO


