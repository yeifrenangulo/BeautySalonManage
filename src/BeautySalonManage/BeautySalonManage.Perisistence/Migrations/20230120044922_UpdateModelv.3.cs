using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Perisistence.Migrations
{
    public partial class UpdateModelv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Services",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Detalle del Servicio",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Detalle del Servicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Detalle del Servicio",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Detalle del Servicio");
        }
    }
}
