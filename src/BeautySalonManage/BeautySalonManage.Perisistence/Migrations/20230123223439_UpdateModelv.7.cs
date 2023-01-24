using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Perisistence.Migrations
{
    public partial class UpdateModelv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurnAdditionalDetails",
                columns: table => new
                {
                    TurnAdditionalDetailId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único del Detalle Adicional del Turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnAdditionalDetails");
        }
    }
}
