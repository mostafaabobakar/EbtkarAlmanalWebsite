﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EbtakrAlmanalntro.Data.Migrations
{
    public partial class tables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShowPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowPassword",
                table: "AspNetUsers");
        }
    }
}
