using Microsoft.EntityFrameworkCore.Migrations;

namespace OrnekProje.Migrations
{
    public partial class AddPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Şehir",
                table: "OrderHeader");

            //migrationBuilder.AddColumn<string>
            //    name: "CardName",
            //    table: "OrderHeader",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "OrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cvc",
                table: "OrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationMonth",
                table: "OrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationYear",
                table: "OrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "OrderHeader",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardName",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "Cvc",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "ExpirationMonth",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "ExpirationYear",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "OrderHeader");

            migrationBuilder.AddColumn<string>(
                name: "Şehir",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
