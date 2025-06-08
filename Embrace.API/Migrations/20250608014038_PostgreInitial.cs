using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Embrace.API.Migrations
{
    /// <inheritdoc />
    public partial class PostgreInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ONGS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TELEFONE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ONGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PONTOS_DE_ALIMENTO",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME_LOCAL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ENDERECO = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CAPACIDADE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTOS_DE_ALIMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VOLUNTARIOS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TELEFONE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CIDADE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOLUNTARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACOES_SOLIDARIAS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TIPO_EVENTO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ESTADO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DESCRICAO = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    META_ITENS = table.Column<int>(type: "integer", nullable: false),
                    ONG_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACOES_SOLIDARIAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACOES_SOLIDARIAS_ONGS_ONG_ID",
                        column: x => x.ONG_ID,
                        principalTable: "ONGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOACOES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TIPO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "integer", nullable: false),
                    DATA_RECEBIDA = table.Column<DateTime>(type: "DATE", nullable: false),
                    ACAO_SOLIDARIA_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOACOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOACOES_ACOES_SOLIDARIAS_ACAO_SOLIDARIA_ID",
                        column: x => x.ACAO_SOLIDARIA_ID,
                        principalTable: "ACOES_SOLIDARIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VOLUNTARIO_ACAO",
                columns: table => new
                {
                    VOLUNTARIO_ID = table.Column<long>(type: "bigint", nullable: false),
                    ACAO_SOLIDARIA_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOLUNTARIO_ACAO", x => new { x.VOLUNTARIO_ID, x.ACAO_SOLIDARIA_ID });
                    table.ForeignKey(
                        name: "FK_VOLUNTARIO_ACAO_ACOES_SOLIDARIAS_ACAO_SOLIDARIA_ID",
                        column: x => x.ACAO_SOLIDARIA_ID,
                        principalTable: "ACOES_SOLIDARIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VOLUNTARIO_ACAO_VOLUNTARIOS_VOLUNTARIO_ID",
                        column: x => x.VOLUNTARIO_ID,
                        principalTable: "VOLUNTARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACOES_SOLIDARIAS_ONG_ID",
                table: "ACOES_SOLIDARIAS",
                column: "ONG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DOACOES_ACAO_SOLIDARIA_ID",
                table: "DOACOES",
                column: "ACAO_SOLIDARIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VOLUNTARIO_ACAO_ACAO_SOLIDARIA_ID",
                table: "VOLUNTARIO_ACAO",
                column: "ACAO_SOLIDARIA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOACOES");

            migrationBuilder.DropTable(
                name: "PONTOS_DE_ALIMENTO");

            migrationBuilder.DropTable(
                name: "VOLUNTARIO_ACAO");

            migrationBuilder.DropTable(
                name: "ACOES_SOLIDARIAS");

            migrationBuilder.DropTable(
                name: "VOLUNTARIOS");

            migrationBuilder.DropTable(
                name: "ONGS");
        }
    }
}
