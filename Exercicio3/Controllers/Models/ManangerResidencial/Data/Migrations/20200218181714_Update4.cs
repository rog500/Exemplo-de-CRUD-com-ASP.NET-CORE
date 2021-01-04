using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercicio3.Data.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Morador_Familia_Familia",
                table: "Morador");

            migrationBuilder.DropIndex(
                name: "IX_Morador_Familia",
                table: "Morador");

            migrationBuilder.DropColumn(
                name: "Familia",
                table: "Morador");

            migrationBuilder.CreateIndex(
                name: "IX_Morador_Id_Familia",
                table: "Morador",
                column: "Id_Familia");

            migrationBuilder.AddForeignKey(
                name: "FK_Morador_Familia_Id_Familia",
                table: "Morador",
                column: "Id_Familia",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Morador_Familia_Id_Familia",
                table: "Morador");

            migrationBuilder.DropIndex(
                name: "IX_Morador_Id_Familia",
                table: "Morador");

            migrationBuilder.AddColumn<int>(
                name: "Familia",
                table: "Morador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Morador_Familia",
                table: "Morador",
                column: "Familia");

            migrationBuilder.AddForeignKey(
                name: "FK_Morador_Familia_Familia",
                table: "Morador",
                column: "Familia",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
