using Microsoft.EntityFrameworkCore.Migrations;

namespace EbtakrAlmanalntro.Data.Migrations
{
    public partial class modify_OurClients_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "OurClients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "OurClients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "OurClients");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "OurClients");
        }
    }
}
