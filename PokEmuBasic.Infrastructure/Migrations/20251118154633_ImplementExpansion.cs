using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PokEmuBasic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImplementExpansion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "expansion_id",
                table: "packs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "expansion_id",
                table: "cards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "expansion_index",
                table: "cards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "expansions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    expansion_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    expansion_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    release_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    prefix_code = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_expansions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_packs_expansion_id",
                table: "packs",
                column: "expansion_id");

            migrationBuilder.CreateIndex(
                name: "ix_cards_expansion_id",
                table: "cards",
                column: "expansion_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_expansion_expansion_id",
                table: "cards",
                column: "expansion_id",
                principalTable: "expansions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_packs_expansion_expansion_id",
                table: "packs",
                column: "expansion_id",
                principalTable: "expansions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_expansion_expansion_id",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_packs_expansion_expansion_id",
                table: "packs");

            migrationBuilder.DropTable(
                name: "expansions");

            migrationBuilder.DropIndex(
                name: "ix_packs_expansion_id",
                table: "packs");

            migrationBuilder.DropIndex(
                name: "ix_cards_expansion_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "expansion_id",
                table: "packs");

            migrationBuilder.DropColumn(
                name: "expansion_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "expansion_index",
                table: "cards");
        }
    }
}
