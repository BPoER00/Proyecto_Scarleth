using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsFirst : Migration
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
                name: "Detalle_Vacunacions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacunacion_id = table.Column<int>(type: "int", nullable: false),
                    fecha_vacunacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dosis = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Vacunacions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cantidad = table.Column<long>(type: "bigint", nullable: false),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vacuna_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Vacunas", x => x.id);
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
                name: "Etnias",
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
                    table.PrimaryKey("PK_Etnias", x => x.id);
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
                name: "Medicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cui = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    numero_colegiado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cargo_id = table.Column<int>(type: "int", nullable: false),
                    id_direccion = table.Column<int>(type: "int", nullable: false),
                    etnia_id = table.Column<int>(type: "int", nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.id);
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
                    id_direccion = table.Column<int>(type: "int", nullable: false),
                    etnia_id = table.Column<int>(type: "int", nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id);
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
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    cui = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nombre_usuario = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    Sal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vacunacions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    medico_id = table.Column<int>(type: "int", nullable: false),
                    vacuna_id = table.Column<int>(type: "int", nullable: false),
                    paciente_id = table.Column<int>(type: "int", nullable: false),
                    dosis = table.Column<long>(type: "bigint", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunacions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    unidades = table.Column<int>(type: "int", nullable: false),
                    dosis = table.Column<int>(type: "int", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    cubre = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Detalle_Vacunacions");

            migrationBuilder.DropTable(
                name: "Detalle_Vacunas");

            migrationBuilder.DropTable(
                name: "Direccions");

            migrationBuilder.DropTable(
                name: "Etnias");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vacunacions");

            migrationBuilder.DropTable(
                name: "Vacunas");
        }
    }
}
