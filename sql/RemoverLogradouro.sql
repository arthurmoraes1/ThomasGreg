USE [CadastroClientes]
GO

/****** Object:  StoredProcedure [dbo].[RemoverEndereco]    Script Date: 31/10/2023 11:39:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[RemoverEndereco]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Enderecos WHERE ID = @Id
END
GO


