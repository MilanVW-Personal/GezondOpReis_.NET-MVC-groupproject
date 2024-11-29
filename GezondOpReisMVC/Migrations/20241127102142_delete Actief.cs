using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GezondOpReis.Migrations
{
    /// <inheritdoc />
    public partial class deleteActief : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actief",
                table: "Bestemming");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Actief",
                table: "Bestemming",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
