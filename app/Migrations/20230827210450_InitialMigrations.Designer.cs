﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app.Models;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(ConexionContext))]
    [Migration("20230827210450_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("app.Models.Asignacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("cargo_id")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("numero_colegiado")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("persona_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Asignacions");
                });

            modelBuilder.Entity("app.Models.Cargo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.HasKey("id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("app.Models.Detalle_Vacuna", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("cantidad")
                        .HasColumnType("bigint");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<DateTime>("fecha_vencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.Property<int>("vacuna_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Detalle_Vacunas");
                });

            modelBuilder.Entity("app.Models.Detalle_Vacunacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("dosis")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_vacunacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.Property<int>("vacunacion_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Detalle_Vacunacions");
                });

            modelBuilder.Entity("app.Models.Direccion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.HasKey("id");

                    b.ToTable("Direccions");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4567),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Gualan"
                        },
                        new
                        {
                            id = 2,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4571),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "La Union"
                        },
                        new
                        {
                            id = 3,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4576),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Zacapa"
                        },
                        new
                        {
                            id = 4,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4580),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Rio Hondo"
                        },
                        new
                        {
                            id = 5,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4584),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Estanzuela"
                        },
                        new
                        {
                            id = 6,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4589),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Teculutan"
                        },
                        new
                        {
                            id = 7,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4593),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Usumatlan"
                        },
                        new
                        {
                            id = 8,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4597),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Huite"
                        },
                        new
                        {
                            id = 9,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4601),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Cabañas"
                        },
                        new
                        {
                            id = 10,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(4606),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "San Diego"
                        });
                });

            modelBuilder.Entity("app.Models.Genero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.HasKey("id");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(5059),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Masculino"
                        },
                        new
                        {
                            id = 2,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(5063),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Femenino"
                        });
                });

            modelBuilder.Entity("app.Models.Paciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("comunidad")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("cui")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("direccion_id")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("genero_id")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("app.Models.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("cui")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("direccion_id")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("genero_id")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("app.Models.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.HasKey("id");

                    b.ToTable("Rols");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(5103),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Administrador"
                        },
                        new
                        {
                            id = 2,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(5108),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Digitador"
                        },
                        new
                        {
                            id = 3,
                            CreateAt = new DateTime(2023, 8, 27, 15, 4, 49, 887, DateTimeKind.Local).AddTicks(5112),
                            DeleteAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            estado = 1,
                            nombre = "Usuario Comun"
                        });
                });

            modelBuilder.Entity("app.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre_usuario")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("persona_id")
                        .HasColumnType("int");

                    b.Property<int>("rol_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("app.Models.Vacuna", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("cubre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("dosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<long>("unidades")
                        .HasColumnType("bigint");

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("app.Models.Vacunacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("asignacion_id")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<long>("dosis")
                        .HasColumnType("bigint");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<int>("paciente_id")
                        .HasColumnType("int");

                    b.Property<int>("vacuna_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Vacunacions");
                });
#pragma warning restore 612, 618
        }
    }
}
