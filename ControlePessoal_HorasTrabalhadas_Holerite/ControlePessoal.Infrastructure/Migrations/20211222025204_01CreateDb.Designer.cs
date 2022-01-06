﻿// <auto-generated />
using System;
using ControlePessoal.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlePessoal.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211222025204_01CreateDb")]
    partial class _01CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Ponto", b =>
                {
                    b.Property<int>("IdPonto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataHoraInclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataPonto")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraPonto")
                        .HasColumnType("time");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPonto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("APIPonto");
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdUsuario");

                    b.ToTable("APIUsuario");
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Ponto", b =>
                {
                    b.HasOne("ControlePessoal.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Pontos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Pontos");
                });
#pragma warning restore 612, 618
        }
    }
}
