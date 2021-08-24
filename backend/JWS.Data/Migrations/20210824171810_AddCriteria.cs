using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWS.Data.Migrations
{
    public partial class AddCriteria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateType",
                table: "FundInvestments",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FundInvestments",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "RevenueCycle",
                table: "FundInvestments",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "FundHistories",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "FundCriterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundCriterias_Funds_FundId",
                        column: x => x.FundId,
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundInvestmentsFundCriterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvestmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CriteriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundInvestmentsFundCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundInvestmentsFundCriterias_FundCriterias_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "FundCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundInvestmentsFundCriterias_FundInvestments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "FundInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundCriterias_FundId",
                table: "FundCriterias",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundInvestmentsFundCriterias_CriteriaId_InvestmentId",
                table: "FundInvestmentsFundCriterias",
                columns: new[] { "CriteriaId", "InvestmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_FundInvestmentsFundCriterias_InvestmentId",
                table: "FundInvestmentsFundCriterias",
                column: "InvestmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundInvestmentsFundCriterias");

            migrationBuilder.DropTable(
                name: "FundCriterias");

            migrationBuilder.AlterColumn<int>(
                name: "UpdateType",
                table: "FundInvestments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "FundInvestments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "RevenueCycle",
                table: "FundInvestments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "FundHistories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
