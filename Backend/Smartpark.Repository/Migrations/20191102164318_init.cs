using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Smartpark.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Contraseña = table.Column<string>(nullable: true),
                    Nombre_adm = table.Column<string>(nullable: true),
                    Apellido_adm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cajeros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Contraseña = table.Column<string>(nullable: true),
                    Nombre_Cajero = table.Column<string>(nullable: true),
                    Apellido_Cajero = table.Column<string>(nullable: true),
                    Fecha_ingreso = table.Column<DateTime>(nullable: false),
                    Turno_Cajero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cajeros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Tipo_servicio = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo_servicio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Monto = table.Column<int>(nullable: false),
                    Tipo_vehiculo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre_estacionamiento = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Localizacion = table.Column<string>(nullable: true),
                    administradorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkings_Administradores_administradorId",
                        column: x => x.administradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TarifaId = table.Column<int>(nullable: false),
                    CajeroId = table.Column<int>(nullable: false),
                    Placa = table.Column<string>(nullable: true),
                    HInicio = table.Column<DateTime>(nullable: false),
                    EspacioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Cajeros_CajeroId",
                        column: x => x.CajeroId,
                        principalTable: "Cajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingresos_Tarifas_TarifaId",
                        column: x => x.TarifaId,
                        principalTable: "Tarifas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Espacios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Identificador = table.Column<string>(nullable: true),
                    Disponibilidad_espacio = table.Column<bool>(nullable: false),
                    id_parking = table.Column<int>(nullable: false),
                    parkingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espacios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Espacios_Parkings_parkingId",
                        column: x => x.parkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cod_ingreso = table.Column<int>(nullable: false),
                    IngresoId = table.Column<int>(nullable: true),
                    horaIni = table.Column<DateTime>(nullable: false),
                    horaFin = table.Column<DateTime>(nullable: false),
                    monto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Ingresos_IngresoId",
                        column: x => x.IngresoId,
                        principalTable: "Ingresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngresoServicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ingresoId = table.Column<int>(nullable: false),
                    servicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoServicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngresoServicios_Ingresos_ingresoId",
                        column: x => x.ingresoId,
                        principalTable: "Ingresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngresoServicios_Servicios_servicioId",
                        column: x => x.servicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_IngresoId",
                table: "Comprobantes",
                column: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Espacios_parkingId",
                table: "Espacios",
                column: "parkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_CajeroId",
                table: "Ingresos",
                column: "CajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_TarifaId",
                table: "Ingresos",
                column: "TarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoServicios_ingresoId",
                table: "IngresoServicios",
                column: "ingresoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoServicios_servicioId",
                table: "IngresoServicios",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_administradorId",
                table: "Parkings",
                column: "administradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "Espacios");

            migrationBuilder.DropTable(
                name: "IngresoServicios");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Cajeros");

            migrationBuilder.DropTable(
                name: "Tarifas");
        }
    }
}
