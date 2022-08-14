using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class CrratePenyedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Penyedia",
                columns: table => new
                {
                    PenyediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaPenyedia = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    NPWP = table.Column<string>(type: "text", nullable: true),
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penyedia", x => x.PenyediaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penyedia");
        }
    }
}
