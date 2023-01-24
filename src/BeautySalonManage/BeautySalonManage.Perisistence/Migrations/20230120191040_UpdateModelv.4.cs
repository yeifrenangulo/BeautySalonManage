using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Perisistence.Migrations
{
    public partial class UpdateModelv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneContact",
                table: "Collaborators",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "Teléfono de Contacto del Colaborador",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Teléfono de Contacto del Colaborador");

            migrationBuilder.AlterColumn<string>(
                name: "NameContact",
                table: "Collaborators",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Nombre de Contacto del Colaborador",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Nombre de Contacto del Colaborador");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Collaborators",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Color Identificador del Colaborador");

            migrationBuilder.CreateTable(
                name: "CollaboratorServices",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Colaborador"),
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Servicio"),
                    Percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false, comment: "Porcentaje del Servicio"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorServices", x => new { x.CollaboratorId, x.ServiceId });
                    table.ForeignKey(
                        name: "CollaboratorServices_CollaboratorId_FK",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "CollaboratorId");
                    table.ForeignKey(
                        name: "CollaboratorServices_ServiceId_FK",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                },
                comment: "Información de Servicio por Colaborador");

            migrationBuilder.CreateTable(
                name: "TurnDetails",
                columns: table => new
                {
                    TurnId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador del Turno"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Colaborador"),
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Servicio"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio Servico del Turno"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnDetails", x => new { x.TurnId, x.CollaboratorId, x.ServiceId });
                    table.ForeignKey(
                        name: "TurnDetailsCollaborator_FK",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "CollaboratorId");
                    table.ForeignKey(
                        name: "TurnDetailsService_FK",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                    table.ForeignKey(
                        name: "TurnDetailsTurn_FK",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "TurnId");
                },
                comment: "Información del Detalle de los Turnos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Collaborators");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneContact",
                table: "Collaborators",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "Teléfono de Contacto del Colaborador",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Teléfono de Contacto del Colaborador");

            migrationBuilder.AlterColumn<string>(
                name: "NameContact",
                table: "Collaborators",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Nombre de Contacto del Colaborador",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Nombre de Contacto del Colaborador");
        }
    }
}
