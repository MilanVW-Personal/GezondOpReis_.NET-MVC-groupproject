using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GezondOpReis.Migrations
{
    /// <inheritdoc />
    public partial class fotoOnDeleteupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Bestemming_BestemmingId",
                table: "Foto");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Bestemming_BestemmingId",
                table: "Foto",
                column: "BestemmingId",
                principalTable: "Bestemming",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Bestemming_BestemmingId",
                table: "Foto");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Bestemming_BestemmingId",
                table: "Foto",
                column: "BestemmingId",
                principalTable: "Bestemming",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
