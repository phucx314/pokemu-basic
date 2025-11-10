using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PokEmuBasic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCardTypeTables_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "card_sub_type_id",
                table: "cards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "card_super_type_id",
                table: "cards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "element_type_id",
                table: "cards",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "power_index",
                table: "cards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "card_sub_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sub_type_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card_sub_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_super_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    super_type_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card_super_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "element_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    type_image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_element_types", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cards_card_sub_type_id",
                table: "cards",
                column: "card_sub_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_cards_card_super_type_id",
                table: "cards",
                column: "card_super_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_cards_element_type_id",
                table: "cards",
                column: "element_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_card_sub_types_card_sub_type_id",
                table: "cards",
                column: "card_sub_type_id",
                principalTable: "card_sub_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_card_super_types_card_super_type_id",
                table: "cards",
                column: "card_super_type_id",
                principalTable: "card_super_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_element_types_element_type_id",
                table: "cards",
                column: "element_type_id",
                principalTable: "element_types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_card_sub_types_card_sub_type_id",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_cards_card_super_types_card_super_type_id",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_cards_element_types_element_type_id",
                table: "cards");

            migrationBuilder.DropTable(
                name: "card_sub_types");

            migrationBuilder.DropTable(
                name: "card_super_types");

            migrationBuilder.DropTable(
                name: "element_types");

            migrationBuilder.DropIndex(
                name: "ix_cards_card_sub_type_id",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "ix_cards_card_super_type_id",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "ix_cards_element_type_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "card_sub_type_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "card_super_type_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "element_type_id",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "power_index",
                table: "cards");
        }
    }
}
