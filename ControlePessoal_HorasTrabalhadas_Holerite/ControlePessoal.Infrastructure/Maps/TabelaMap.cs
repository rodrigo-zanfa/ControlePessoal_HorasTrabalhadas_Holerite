using ControlePessoal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.Maps
{
    public class TabelaMap : IEntityTypeConfiguration<Tabela>
    {
        public void Configure(EntityTypeBuilder<Tabela> builder)
        {
            builder.ToTable("APITabela");

            builder.Property(x => x.IdTabela)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.IdTabelaTipo)
                .IsRequired();

            builder.Property(x => x.DataVigenciaInicial)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.DataHoraInclusao)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");  // usado apenas para a carga inicial de dados

            builder.Property(x => x.DataHoraAlteracao)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.HasKey(x => x.IdTabela);

            builder.HasOne(x => x.TabelaTipo)
                .WithMany(x => x.Tabelas)
                .HasForeignKey(x => x.IdTabelaTipo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Tabela(idTabela: 1, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1995, 01, 01), descricao: "INSS a partir de 01/1995"),
                new Tabela(idTabela: 2, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1995, 05, 01), descricao: "INSS a partir de 05/1995"),
                new Tabela(idTabela: 3, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1995, 08, 01), descricao: "INSS a partir de 08/1995"),
                new Tabela(idTabela: 4, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1996, 05, 01), descricao: "INSS a partir de 05/1996"),
                new Tabela(idTabela: 5, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1997, 01, 01), descricao: "INSS a partir de 01/1997"),
                new Tabela(idTabela: 6, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1997, 05, 01), descricao: "INSS a partir de 05/1997"),
                new Tabela(idTabela: 7, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1997, 06, 01), descricao: "INSS a partir de 06/1997"),
                new Tabela(idTabela: 8, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1998, 05, 01), descricao: "INSS a partir de 05/1998"),
                new Tabela(idTabela: 9, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1998, 06, 01), descricao: "INSS a partir de 06/1998"),
                new Tabela(idTabela: 10, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1998, 12, 01), descricao: "INSS a partir de 12/1998"),
                new Tabela(idTabela: 11, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1999, 01, 01), descricao: "INSS a partir de 01/1999"),
                new Tabela(idTabela: 12, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1999, 06, 01), descricao: "INSS a partir de 06/1999"),
                new Tabela(idTabela: 13, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(1999, 07, 01), descricao: "INSS a partir de 07/1999"),
                new Tabela(idTabela: 14, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2000, 04, 01), descricao: "INSS a partir de 04/2000"),
                new Tabela(idTabela: 15, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2000, 05, 01), descricao: "INSS a partir de 05/2000"),
                new Tabela(idTabela: 16, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2000, 06, 01), descricao: "INSS a partir de 06/2000"),
                new Tabela(idTabela: 17, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2000, 07, 01), descricao: "INSS a partir de 07/2000"),
                new Tabela(idTabela: 18, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2001, 03, 01), descricao: "INSS a partir de 03/2001"),
                new Tabela(idTabela: 19, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2001, 04, 01), descricao: "INSS a partir de 04/2001"),
                new Tabela(idTabela: 20, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2001, 06, 01), descricao: "INSS a partir de 06/2001"),
                new Tabela(idTabela: 21, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2002, 04, 01), descricao: "INSS a partir de 04/2002"),
                new Tabela(idTabela: 22, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2002, 06, 01), descricao: "INSS a partir de 06/2002"),
                new Tabela(idTabela: 23, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2003, 04, 01), descricao: "INSS a partir de 04/2003"),
                new Tabela(idTabela: 24, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2003, 06, 01), descricao: "INSS a partir de 06/2003"),
                new Tabela(idTabela: 25, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2004, 01, 01), descricao: "INSS a partir de 01/2004"),
                new Tabela(idTabela: 26, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2004, 05, 01), descricao: "INSS a partir de 05/2004"),
                new Tabela(idTabela: 27, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2005, 05, 01), descricao: "INSS a partir de 05/2005"),
                new Tabela(idTabela: 28, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2006, 04, 01), descricao: "INSS a partir de 04/2006"),
                new Tabela(idTabela: 29, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2006, 08, 01), descricao: "INSS a partir de 08/2006"),
                new Tabela(idTabela: 30, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2007, 04, 01), descricao: "INSS a partir de 04/2007"),
                new Tabela(idTabela: 31, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2008, 01, 01), descricao: "INSS a partir de 01/2008"),
                new Tabela(idTabela: 32, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2008, 03, 01), descricao: "INSS a partir de 03/2008"),
                new Tabela(idTabela: 33, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2009, 02, 01), descricao: "INSS a partir de 02/2009"),
                new Tabela(idTabela: 34, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2010, 01, 01), descricao: "INSS a partir de 01/2010"),
                new Tabela(idTabela: 35, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2010, 06, 01), descricao: "INSS a partir de 06/2010"),
                new Tabela(idTabela: 36, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2011, 01, 01), descricao: "INSS a partir de 01/2011"),
                new Tabela(idTabela: 37, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2011, 07, 01), descricao: "INSS a partir de 07/2011"),
                new Tabela(idTabela: 38, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2012, 01, 01), descricao: "INSS a partir de 01/2012"),
                new Tabela(idTabela: 39, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2013, 01, 01), descricao: "INSS a partir de 01/2013"),
                new Tabela(idTabela: 40, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2014, 01, 01), descricao: "INSS a partir de 01/2014"),
                new Tabela(idTabela: 41, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2015, 01, 01), descricao: "INSS a partir de 01/2015"),
                new Tabela(idTabela: 42, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2016, 01, 01), descricao: "INSS a partir de 01/2016"),
                new Tabela(idTabela: 43, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2017, 01, 01), descricao: "INSS a partir de 01/2017"),
                new Tabela(idTabela: 44, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2018, 01, 01), descricao: "INSS a partir de 01/2018"),
                new Tabela(idTabela: 45, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2019, 01, 01), descricao: "INSS a partir de 01/2019"),
                new Tabela(idTabela: 46, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2020, 01, 01), descricao: "INSS a partir de 01/2020"),
                new Tabela(idTabela: 47, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2020, 03, 01), descricao: "INSS a partir de 03/2020"),
                new Tabela(idTabela: 48, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2021, 01, 01), descricao: "INSS a partir de 01/2021"),
                new Tabela(idTabela: 49, idTabelaTipo: 1, dataVigenciaInicial: new DateTime(2022, 01, 01), descricao: "INSS a partir de 01/2022")/*,
                new Tabela(idTabela: , idTabelaTipo: , dataVigenciaInicial: new DateTime(, , ), descricao: ""),
                new Tabela(idTabela: , idTabelaTipo: , dataVigenciaInicial: new DateTime(, , ), descricao: ""),
                new Tabela(idTabela: , idTabelaTipo: , dataVigenciaInicial: new DateTime(, , ), descricao: ""),
                new Tabela(idTabela: , idTabelaTipo: , dataVigenciaInicial: new DateTime(, , ), descricao: "")*/
                );
        }
    }
}
