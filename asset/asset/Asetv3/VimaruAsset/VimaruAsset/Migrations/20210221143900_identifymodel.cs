using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VimaruAsset.Migrations
{
    public partial class identifymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "identify",
                table: "Assets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "identify",
                table: "Assets");
        }
    }
}
