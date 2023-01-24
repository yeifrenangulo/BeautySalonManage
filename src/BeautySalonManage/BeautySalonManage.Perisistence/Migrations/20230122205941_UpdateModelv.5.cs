using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Perisistence.Migrations
{
    public partial class UpdateModelv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Turns");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Turns",
                type: "time",
                nullable: false,
                comment: "Hora Inicial del Turno",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "Hora Inicial del Turno");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Turns",
                type: "time",
                nullable: false,
                comment: "Hora Final del Turno",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "Hora Final del Turno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Turns",
                type: "datetime",
                nullable: false,
                comment: "Hora Inicial del Turno",
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldComment: "Hora Inicial del Turno");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Turns",
                type: "datetime",
                nullable: false,
                comment: "Hora Final del Turno",
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldComment: "Hora Final del Turno");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Turns",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Precio Total del Turno");
        }
    }
}
