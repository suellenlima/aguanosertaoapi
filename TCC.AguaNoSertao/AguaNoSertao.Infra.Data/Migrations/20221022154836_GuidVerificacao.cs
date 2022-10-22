using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AguaNoSertao.Infra.Data.Migrations
{
    public partial class GuidVerificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuidVerificacao",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidVerificacao",
                table: "Logins");
        }
    }
}
