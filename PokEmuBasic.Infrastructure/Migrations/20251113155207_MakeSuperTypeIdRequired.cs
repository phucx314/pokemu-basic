using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokEmuBasic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeSuperTypeIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_card_super_types_card_super_type_id",
                table: "cards");

            migrationBuilder.AlterColumn<int>(
                name: "card_super_type_id",
                table: "cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_cards_card_super_types_card_super_type_id",
                table: "cards",
                column: "card_super_type_id",
                principalTable: "card_super_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_card_super_types_card_super_type_id",
                table: "cards");

            migrationBuilder.AlterColumn<int>(
                name: "card_super_type_id",
                table: "cards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_card_super_types_card_super_type_id",
                table: "cards",
                column: "card_super_type_id",
                principalTable: "card_super_types",
                principalColumn: "id");
        }
    }
}
