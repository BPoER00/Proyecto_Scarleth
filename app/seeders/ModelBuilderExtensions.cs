
using System.Runtime.CompilerServices;
using app.helpers;
using app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace app.seeders
{
    public static class ModelBuilderExtensions
    {


        public static void Seed(this ModelBuilder modelBuilder)
        {

            var hash = new PasswordHasherService().HashPassword("12345678");

            //Direccion Data
            modelBuilder.Entity<Direccion>()
                        .HasData(
                            new Direccion
                            {
                                id = 1,
                                nombre = "Gualan",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 2,
                                nombre = "La Union",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 3,
                                nombre = "Zacapa",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 4,
                                nombre = "Rio Hondo",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 5,
                                nombre = "Estanzuela",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 6,
                                nombre = "Teculutan",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 7,
                                nombre = "Usumatlan",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 8,
                                nombre = "Huite",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 9,
                                nombre = "Cabañas",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Direccion
                            {
                                id = 10,
                                nombre = "San Diego",
                                estado = Direccion.ACTIVO,
                                CreateAt = DateTime.Now
                            }
                        );

            modelBuilder.Entity<Genero>()
                        .HasData(
                            new Genero
                            {
                                id = 1,
                                nombre = "Masculino",
                                estado = Genero.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Genero
                            {
                                id = 2,
                                nombre = "Femenino",
                                estado = Genero.ACTIVO,
                                CreateAt = DateTime.Now
                            }
                        );

            modelBuilder.Entity<Rol>()
                        .HasData(
                            new Rol
                            {
                                id = 1,
                                nombre = "Administrador",
                                estado = Rol.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Rol
                            {
                                id = 2,
                                nombre = "Digitador",
                                estado = Rol.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Rol
                            {
                                id = 3,
                                nombre = "Usuario Comun",
                                estado = Rol.ACTIVO,
                                CreateAt = DateTime.Now
                            }
                        );

            modelBuilder.Entity<Persona>()
                        .HasData(
                            new Persona
                            {
                                id = 1,
                                nombre = "Usuario Administrador",
                                cui = "111111111111",
                                telefono = "55353553",
                                fecha_nacimiento = DateTime.Parse("10-26-2000"),
                                direccion_id = 5,
                                genero_id = 1,
                                estado = 2
                            }
                        );

            modelBuilder.Entity<Usuario>()
                        .HasData(
                            new Usuario
                            {
                                id = 1,
                                persona_id = 1,
                                nombre_usuario = "admin",
                                correo = "pazbryan32@gmail.com",
                                password = hash,
                                rol_id = 1
                            }
                        );
        }
    }
}