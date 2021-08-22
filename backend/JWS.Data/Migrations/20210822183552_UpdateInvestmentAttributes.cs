using Microsoft.EntityFrameworkCore.Migrations;

namespace JWS.Data.Migrations
{
    public partial class UpdateInvestmentAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalProfitPercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCapital",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalProfitPercent",
                table: "FundInvestments");

            migrationBuilder.DropColumn(
                name: "TotalCapital",
                table: "FundInvestments");
        }
    }
}
