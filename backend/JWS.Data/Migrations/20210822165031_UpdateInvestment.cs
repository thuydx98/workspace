using Microsoft.EntityFrameworkCore.Migrations;

namespace JWS.Data.Migrations
{
    public partial class UpdateInvestment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SellFeePercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CapitalPrice",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BuyFeePercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "FundInvestments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FinalProfit",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MarketPrice",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SellPrice",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StopLossPercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TakeProfitPercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TrailingStopLossPercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalProfit",
                table: "FundInvestments");

            migrationBuilder.DropColumn(
                name: "MarketPrice",
                table: "FundInvestments");

            migrationBuilder.DropColumn(
                name: "SellPrice",
                table: "FundInvestments");

            migrationBuilder.DropColumn(
                name: "StopLossPercent",
                table: "FundInvestments");

            migrationBuilder.DropColumn(
                name: "TakeProfitPercent",
                table: "FundInvestments");

            migrationBuilder.DropColumn(
                name: "TrailingStopLossPercent",
                table: "FundInvestments");

            migrationBuilder.AlterColumn<double>(
                name: "SellFeePercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "CapitalPrice",
                table: "FundInvestments",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "BuyFeePercent",
                table: "FundInvestments",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "FundInvestments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
