
create or alter procedure dbo.RetornarValorInssDoSalario
	@Data date,
	@Salario numeric(8,2),
	@ValorInss numeric(8,2) output
as
declare @Sequencia int
declare @IdTabela int

select top 1
  @Sequencia = row_number() over (order by t.DataVigenciaInicial desc),
  @IdTabela = t.IdTabela
from dbo.APITabela t
where t.IdTabelaTipo = 1  -- INSS
  and t.DataVigenciaInicial <= @Data

print '@Sequencia = ' + cast(@Sequencia as varchar)
print '@IdTabela = ' + cast(@IdTabela as varchar)

declare cursor_TabelaItens cursor keyset for
	select
	  ti.IntervaloInicial, ti.IntervaloFinal, ti.ValorAliquota
	from dbo.APITabela t
	  inner join dbo.APITabelaItem ti on t.IdTabela = ti.IdTabela
	where t.IdTabela = @IdTabela
	order by ti.IntervaloInicial
declare @IntervaloInicial numeric(8,2), @IntervaloFinal numeric(8,2), @ValorAliquota numeric(8,2)
declare @ValorFaixaTotal numeric(8,2)
declare @IntervaloFinalAnterior numeric(8,2) = 0

open cursor_TabelaItens

fetch first from cursor_TabelaItens into @IntervaloInicial, @IntervaloFinal, @ValorAliquota

while @@fetch_status = 0
begin
	set @ValorFaixaTotal = (@IntervaloFinal - @IntervaloFinalAnterior) * @ValorAliquota / 100

	if (@Salario >= @IntervaloFinal)  /* caso o salário seja maior que o limite da faixa, a referência de cálculo será o próprio valor calculado da faixa */
	begin
		set @ValorInss = @ValorInss + @ValorFaixaTotal
		print 'INSS - Faixa entre ' + cast(@IntervaloInicial as varchar) + ' e ' + cast(@IntervaloFinal as varchar) + ' - Alíquota ' + cast(@ValorAliquota as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorFaixaTotal as varchar) + ' - Valor Calculado para o Salário ' + cast(@ValorFaixaTotal as varchar)
	end
	else if (@Salario between @IntervaloInicial and @IntervaloFinal)  /* caso o salário esteja entre os intervalos da faixa, a referência de cálculo será o proporcional */
	begin
		declare @ValorFaixaParcial numeric(8,2) = (@Salario - @IntervaloFinalAnterior) * @ValorAliquota / 100
		set @ValorInss = @ValorInss + @ValorFaixaParcial
		print 'INSS - Faixa entre ' + cast(@IntervaloInicial as varchar) + ' e ' + cast(@IntervaloFinal as varchar) + ' - Alíquota ' + cast(@ValorAliquota as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorFaixaTotal as varchar) + ' - Valor Calculado para o Salário ' + cast(@ValorFaixaParcial as varchar)
	end
	else
	begin
		print 'INSS - Faixa entre ' + cast(@IntervaloInicial as varchar) + ' e ' + cast(@IntervaloFinal as varchar) + ' - Alíquota ' + cast(@ValorAliquota as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorFaixaTotal as varchar) + ' - Valor Calculado para o Salário ' + cast(0.00 as varchar)
	end

	set @IntervaloFinalAnterior = @IntervaloFinal

	fetch next from cursor_TabelaItens into @IntervaloInicial, @IntervaloFinal, @ValorAliquota
end

close cursor_TabelaItens

deallocate cursor_TabelaItens
