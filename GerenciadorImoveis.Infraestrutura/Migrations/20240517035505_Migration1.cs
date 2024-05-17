using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorImoveis.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoArquivo = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentoId = table.Column<long>(type: "bigint", nullable: true),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoImovelId = table.Column<long>(type: "bigint", nullable: false),
                    TipoImovel = table.Column<int>(type: "int", nullable: false),
                    ProprietarioId = table.Column<long>(type: "bigint", nullable: true),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: true),
                    ImovelStatus = table.Column<int>(type: "int", nullable: false),
                    AreaTerreno = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaEdificacao = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorAquisicao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatriculaId = table.Column<long>(type: "bigint", nullable: true),
                    PlantaId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imoveis_Clientes_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImovelId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImovelId = table.Column<long>(type: "bigint", nullable: true),
                    ArquivoId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matriculas_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImovelId = table.Column<long>(type: "bigint", nullable: true),
                    ArquivoId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantas_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plantas_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoEvento = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: true),
                    ImovelId = table.Column<long>(type: "bigint", nullable: true),
                    ArquivoId = table.Column<long>(type: "bigint", nullable: true),
                    MatriculaId = table.Column<long>(type: "bigint", nullable: true),
                    PlantaId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentoId = table.Column<long>(type: "bigint", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eventos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Plantas_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Plantas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "NomeCompleto", "NomeUsuario", "Senha", "TipoUsuario" },
                values: new object[] { 1L, true, null, "UsuarioMaster", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ClienteId",
                table: "Documentos",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ImovelId",
                table: "Enderecos",
                column: "ImovelId",
                unique: true,
                filter: "[ImovelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ArquivoId",
                table: "Eventos",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ClienteId",
                table: "Eventos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DocumentoId",
                table: "Eventos",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EnderecoId",
                table: "Eventos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ImovelId",
                table: "Eventos",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_MatriculaId",
                table: "Eventos",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_PlantaId",
                table: "Eventos",
                column: "PlantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ProprietarioId",
                table: "Imoveis",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_ArquivoId",
                table: "Matriculas",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_ImovelId",
                table: "Matriculas",
                column: "ImovelId",
                unique: true,
                filter: "[ImovelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_ArquivoId",
                table: "Plantas",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_ImovelId",
                table: "Plantas",
                column: "ImovelId",
                unique: true,
                filter: "[ImovelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
