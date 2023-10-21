using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class CambiosApp : Migration
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
                    dosis = table.Column<long>(type: "bigint", nullable: false),
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
                name: "Detalle_Vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cantidad = table.Column<long>(type: "bigint", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vacuna_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Vacunas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detalle_Vacunas_Vacunas_vacuna_id",
                        column: x => x.vacuna_id,
                        principalTable: "Vacunas",
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
                    numero_colegiado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
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
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunacions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vacunacions_Personas_persona_id",
                        column: x => x.persona_id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacunacions_Vacunas_vacuna_id",
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
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(2108), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gualan" },
                    { 2, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(2155), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "La Union" },
                    { 3, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(2198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zacapa" },
                    { 4, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(2241), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rio Hondo" },
                    { 5, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(3452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Estanzuela" },
                    { 6, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(3559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Teculutan" },
                    { 7, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(3653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Usumatlan" },
                    { 8, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(3762), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Huite" },
                    { 9, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(3811), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cabañas" },
                    { 10, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(3854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "San Diego" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(4813), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Masculino" },
                    { 2, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(4856), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(4942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Administrador" },
                    { 2, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(4985), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Digitador" },
                    { 3, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(5036), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Usuario Comun" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "cui", "direccion_id", "estado", "fecha_nacimiento", "genero_id", "nombre", "telefono" },
                values: new object[] { 1, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(5161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "111111111111", 5, 2, new DateTime(2000, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Usuario Administrador", "55353553" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "CreateAt", "DeleteAt", "UpdateAt", "correo", "estado", "nombre_usuario", "password", "persona_id", "rol_id" },
                values: new object[] { 1, new DateTime(2023, 10, 21, 0, 11, 11, 487, DateTimeKind.Local).AddTicks(5496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pazbryan32@gmail.com", 1, "admin", "$2a$11$sdQk9j2YRZp5.MFcX6r8HeCUhhOJRGuYJ/Izi9g4iutDEzxHtTOr6", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_cargo_id",
                table: "Asignacions",
                column: "cargo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_persona_id",
                table: "Asignacions",
                column: "persona_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_nombre",
                table: "Cargos",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunacions_asignacion_id",
                table: "Detalle_Vacunacions",
                column: "asignacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunacions_vacunacion_id",
                table: "Detalle_Vacunacions",
                column: "vacunacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Vacunas_vacuna_id",
                table: "Detalle_Vacunas",
                column: "vacuna_id");

            migrationBuilder.CreateIndex(
                name: "IX_Direccions_nombre",
                table: "Direccions",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_nombre",
                table: "Generos",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_cui",
                table: "Personas",
                column: "cui",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_direccion_id",
                table: "Personas",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_genero_id",
                table: "Personas",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rols_nombre",
                table: "Rols",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_correo",
                table: "Usuarios",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_nombre_usuario",
                table: "Usuarios",
                column: "nombre_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_persona_id",
                table: "Usuarios",
                column: "persona_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_rol_id",
                table: "Usuarios",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunacions_persona_id",
                table: "Vacunacions",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunacions_vacuna_id",
                table: "Vacunacions",
                column: "vacuna_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_nombre",
                table: "Vacunas",
                column: "nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Vacunacions");

            migrationBuilder.DropTable(
                name: "Detalle_Vacunas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Asignacions");

            migrationBuilder.DropTable(
                name: "Vacunacions");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Direccions");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
