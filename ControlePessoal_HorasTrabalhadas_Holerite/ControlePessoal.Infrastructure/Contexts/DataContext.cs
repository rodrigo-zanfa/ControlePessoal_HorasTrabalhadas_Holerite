using ControlePessoal.Domain.Entities;
using ControlePessoal.Infrastructure.Maps;
using Core.CQRS.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Ausencia> Ausencias { get; set; }
        public DbSet<Salario> Salarios { get; set; }
        public DbSet<SalarioMinimo> SalariosMinimos { get; set; }
        public DbSet<ParametroTipoDado> ParametrosTiposDados { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<ParametroUsuario> ParametrosUsuarios { get; set; }
        public DbSet<TabelaTipo> TabelasTipos { get; set; }
        public DbSet<Tabela> Tabelas { get; set; }
        public DbSet<TabelaItem> TabelasItens { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=PLANTDEV;Database=FuncionalPlant;User ID=appFuncPlant;Password=@Plant2017");
        //    optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ControlePessoal2;User ID=sa;Password=q1w2e3r4t5");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();  // se somente este, o TempId será gerado erroneamente
            //modelBuilder.Ignore<Entity>();  // se somente este, erro ao gerar (The entity type 'Notification' requires a primary key to be defined.); se Notification + Entity, o TempId será gerado erroneamente
            modelBuilder.Ignore<Usuario>();  // se somente este, erro ao gerar (The entity type 'Notification' requires a primary key to be defined.); se Notification + Usuario, SUCESSO!
            modelBuilder.Ignore<Ponto>();
            modelBuilder.Ignore<Ausencia>();
            modelBuilder.Ignore<Salario>();
            modelBuilder.Ignore<SalarioMinimo>();
            modelBuilder.Ignore<ParametroTipoDado>();
            modelBuilder.Ignore<Parametro>();
            modelBuilder.Ignore<ParametroUsuario>();
            modelBuilder.Ignore<TabelaTipo>();
            modelBuilder.Ignore<Tabela>();
            modelBuilder.Ignore<TabelaItem>();

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PontoMap());
            modelBuilder.ApplyConfiguration(new AusenciaMap());
            modelBuilder.ApplyConfiguration(new SalarioMap());
            modelBuilder.ApplyConfiguration(new SalarioMinimoMap());
            modelBuilder.ApplyConfiguration(new ParametroTipoDadoMap());
            modelBuilder.ApplyConfiguration(new ParametroMap());
            modelBuilder.ApplyConfiguration(new ParametroUsuarioMap());
            modelBuilder.ApplyConfiguration(new TabelaTipoMap());
            modelBuilder.ApplyConfiguration(new TabelaMap());
            modelBuilder.ApplyConfiguration(new TabelaItemMap());
        }
    }
}
