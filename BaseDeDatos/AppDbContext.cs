using EntityFrameWork2.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork2.BaseDeDatos
{
    public class AppDbContext : DbContext  //Clase de Entity
    {
        public DbSet<Measurement_Unit> Measurement_Unit { get; set; }
        public AppDbContext() { } //Constructor por defecto de la clase

        //Método que es solo visible dentro de su mismo contexto y dentro de clases hijas, 
        //pero no accesible de instancias no heredadas.
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=jyjtechsolutions.com;Database=u481278819_estilos; User ID=u481278819_estyls; Password=Estilos24*;",
                new MySqlServerVersion(new Version (10,11,7)));
        }
    }
}
