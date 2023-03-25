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
    }
}