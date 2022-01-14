
create or alter procedure dbo.RetornarParametroDoUsuario
	@IdParametro int,
	@IdUsuario int,
	@Data date,
	@Valor varchar(30) output
as
declare @Sequencia int
declare @IdParametroUsuario int

select top 1
  @Sequencia = row_number() over (order by pu.DataVigenciaInicial desc),
  @IdParametroUsuario = pu.IdParametroUsuario
from dbo.APIParametroUsuario pu
where pu.IdParametro = @IdParametro
  and pu.IdUsuario = @IdUsuario
  and pu.DataVigenciaInicial <= @Data

print '@Sequencia = ' + cast(@Sequencia as varchar)
print '@IdParametroUsuario = ' + cast(@IdParametroUsuario as varchar)

select
  @Valor = pu.Valor
from dbo.APIParametroUsuario pu
where pu.IdParametroUsuario = @IdParametroUsuario
