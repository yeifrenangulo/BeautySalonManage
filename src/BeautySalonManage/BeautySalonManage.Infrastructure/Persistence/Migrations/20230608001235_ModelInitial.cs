using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Género")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción del Género"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Regitro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Regitro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único de la Opción de Menú")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción de la Opción de Menú"),
                    ParentOption = table.Column<int>(type: "int", nullable: true, comment: "Opción de Menú Padre"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Icono de la Opción"),
                    Order = table.Column<int>(type: "int", nullable: false, comment: "Orden de la Opción"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único de la Venta"),
                    NumberSale = table.Column<long>(type: "bigint", nullable: false, comment: "Número de Venta")
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Servicio")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Titulo del Servicio"),
                    Detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Detalle del Servicio"),
                    Duration = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Duración del Servicio"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio del Servicio"),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "", comment: "Color Identificador del Servicio"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Estás Activo) (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación de Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Última Modificación de Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Estado")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción del Estado"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Nombre del Usuario"),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Apellido del Usuario"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Email del Usuario"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Colaborador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Nombre del Colaborador"),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Apellido del Colaborador"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Colaborador"),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Dirección del Colaborador"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Email del Colaborador"),
                    NameContact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Nombre de Contacto del Colaborador"),
                    PhoneContact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Teléfono de Contacto del Colaborador"),
                    GenderId = table.Column<int>(type: "int", nullable: false, comment: "Género del Colaborador"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Estás Activo) (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación de Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Última Modificación de Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.Id);
                    table.ForeignKey(
                        name: "Collaborator_GenderId_FK",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Cliente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Nombre del Cliente"),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Apellido del Cliente"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Cliente"),
                    DateBirth = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Fecha de Nacimiento del Cliente"),
                    GenderId = table.Column<int>(type: "int", nullable: false, comment: "Género del Cliente"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Usuario de Creación del Regitro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Usuario de la Última Modificación del Regitro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único del Turno"),
                    NumberTurn = table.Column<long>(type: "bigint", nullable: false, comment: "Número de Turno")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha del Turno"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Hora Inicial del Turno"),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Hora Final del Turno"),
                    NameCustomer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Nombre del Cliente del Turno"),
                    PhoneCustomer = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Cliente del Turno"),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Observación del Turno"),
                    StateId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Estado"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.Id);
                    table.ForeignKey(
                        name: "TurnsStatus_FK",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "CollaboratorServices_ServiceId_FK",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleAdditionalDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único del Detalle Adicional de la Venta"),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador de la Venta"),
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
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador de la Venta"),
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
                name: "SettlementPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único de la Venta"),
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
                name: "TurnAdditionalDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único del Detalle Adicional del Turno"),
                    TurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador del Turno"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Colaborador"),
                    Detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Detalle del Turno"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio detalle del Turno"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnAdditionalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "TurnAdditionalDetailsCollaborators_FK",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TurnAdditionalDetailsTurns_FK",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TurnDetails",
                columns: table => new
                {
                    TurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador del Turno"),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TurnDetailsService_FK",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TurnDetailsTurn_FK",
                        column: x => x.TurnId,
                        principalTable: "Turns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettlementPaymentsDetails",
                columns: table => new
                {
                    SettlementPaymentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único de la Liquidación"),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Único de la Venta"),
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
                name: "FK_CollaboratorGenderId",
                table: "Collaborators",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IDX_CollaboratorsName",
                table: "Collaborators",
                columns: new[] { "Name", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorServices_ServiceId",
                table: "CollaboratorServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IDX_NameSurname",
                table: "Customers",
                columns: new[] { "Name", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GenderId",
                table: "Customers",
                column: "GenderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TurnAdditionalDetails_CollaboratorId",
                table: "TurnAdditionalDetails",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnAdditionalDetails_TurnId",
                table: "TurnAdditionalDetails",
                column: "TurnId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnDetails_CollaboratorId",
                table: "TurnDetails",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnDetails_ServiceId",
                table: "TurnDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_StateId",
                table: "Turns",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CollaboratorServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MenuOptions");

            migrationBuilder.DropTable(
                name: "SaleAdditionalDetails");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "SettlementPaymentsDetails");

            migrationBuilder.DropTable(
                name: "TurnAdditionalDetails");

            migrationBuilder.DropTable(
                name: "TurnDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SettlementPayments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
