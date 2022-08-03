using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class UpdateRekeningTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransKegiatan_Rekening_RekeningId",
                table: "TransKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_TransKegiatan_RekeningId",
                table: "TransKegiatan");

            migrationBuilder.DropColumn(
                name: "RekeningId",
                table: "TransKegiatan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RekeningId",
                table: "TransKegiatan",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_RekeningId",
                table: "TransKegiatan",
                column: "RekeningId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransKegiatan_Rekening_RekeningId",
                table: "TransKegiatan",
                column: "RekeningId",
                principalTable: "Rekening",
                principalColumn: "RekeningId");
        }
    }
}
