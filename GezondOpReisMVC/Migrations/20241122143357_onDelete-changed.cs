using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GezondOpReis.Migrations
{
    /// <inheritdoc />
    public partial class onDeletechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programma_Activiteit_ActiviteidId",
                table: "Programma");

            migrationBuilder.DropForeignKey(
                name: "FK_Programma_Groepsreis_GroepsreisId",
                table: "Programma");

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_Activiteit_ActiviteidId",
                table: "Programma",
                column: "ActiviteidId",
                principalTable: "Activiteit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_Groepsreis_GroepsreisId",
                table: "Programma",
                column: "GroepsreisId",
                principalTable: "Groepsreis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programma_Activiteit_ActiviteidId",
                table: "Programma");

            migrationBuilder.DropForeignKey(
                name: "FK_Programma_Groepsreis_GroepsreisId",
                table: "Programma");

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_Activiteit_ActiviteidId",
                table: "Programma",
                column: "ActiviteidId",
                principalTable: "Activiteit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_Groepsreis_GroepsreisId",
                table: "Programma",
                column: "GroepsreisId",
                principalTable: "Groepsreis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
