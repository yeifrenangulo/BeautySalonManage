using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalonManage.Perisistence.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Género")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción del Género"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Regitro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Regitro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                },
                comment: "Información de los Géneros (1 = Hombre, 2 = Mujer)");

            migrationBuilder.CreateTable(
                name: "MenuOptions",
                columns: table => new
                {
                    MenuOptionId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único de la Opción de Menú")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción de la Opción de Menú"),
                    ParentOption = table.Column<int>(type: "int", nullable: true, comment: "Opción de Menú Padre"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Icono de la Opción"),
                    Order = table.Column<int>(type: "int", nullable: false, comment: "Orden de la Opción"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOptions", x => x.MenuOptionId);
                },
                comment: "Información de las Opciones del Menú");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Rol")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción del Rol"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                },
                comment: "Información de los Roles");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Servicio")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Titulo del Servicio"),
                    Detail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Detalle del Servicio"),
                    Duration = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Duración del Servicio"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio del Servicio"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Estás Activo) (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación de Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Última Modificación de Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                },
                comment: "Información de los Servicios");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Estado")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción del Estado"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                },
                comment: "Información de los Estados");

            migrationBuilder.CreateTable(
                name: "TypeUsers",
                columns: table => new
                {
                    TypeUserId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Tipo de Usuario")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Descripción del Tipo de Usuario"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de la Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUsers", x => x.TypeUserId);
                },
                comment: "Información de los Tipos de Usuarios");

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Colaborador")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Nombre del Colaborador"),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Apellido del Colaborador"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Colaborador"),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Dirección del Colaborador"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Email del Colaborador"),
                    NameContact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Nombre de Contacto del Colaborador"),
                    PhoneContact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono de Contacto del Colaborador"),
                    GenderId = table.Column<int>(type: "int", nullable: false, comment: "Género del Colaborador"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Estás Activo) (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación de Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Última Modificación de Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.CollaboratorId);
                    table.ForeignKey(
                        name: "Collaborator_GenderId_FK",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId");
                },
                comment: "Información de los Colaboradores");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Cliente")
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
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId");
                },
                comment: "Información de los Clientes");

            migrationBuilder.CreateTable(
                name: "MenuOptionRoles",
                columns: table => new
                {
                    MenuOptionId = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la Opcion Menu"),
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Rol"),
                    AllowCreate = table.Column<bool>(type: "bit", nullable: false, comment: "Permite Crear en la Opción"),
                    AllowUpdate = table.Column<bool>(type: "bit", nullable: false, comment: "Permite Actualizar en la Opción"),
                    AllowRead = table.Column<bool>(type: "bit", nullable: false, comment: "Permite Consultar en la Opción"),
                    AllowRemove = table.Column<bool>(type: "bit", nullable: false, comment: "Permite Eliminar en la Opción"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MenuOptionId, x.RoleId });
                    table.ForeignKey(
                        name: "MenuOptionRoles_MenuOptionId_FK",
                        column: x => x.MenuOptionId,
                        principalTable: "MenuOptions",
                        principalColumn: "MenuOptionId");
                    table.ForeignKey(
                        name: "MenuOptionRoles_RoleId_FK",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                },
                comment: "Información de Opciones Rol");

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    TurnId = table.Column<long>(type: "bigint", nullable: false, comment: "Identificador Único del Turno"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha del Turno"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Hora Inicial del Turno"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Hora Final del Turno"),
                    NameCustomer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Nombre del Cliente del Turno"),
                    PhoneCustomer = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Teléfono del Cliente del Turno"),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio Total del Turno"),
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "Identificador Único del Usuario")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUserId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Tipo de Usuario"),
                    RelatedUser = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Login del Usuario"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Contraseña del Usuario"),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Correo Electrónico del Usuario"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Estás Activo) (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación de Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Última Modificación de Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "Users_FK",
                        column: x => x.TypeUserId,
                        principalTable: "TypeUsers",
                        principalColumn: "TypeUserId");
                },
                comment: "Información de los Usuarios");

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
                    table.PrimaryKey("PRIMARY", x => new { x.CollaboratorId, x.ServiceId });
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
                    table.PrimaryKey("PRIMARY", x => new { x.TurnId, x.CollaboratorId, x.ServiceId });
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

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Usuario"),
                    RoleId = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Rol"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "¿Está Activo? (1 = Si, 0 = No)"),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Creación del Registro"),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creación del Registro"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Usuario de Última Modificación del Registro"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha Última Modificación del Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "UserRoles_RoleId_FK",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "UserRoles_UserId_FK",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                },
                comment: "Información de los Roles de Usuarios");

            migrationBuilder.CreateIndex(
                name: "IDX_CollaboratorsName",
                table: "Collaborators",
                columns: new[] { "Name", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_NameSurname",
                table: "Customers",
                columns: new[] { "Name", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_un",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MenuOptionRoles");

            migrationBuilder.DropTable(
                name: "TurnAdditionalDetails");

            migrationBuilder.DropTable(
                name: "TurnDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "MenuOptions");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TypeUsers");
        }
    }
}
