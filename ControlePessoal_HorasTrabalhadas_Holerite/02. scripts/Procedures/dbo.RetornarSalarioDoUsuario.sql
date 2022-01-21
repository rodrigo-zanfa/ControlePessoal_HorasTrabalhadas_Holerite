
create or alter procedure dbo.RetornarSalarioDoUsuario
	@IdUsuario int,
	@Data date,
	@Salario numeric(8,2) output
as
declare @Sequencia int
declare @IdSalario int

select top 1
  @Sequencia = row_number() over (order by s.DataVigenciaInicial desc),
  @IdSalario = s.IdSalario
from dbo.APISalario s
where s.IdUsuario = @IdUsuario
  and s.DataVigenciaInicial <= @Data

print '@Sequencia = ' + cast(@Sequencia as varchar)
print '@IdSalario = ' + cast(@IdSalario as varchar)

select
  @Salario = s.Valor
from dbo.APISalario s
where s.IdSalario = @IdSalario
