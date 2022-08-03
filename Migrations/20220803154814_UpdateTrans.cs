using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class UpdateTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransKegiatan_Rekening_RekeningId",
                table: "TransKegiatan");

            migrationBuilder.DropColumn(
                name: "Anggaran",
                table: "TransKegiatan");

            migrationBuilder.AlterColumn<int>(
                name: "RekeningId",
                table: "TransKegiatan",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Tahun",
                table: "TransKegiatan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TransKegiatan_Rekening_RekeningId",
                table: "TransKegiatan",
                column: "RekeningId",
                principalTable: "Rekening",
                principalColumn: "RekeningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransKegiatan_Rekening_RekeningId",
                table: "TransKegiatan");

            migrationBuilder.DropColumn(
                name: "Tahun",
                table: "TransKegiatan");

            migrationBuilder.AlterColumn<int>(
                name: "RekeningId",
                table: "TransKegiatan",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Anggaran",
                table: "TransKegiatan",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_TransKegiatan_Rekening_RekeningId",
                table: "TransKegiatan",
                column: "RekeningId",
                principalTable: "Rekening",
                principalColumn: "RekeningId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
