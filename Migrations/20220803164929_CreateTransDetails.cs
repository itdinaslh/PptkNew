using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class CreateTransDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransDetails",
                columns: table => new
                {
                    TransDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransKegiatanId = table.Column<long>(type: "bigint", nullable: false),
                    RekeningId = table.Column<int>(type: "integer", nullable: false),
                    Anggaran = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransDetails", x => x.TransDetailId);
                    table.ForeignKey(
                        name: "FK_TransDetails_Rekening_RekeningId",
                        column: x => x.RekeningId,
                        principalTable: "Rekening",
                        principalColumn: "RekeningId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransDetails_TransKegiatan_TransKegiatanId",
                        column: x => x.TransKegiatanId,
                        principalTable: "TransKegiatan",
                        principalColumn: "TransKegiatanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransDetails_RekeningId",
                table: "TransDetails",
                column: "RekeningId");

            migrationBuilder.CreateIndex(
                name: "IX_TransDetails_TransKegiatanId",
                table: "TransDetails",
                column: "TransKegiatanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransDetails");
        }
    }
}
