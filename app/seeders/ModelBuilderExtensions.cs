
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.seeders
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Etnia>()
                        .HasData(
                            new Etnia
                            {
                                id = 1,
                                nombre = "Maya",
                                estado = Etnia.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Etnia
                            {
                                id = 2,
                                nombre = "Ladino",
                                estado = Etnia.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Etnia
                            {
                                id = 3,
                                nombre = "Xinca",
                                estado = Etnia.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Etnia
                            {
                                id = 4,
                                nombre = "Afrodescendiente/Creole",
                                estado = Etnia.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Etnia
                            {
                                id = 5,
                                nombre = "Garifuna",
                                estado = Etnia.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Etnia
                            {
                                id = 6,
                                nombre = "Extranjero",
                                estado = Etnia.ACTIVO,
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
                            new Rol {
                                id = 1,
                                nombre = "Administrador",
                                estado = Rol.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Rol {
                                id = 2,
                                nombre = "Digitador",
                                estado = Rol.ACTIVO,
                                CreateAt = DateTime.Now
                            },
                            new Rol {
                                id = 3,
                                nombre = "Usuario Comun",
                                estado = Rol.ACTIVO,
                                CreateAt = DateTime.Now
                            }
                        );
        }
    }
}