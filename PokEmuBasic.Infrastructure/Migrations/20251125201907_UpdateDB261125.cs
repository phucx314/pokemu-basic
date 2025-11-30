using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokEmuBasic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB261125 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_expansion_expansion_id",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_packs_expansion_expansion_id",
                table: "packs");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_expansions_expansion_id",
                table: "cards",
                column: "expansion_id",
                principalTable: "expansions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_packs_expansions_expansion_id",
                table: "packs",
                column: "expansion_id",
                principalTable: "expansions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_expansions_expansion_id",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_packs_expansions_expansion_id",
                table: "packs");

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
    }
}
