using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelInitialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Sistema",
                comment: "Usuario de Creación del Regitro");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                comment: "Fecha de Creación del Registro");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Sistema",
                comment: "Usuario de la Última Modificación del Regitro");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                comment: "Fecha de la Última Modificación del Registro");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Roles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Sistema",
                comment: "Usuario de Creación del Regitro");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Roles",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                comment: "Fecha de Creación del Registro");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Roles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Sistema",
                comment: "Usuario de la Última Modificación del Regitro");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Roles",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                comment: "Fecha de la Última Modificación del Registro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Roles");
        }
    }
}
