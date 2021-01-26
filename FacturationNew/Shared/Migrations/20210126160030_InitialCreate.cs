using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturationNew.Shared.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiffreAffaire",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chiffreAffairesDu = table.Column<double>(type: "float", nullable: false),
                    chiffreAffairesReel = table.Column<double>(type: "float", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiffreAffaire", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateEmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateReglement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montantDu = table.Column<double>(type: "float", nullable: false),
                    montantRegle = table.Column<double>(type: "float", nullable: false),
                    ChiffreAffaireid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.id);
                    table.ForeignKey(
                        name: "FK_Facture_ChiffreAffaire_ChiffreAffaireid",
                        column: x => x.ChiffreAffaireid,
                        principalTable: "ChiffreAffaire",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ChiffreAffaire",
                columns: new[] { "id", "chiffreAffairesDu", "chiffreAffairesReel", "year" },
                values: new object[] { 1, 66666.0, 66666.0, null });

            migrationBuilder.InsertData(
                table: "Facture",
                columns: new[] { "id", "ChiffreAffaireid", "client", "code", "dateEmission", "dateReglement", "montantDu", "montantRegle" },
                values: new object[] { 3, null, "John Test", "F666", new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 666.0, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Facture_ChiffreAffaireid",
                table: "Facture",
                column: "ChiffreAffaireid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "ChiffreAffaire");
        }
    }
}
