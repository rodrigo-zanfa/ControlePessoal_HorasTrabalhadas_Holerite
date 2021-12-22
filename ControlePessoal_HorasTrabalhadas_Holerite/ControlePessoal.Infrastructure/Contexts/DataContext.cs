﻿using ControlePessoal.Domain.Entities;
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
        //public DbSet<Ponto> Pontos { get; set; }
        //public DbSet<Ausencia> Ausencias { get; set; }

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

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new PontoMap());
            //modelBuilder.ApplyConfiguration(new AusenciaMap());
        }
    }
}