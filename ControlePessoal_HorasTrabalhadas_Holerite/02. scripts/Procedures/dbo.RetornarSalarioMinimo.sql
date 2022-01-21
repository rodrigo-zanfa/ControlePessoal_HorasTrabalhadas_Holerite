
create or alter procedure dbo.RetornarSalarioMinimo
	@Data date,
	@SalarioMinimo numeric(8,2) output
as
declare @Sequencia int
declare @IdSalarioMinimo int

select top 1
  @Sequencia = row_number() over (order by sm.DataVigenciaInicial desc),
  @IdSalarioMinimo = sm.IdSalarioMinimo
from dbo.APISalarioMinimo sm
where sm.DataVigenciaInicial <= @Data

print '@Sequencia = ' + cast(@Sequencia as varchar)
print '@IdSalarioMinimo = ' + cast(@IdSalarioMinimo as varchar)

select
  @SalarioMinimo = sm.Valor
from dbo.APISalarioMinimo sm
where sm.IdSalarioMinimo = @IdSalarioMinimo
