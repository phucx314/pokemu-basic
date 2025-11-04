using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokEmuBasic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPackFeatured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_cards_rarity_id",
                table: "cards");

            migrationBuilder.AddColumn<bool>(
                name: "is_featured",
                table: "packs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "ix_cards_index_number",
                table: "cards",
                column: "index_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_cards_rarity_id_id",
                table: "cards",
                columns: new[] { "rarity_id", "id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_cards_index_number",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "ix_cards_rarity_id_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "is_featured",
                table: "packs");

            migrationBuilder.CreateIndex(
                name: "ix_cards_rarity_id",
                table: "cards",
                column: "rarity_id");
        }
    }
}
