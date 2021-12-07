using ControlePessoal.Data.Maps;
using ControlePessoal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ponto> Pontos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=PLANTDEV;Database=FuncionalPlant;User ID=appFuncPlant;Password=@Plant2017");
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ControlePessoal;User ID=sa;Password=q1w2e3r4t5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PontoMap());
        }
    }
}
