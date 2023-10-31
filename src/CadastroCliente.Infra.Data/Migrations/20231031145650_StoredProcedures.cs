using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroCliente.Infra.Data.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[InserirCliente]
                                @Id UNIQUEIDENTIFIER,
                                @Nome NVARCHAR(255),
                                @Email NVARCHAR(255),
                                @Logotipo NVARCHAR(255)
                            AS
                            BEGIN
                                INSERT INTO Clientes (Id, Nome, Email, Logotipo, CreateAt)
                                VALUES (@Id, @Nome, @Email, @Logotipo, GETDATE())
                            END");

            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[AtualizarCliente]
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
                                END");

            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[RemoverCliente]
                                    @Id UNIQUEIDENTIFIER
                                AS
                                BEGIN
                                    DELETE FROM CLIENTES WHERE ID = @Id
                                END");

            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[InserirLogradouro]
                                    @Id UNIQUEIDENTIFIER,
                                    @Logradouro NVARCHAR(255),
                                    @ClienteId UNIQUEIDENTIFIER
                                AS
                                BEGIN
                                    INSERT INTO Enderecos (Id, Logradouro, ClienteId, CreateAt)
                                    VALUES (@Id, @Logradouro, @ClienteId, GETDATE())
                                END");

            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[AtualizarLogradouro]
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
                                END");

            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[RemoverLogradouro]
                                        @Id UNIQUEIDENTIFIER
                                    AS
                                    BEGIN
                                        DELETE FROM Enderecos WHERE ID = @Id
                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
