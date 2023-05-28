using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Turns",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Turns_StatusId",
                table: "Turns",
                newName: "IX_Turns_StateId");

            migrationBuilder.AddColumn<int>(
                name: "CollaboratorId",
                table: "TurnAdditionalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identificador del Colaborador");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único de la Venta")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSale = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha del Turno"),
                    NameCustomer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Nombre del Cliente de la Venta"),
                    PhoneCustomer = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Cliente de la Venta"),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Observación de la Venta"),
                    Amount = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false, comment: "Monto de la Venta"),
                    TurnId = table.Column<long>(type: "bigint", nullable: true, comment: "Turno asociado a la Vente"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettlementPayments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único de la Venta")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Colaborador"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Inicio de la Liquidación"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Fin de la Liquidación"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Monto de la Venta"),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Observación de la Venta"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettlementPaymentsCollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleAdditionalDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único del Detalle Adicional de la Venta")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador de la Venta"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Colaborador"),
                    Detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Detalle de la Venta"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio detalle de la Venta"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleAdditionalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "SaleAdditionalDetailsCollaborators_FK",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SaleAdditionalDetailsSales_FK",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleDetails",
                columns: table => new
                {
                    SaleId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador de la Venta"),
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
                    table.PrimaryKey("PK_SaleDetails", x => new { x.SaleId, x.CollaboratorId, x.ServiceId });
                    table.ForeignKey(
                        name: "SaleDetailsCollaborator_FK",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SaleDetailsService_FK",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SaleDetailsTurn_FK",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettlementPaymentsDetails",
                columns: table => new
                {
                    SettlementPaymentsId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único de la Liquidación"),
                    SaleId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único de la Venta"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementPaymentsDetails", x => new { x.SettlementPaymentsId, x.SaleId });
                    table.ForeignKey(
                        name: "FK_SettlementPaymentsDetailsSaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SettlementPaymentsDetailsettlementPaymentsId",
                        column: x => x.SettlementPaymentsId,
                        principalTable: "SettlementPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurnAdditionalDetails_CollaboratorId",
                table: "TurnAdditionalDetails",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAdditionalDetails_CollaboratorId",
                table: "SaleAdditionalDetails",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAdditionalDetails_SaleId",
                table: "SaleAdditionalDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_CollaboratorId",
                table: "SaleDetails",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_ServiceId",
                table: "SaleDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPayments_CollaboratorId",
                table: "SettlementPayments",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementPaymentsDetails_SaleId",
                table: "SettlementPaymentsDetails",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "TurnAdditionalDetailsCollaborators_FK",
                table: "TurnAdditionalDetails",
                column: "CollaboratorId",
                principalTable: "Collaborators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "TurnAdditionalDetailsCollaborators_FK",
                table: "TurnAdditionalDetails");

            migrationBuilder.DropTable(
                name: "SaleAdditionalDetails");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "SettlementPaymentsDetails");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SettlementPayments");

            migrationBuilder.DropIndex(
                name: "IX_TurnAdditionalDetails_CollaboratorId",
                table: "TurnAdditionalDetails");

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                table: "TurnAdditionalDetails");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Turns",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Turns_StateId",
                table: "Turns",
                newName: "IX_Turns_StatusId");
        }
    }
}
