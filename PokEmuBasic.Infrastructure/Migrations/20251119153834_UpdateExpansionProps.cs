using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokEmuBasic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExpansionProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "expansion_code",
                table: "expansions",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "expansion_image",
                table: "expansions",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expansion_image",
                table: "expansions");

            migrationBuilder.AlterColumn<string>(
                name: "expansion_code",
                table: "expansions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }
    }
}
