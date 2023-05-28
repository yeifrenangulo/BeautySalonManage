﻿// <auto-generated />
using System;
using BeautySalonManage.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeautySalonManage.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230410164748_ModelInitial")]
    partial class ModelInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Collaborator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador Único del Colaborador");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Dirección del Colaborador");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación de Registro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Email del Colaborador");

                    b.Property<int>("GenderId")
                        .HasColumnType("int")
                        .HasComment("Género del Colaborador");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Estás Activo) (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Última Modificación de Registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Nombre del Colaborador");

                    b.Property<string>("NameContact")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Nombre de Contacto del Colaborador");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Teléfono del Colaborador");

                    b.Property<string>("PhoneContact")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Teléfono de Contacto del Colaborador");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Apellido del Colaborador");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "GenderId" }, "FK_CollaboratorGenderId");

                    b.HasIndex(new[] { "Name", "Surname" }, "IDX_CollaboratorsName")
                        .IsUnique();

                    b.ToTable("Collaborators", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.CollaboratorService", b =>
                {
                    b.Property<int>("CollaboratorId")
                        .HasColumnType("int")
                        .HasComment("Identificador del Colaborador");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasComment("Identificador del Servicio");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha Última Modificación del Registro");

                    b.Property<decimal>("Percentage")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasComment("Porcentaje del Servicio");

                    b.HasKey("CollaboratorId", "ServiceId")
                        .HasName("PK_CollaboratorServices");

                    b.HasIndex("ServiceId");

                    b.ToTable("CollaboratorServices", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador Único del Cliente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Regitro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<DateTime?>("DateBirth")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Nacimiento del Cliente");

                    b.Property<int>("GenderId")
                        .HasColumnType("int")
                        .HasComment("Género del Cliente");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de la Última Modificación del Regitro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la Última Modificación del Registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Nombre del Cliente");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Teléfono del Cliente");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Apellido del Cliente");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("Name", "Surname")
                        .IsUnique()
                        .HasDatabaseName("IDX_NameSurname");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador Único del Género");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Regitro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de la Última Modificación del Regitro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la Última Modificación del Registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Descripción del Género");

                    b.HasKey("Id");

                    b.ToTable("Genders", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.MenuOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador Único de la Opción de Menú");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Icono de la Opción");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de la Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la Última Modificación del Registro");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasComment("Orden de la Opción");

                    b.Property<int?>("ParentOption")
                        .HasColumnType("int")
                        .HasComment("Opción de Menú Padre");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Descripción de la Opción de Menú");

                    b.HasKey("Id");

                    b.ToTable("MenuOptions", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador Único del Servicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("")
                        .HasComment("Color Identificador del Servicio");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación de Registro");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Detalle del Servicio");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Duración del Servicio");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Estás Activo) (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Última Modificación de Registro");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio del Servicio");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Titulo del Servicio");

                    b.HasKey("Id");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador Único del Estado");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de la Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la Última Modificación del Registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Descripción del Estado");

                    b.HasKey("Id");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Turn", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Identificador Único del Turno");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasComment("Hora Final del Turno");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha Última Modificación del Registro");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Nombre del Cliente del Turno");

                    b.Property<string>("Observation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Observación del Turno");

                    b.Property<string>("PhoneCustomer")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Teléfono del Cliente del Turno");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasComment("Fecha del Turno");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasComment("Hora Inicial del Turno");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasComment("Identificador del Estado");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Turns", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.TurnAdditionalDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Identificador Único del Detalle Adicional del Turno");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Detalle del Turno");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha Última Modificación del Registro");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio detalle del Turno");

                    b.Property<long>("TurnId")
                        .HasColumnType("bigint")
                        .HasComment("Identificador del Turno");

                    b.HasKey("Id");

                    b.HasIndex("TurnId");

                    b.ToTable("TurnAdditionalDetails", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.TurnDetail", b =>
                {
                    b.Property<long>("TurnId")
                        .HasColumnType("bigint")
                        .HasComment("Identificador del Turno");

                    b.Property<int>("CollaboratorId")
                        .HasColumnType("int")
                        .HasComment("Identificador del Colaborador");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasComment("Identificador del Servicio");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Creación del Registro");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de Creación del Registro");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("¿Está Activo? (1 = Si, 0 = No)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Usuario de Última Modificación del Registro");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime")
                        .HasComment("Fecha Última Modificación del Registro");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio Servico del Turno");

                    b.HasKey("TurnId", "CollaboratorId", "ServiceId")
                        .HasName("PK_TurnDetails");

                    b.HasIndex("CollaboratorId");

                    b.HasIndex("ServiceId");

                    b.ToTable("TurnDetails", (string)null);
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Collaborator", b =>
                {
                    b.HasOne("BeautySalonManage.Domain.Entities.Gender", "Gender")
                        .WithMany("Collaborators")
                        .HasForeignKey("GenderId")
                        .IsRequired()
                        .HasConstraintName("Collaborator_GenderId_FK");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.CollaboratorService", b =>
                {
                    b.HasOne("BeautySalonManage.Domain.Entities.Collaborator", "Collaborator")
                        .WithMany("CollaboratorServices")
                        .HasForeignKey("CollaboratorId")
                        .IsRequired()
                        .HasConstraintName("CollaboratorServices_CollaboratorId_FK");

                    b.HasOne("BeautySalonManage.Domain.Entities.Service", "Service")
                        .WithMany("CollaboratorServices")
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("CollaboratorServices_ServiceId_FK");

                    b.Navigation("Collaborator");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Customer", b =>
                {
                    b.HasOne("BeautySalonManage.Domain.Entities.Gender", "Gender")
                        .WithMany("Customers")
                        .HasForeignKey("GenderId")
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Gender_GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Turn", b =>
                {
                    b.HasOne("BeautySalonManage.Domain.Entities.State", "Status")
                        .WithMany("Turns")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("TurnsStatus_FK");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.TurnAdditionalDetail", b =>
                {
                    b.HasOne("BeautySalonManage.Domain.Entities.Turn", "Turn")
                        .WithMany("TurnAdditionalDetails")
                        .HasForeignKey("TurnId")
                        .IsRequired()
                        .HasConstraintName("TurnAdditionalDetailsTurns_FK");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.TurnDetail", b =>
                {
                    b.HasOne("BeautySalonManage.Domain.Entities.Collaborator", "Collaborator")
                        .WithMany("TurnDetails")
                        .HasForeignKey("CollaboratorId")
                        .IsRequired()
                        .HasConstraintName("TurnDetailsCollaborator_FK");

                    b.HasOne("BeautySalonManage.Domain.Entities.Service", "Service")
                        .WithMany("TurnDetails")
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("TurnDetailsService_FK");

                    b.HasOne("BeautySalonManage.Domain.Entities.Turn", "Turn")
                        .WithMany("TurnDetails")
                        .HasForeignKey("TurnId")
                        .IsRequired()
                        .HasConstraintName("TurnDetailsTurn_FK");

                    b.Navigation("Collaborator");

                    b.Navigation("Service");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Collaborator", b =>
                {
                    b.Navigation("CollaboratorServices");

                    b.Navigation("TurnDetails");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Gender", b =>
                {
                    b.Navigation("Collaborators");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Service", b =>
                {
                    b.Navigation("CollaboratorServices");

                    b.Navigation("TurnDetails");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.State", b =>
                {
                    b.Navigation("Turns");
                });

            modelBuilder.Entity("BeautySalonManage.Domain.Entities.Turn", b =>
                {
                    b.Navigation("TurnAdditionalDetails");

                    b.Navigation("TurnDetails");
                });
#pragma warning restore 612, 618
        }
    }
}