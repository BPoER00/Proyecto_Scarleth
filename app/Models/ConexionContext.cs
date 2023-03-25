using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app.Models
{
    public class ConexionContext : DbContext
    {
        private readonly IConfiguration _config;

        public ConexionContext(IConfiguration _config)
        {
            this._config = _config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conexionString = this._config.GetConnectionString("NameConnectionString");

            //conect to sql server with connection string from appsettings.json
            options.UseSqlServer(conexionString);
        }

        //Dbset para integrar data a la base de datos
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Detalle_Vacuna> Detalle_Vacunas { get; set; }
        public DbSet<Detalle_Vacunacion> Detalle_Vacunacions { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<Etnia> Etnias { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Vacunacion> Vacunacions { get; set; }

    }
}