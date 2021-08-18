using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JWS.Data.Migrations
{
    public partial class AddInvestment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundInvestments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UpdateType = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    CapitalPrice = table.Column<double>(type: "double precision", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: true),
                    BuyFeePercent = table.Column<double>(type: "double precision", nullable: true),
                    SellFeePercent = table.Column<double>(type: "double precision", nullable: true),
                    RevenuePercent = table.Column<double>(type: "double precision", nullable: true),
                    RevenueCycle = table.Column<int>(type: "integer", nullable: true),
                    FollowedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    InvestedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundInvestments_Funds_FundId",
                        column: x => x.FundId,
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundInvestments_FundId",
                table: "FundInvestments",
                column: "FundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundInvestments");
        }
    }
}
