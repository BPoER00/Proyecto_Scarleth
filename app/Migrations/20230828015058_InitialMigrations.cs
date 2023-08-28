using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Direccions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    unidades = table.Column<long>(type: "bigint", nullable: false),
                    dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cubre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cui = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comunidad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    direccion_id = table.Column<int>(type: "int", nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Direccions_direccion_id",
                        column: x => x.direccion_id,
                        principalTable: "Direccions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cui = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    direccion_id = table.Column<int>(type: "int", nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personas_Direccions_direccion_id",
                        column: x => x.direccion_id,
                        principalTable: "Direccions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignacions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    persona_id = table.Column<int>(type: "int", nullable: false),
                    numero_colegiado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    cargo_id = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Asignacions_Cargos_cargo_id",
                        column: x => x.cargo_id,
                        principalTable: "Cargos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignacions_Personas_persona_id",
                        column: x => x.persona_id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    persona_id = table.Column<int>(type: "int", nullable: false),
                    nombre_usuario = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    rol_id = table.Column<int>(type: "int", nullable: false),
                    Sal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_persona_id",
                        column: x => x.persona_id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Rols_rol_id",
                        column: x => x.rol_id,
                        principalTable: "Rols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacunacions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    vacuna_id = table.Column<int>(type: "int", nullable: false),
                    persona_id = table.Column<int>(type: "int", nullable: false),
                    dosis = table.Column<long>(type: "bigint", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunacions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vacunacions_Personas_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Personas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vacunacions_Vacunas_vacuna_id",
                        column: x => x.vacuna_id,
                        principalTable: "Vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cantidad = table.Column<long>(type: "bigint", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vacuna_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Vacunas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detalle_Vacunas_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Vacunas_Vacunas_vacuna_id",
                        column: x => x.vacuna_id,
                        principalTable: "Vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Vacunacions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacunacion_id = table.Column<int>(type: "int", nullable: false),
                    fecha_vacunacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dosis = table.Column<int>(type: "int", nullable: false),
                    asignacion_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Vacunacions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detalle_Vacunacions_Asignacions_asignacion_id",
                        column: x => x.asignacion_id,
                        principalTable: "Asignacions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Vacunacions_Vacunacions_vacunacion_id",
                        column: x => x.vacunacion_id,
                        principalTable: "Vacunacions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Direccions",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gualan" },
                    { 2, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "La Union" },
                    { 3, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8885), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zacapa" },
                    { 4, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8890), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rio Hondo" },
                    { 5, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8894), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Estanzuela" },
                    { 6, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8898), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Teculutan" },
                    { 7, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Usumatlan" },
                    { 8, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Huite" },
                    { 9, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8910), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cabañas" },
                    { 10, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(8914), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "San Diego" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(9424), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Masculino" },
                    { 2, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(9428), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(9467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Administrador" },
                    { 2, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(9471), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Digitador" },
                    { 3, new DateTime(2023, 8, 27, 19, 50, 58, 442, DateTimeKind.Local).AddTicks(9475), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Usuario Comun" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_cargo_id",
                table: "Asignacions",
                column: "cargo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_persona_id",
                table: "Asignacions",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunacions_asignacion_id",
                table: "Detalle_Vacunacions",
                column: "asignacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunacions_vacunacion_id",
                table: "Detalle_Vacunacions",
                column: "vacunacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunas_usuario_id",
                table: "Detalle_Vacunas",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunas_vacuna_id",
                table: "Detalle_Vacunas",
                column: "vacuna_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_direccion_id",
                table: "Pacientes",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_genero_id",
                table: "Pacientes",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_direccion_id",
                table: "Personas",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_genero_id",
                table: "Personas",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_persona_id",
                table: "Usuarios",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_rol_id",
                table: "Usuarios",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunacions_paciente_id",
                table: "Vacunacions",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunacions_vacuna_id",
                table: "Vacunacions",
                column: "vacuna_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Vacunacions");

            migrationBuilder.DropTable(
                name: "Detalle_Vacunas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Asignacions");

            migrationBuilder.DropTable(
                name: "Vacunacions");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Direccions");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
