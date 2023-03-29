using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskOfc.Migrations
{
    public partial class AddPictureColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Employes",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Employes");
        }
    }
}
