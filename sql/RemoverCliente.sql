USE [CadastroClientes]
GO

/****** Object:  StoredProcedure [dbo].[RemoverCliente]    Script Date: 31/10/2023 11:38:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[RemoverCliente]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM CLIENTES WHERE ID = @Id
END
GO


