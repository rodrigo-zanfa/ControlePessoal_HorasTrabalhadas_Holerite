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
    [Migration("20220112024938_05SalarioMinimo")]
    partial class _05SalarioMinimo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Ausencia", b =>
                {
                    b.Property<int>("IdAusencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAusencia")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataHoraInclusao")
                        .HasColumnType("datetime");

                    b.Property<TimeSpan>("HoraFinalAusencia")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicialAusencia")
                        .HasColumnType("time");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdAusencia");

                    b.HasIndex("IdUsuario");

                    b.ToTable("APIAusencia");
                });

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

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Salario", b =>
                {
                    b.Property<int>("IdSalario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataHoraInclusao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataVigenciaInicial")
                        .HasColumnType("date");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(8,2)");

                    b.HasKey("IdSalario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("APISalario");
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.SalarioMinimo", b =>
                {
                    b.Property<int>("IdSalarioMinimo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataHoraInclusao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("DataVigenciaInicial")
                        .HasColumnType("date");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(8,2)");

                    b.HasKey("IdSalarioMinimo");

                    b.ToTable("APISalarioMinimo");

                    b.HasData(
                        new
                        {
                            IdSalarioMinimo = 1,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1994, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 64.79m
                        },
                        new
                        {
                            IdSalarioMinimo = 2,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 70m
                        },
                        new
                        {
                            IdSalarioMinimo = 3,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1995, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 100m
                        },
                        new
                        {
                            IdSalarioMinimo = 4,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 112m
                        },
                        new
                        {
                            IdSalarioMinimo = 5,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 120m
                        },
                        new
                        {
                            IdSalarioMinimo = 6,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 130m
                        },
                        new
                        {
                            IdSalarioMinimo = 7,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(1999, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 136m
                        },
                        new
                        {
                            IdSalarioMinimo = 8,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 151m
                        },
                        new
                        {
                            IdSalarioMinimo = 9,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2001, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 180m
                        },
                        new
                        {
                            IdSalarioMinimo = 10,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2002, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 200m
                        },
                        new
                        {
                            IdSalarioMinimo = 11,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 240m
                        },
                        new
                        {
                            IdSalarioMinimo = 12,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 260m
                        },
                        new
                        {
                            IdSalarioMinimo = 13,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2005, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 300m
                        },
                        new
                        {
                            IdSalarioMinimo = 14,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2006, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 350m
                        },
                        new
                        {
                            IdSalarioMinimo = 15,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2007, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 380m
                        },
                        new
                        {
                            IdSalarioMinimo = 16,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 415m
                        },
                        new
                        {
                            IdSalarioMinimo = 17,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2009, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 465m
                        },
                        new
                        {
                            IdSalarioMinimo = 18,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 510m
                        },
                        new
                        {
                            IdSalarioMinimo = 19,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 540m
                        },
                        new
                        {
                            IdSalarioMinimo = 20,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 545m
                        },
                        new
                        {
                            IdSalarioMinimo = 21,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 622m
                        },
                        new
                        {
                            IdSalarioMinimo = 22,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 678m
                        },
                        new
                        {
                            IdSalarioMinimo = 23,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 724m
                        },
                        new
                        {
                            IdSalarioMinimo = 24,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 788m
                        },
                        new
                        {
                            IdSalarioMinimo = 25,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 880m
                        },
                        new
                        {
                            IdSalarioMinimo = 26,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 937m
                        },
                        new
                        {
                            IdSalarioMinimo = 27,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 954m
                        },
                        new
                        {
                            IdSalarioMinimo = 28,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 998m
                        },
                        new
                        {
                            IdSalarioMinimo = 29,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 1039m
                        },
                        new
                        {
                            IdSalarioMinimo = 30,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 1045m
                        },
                        new
                        {
                            IdSalarioMinimo = 31,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 1100m
                        },
                        new
                        {
                            IdSalarioMinimo = 32,
                            DataHoraInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVigenciaInicial = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 1212m
                        });
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataHoraInclusao")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdUsuario");

                    b.ToTable("APIUsuario");
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Ausencia", b =>
                {
                    b.HasOne("ControlePessoal.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Ausencias")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Salario", b =>
                {
                    b.HasOne("ControlePessoal.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Salarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ControlePessoal.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Ausencias");

                    b.Navigation("Pontos");

                    b.Navigation("Salarios");
                });
#pragma warning restore 612, 618
        }
    }
}