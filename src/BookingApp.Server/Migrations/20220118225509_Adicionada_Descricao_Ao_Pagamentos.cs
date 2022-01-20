using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApp.Server.Migrations
{
    public partial class Adicionada_Descricao_Ao_Pagamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "payments",
                table: "payments",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                comment: "O que aconteceu...");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "payments",
                table: "payments");
        }
    }
}
