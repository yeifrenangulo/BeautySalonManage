using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Perisistence.Migrations
{
    public partial class UpdateModelv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    TurnId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único del Turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Fecha del Turno"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Hora Inicial del Turno"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Hora Final del Turno"),
                    NameCustomer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Nombre del Cliente del Turno"),
                    PhoneCustomer = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Cliente del Turno"),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Observación del Turno"),
                    StatusId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Estado"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.TurnId);
                    table.ForeignKey(
                        name: "TurnsStatus_FK",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                },
                comment: "Información de los Turnos");

            migrationBuilder.CreateTable(
                name: "TurnAdditionalDetails",
                columns: table => new
                {
                    TurnAdditionalDetailId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único del Detalle Adicional del Turno"),
                    TurnId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador del Turno"),
                    Detail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Detalle del Turno"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio detalle del Turno"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnAdditionalDetails", x => x.TurnAdditionalDetailId);
                    table.ForeignKey(
                        name: "TurnAdditionalDetailsTurns_FK",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "TurnId");
                },
                comment: "Información de los Detalles Adicionales de los Turnos");

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
            migrationBuilder.DropTable(
                name: "TurnAdditionalDetails");

            migrationBuilder.DropTable(
                name: "TurnDetails");

            migrationBuilder.DropTable(
                name: "Turns");
        }
    }
}
