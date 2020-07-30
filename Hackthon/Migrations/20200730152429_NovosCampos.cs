using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackthon.Migrations
{
    public partial class NovosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtividadeEconomica",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CpfCnpj",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TipoCadastro",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtividadeEconomica",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CpfCnpj",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoCadastro",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
