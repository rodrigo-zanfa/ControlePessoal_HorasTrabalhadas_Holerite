
create or alter procedure dbo.RetornarValorIrrfDoSalario
	@Data date,
	@Salario numeric(8,2),
	@ValorInss numeric(8,2),
	@QuantidadeDependentes int,
	@ValorIrrf numeric(8,2) output,
	@CalculoUsandoCursor bit = 0
as
declare @Sequencia int
declare @IdTabela int

select top 1
  @Sequencia = row_number() over (order by t.DataVigenciaInicial desc),
  @IdTabela = t.IdTabela
from dbo.APITabela t
where t.IdTabelaTipo = 2  -- IRRF
  and t.DataVigenciaInicial <= @Data

print '@Sequencia = ' + cast(@Sequencia as varchar)
print '@IdTabela = ' + cast(@IdTabela as varchar)

if (@CalculoUsandoCursor = 1)  /* realizar o cálculo da mesma forma como calculado o INSS, usando cursor */
begin
	declare cursor_TabelaItens cursor keyset for
		select
		  ti.IntervaloInicial, ti.IntervaloFinal, ti.ValorAliquota, t.ValorDeducaoDependente
		from dbo.APITabela t
		  inner join dbo.APITabelaItem ti on t.IdTabela = ti.IdTabela
		where t.IdTabela = @IdTabela
		order by ti.IntervaloInicial
	declare @IntervaloInicial numeric(8,2), @IntervaloFinal numeric(8,2), @ValorAliquota numeric(8,2), @ValorDeducaoDependente numeric(8,2)
	declare @ValorFaixaTotal numeric(8,2)
	declare @IntervaloFinalAnterior numeric(8,2) = 0

	open cursor_TabelaItens

	fetch first from cursor_TabelaItens into @IntervaloInicial, @IntervaloFinal, @ValorAliquota, @ValorDeducaoDependente

	print 'Salário Bruto .....................: ' + cast(@Salario as varchar)
	print 'Dedução do INSS ...................: ' + cast(@ValorInss as varchar)
	print 'Dedução por Dependente ............: ' + cast(@ValorDeducaoDependente as varchar)
	print 'Quantidade de Dependentes .........: ' + cast(@QuantidadeDependentes as varchar)
	declare @ValorTotalDeducao numeric(8,2) = @ValorDeducaoDependente * @QuantidadeDependentes
	print 'Dedução Total por Dependentes .....: ' + cast(@ValorTotalDeducao as varchar)
	declare @SalarioBaseIrrf numeric(8,2) = @Salario - @ValorInss - @ValorTotalDeducao
	print 'Salário Base para IRRF ............: ' + cast(@SalarioBaseIrrf as varchar)

	while @@fetch_status = 0
	begin
		set @ValorFaixaTotal = (@IntervaloFinal - @IntervaloFinalAnterior) * @ValorAliquota / 100

		if (@SalarioBaseIrrf >= @IntervaloFinal)  /* caso o salário seja maior que o limite da faixa, a referência de cálculo será o próprio valor calculado da faixa */
		begin
			set @ValorIrrf = @ValorIrrf + @ValorFaixaTotal
			print 'IRRF - Faixa entre ' + cast(@IntervaloInicial as varchar) + ' e ' + cast(@IntervaloFinal as varchar) + ' - Alíquota ' + cast(@ValorAliquota as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorFaixaTotal as varchar) + ' - Valor Calculado para o Salário ' + cast(@ValorFaixaTotal as varchar)
		end
		else if (@SalarioBaseIrrf between @IntervaloInicial and @IntervaloFinal)  /* caso o salário esteja entre os intervalos da faixa, a referência de cálculo será o proporcional */
		begin
			declare @ValorFaixaParcial numeric(8,2) = (@SalarioBaseIrrf - @IntervaloFinalAnterior) * @ValorAliquota / 100
			set @ValorIrrf = @ValorIrrf + @ValorFaixaParcial
			print 'IRRF - Faixa entre ' + cast(@IntervaloInicial as varchar) + ' e ' + cast(@IntervaloFinal as varchar) + ' - Alíquota ' + cast(@ValorAliquota as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorFaixaTotal as varchar) + ' - Valor Calculado para o Salário ' + cast(@ValorFaixaParcial as varchar)
		end
		else
		begin
			print 'IRRF - Faixa entre ' + cast(@IntervaloInicial as varchar) + ' e ' + cast(@IntervaloFinal as varchar) + ' - Alíquota ' + cast(@ValorAliquota as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorFaixaTotal as varchar) + ' - Valor Calculado para o Salário ' + cast(0.00 as varchar)
		end

		set @IntervaloFinalAnterior = @IntervaloFinal

		fetch next from cursor_TabelaItens into @IntervaloInicial, @IntervaloFinal, @ValorAliquota, @ValorDeducaoDependente
	end

	close cursor_TabelaItens

	deallocate cursor_TabelaItens
end
else if (@CalculoUsandoCursor = 0)  /* realizar o cálculo apenas enquadrando o @SalarioBaseIrrf entre os intervalos inicial e final da tabela, aplicando a alíquota e subtraindo a dedução */
begin
	declare @ValorDeducaoDependente2 numeric(8,2), @IntervaloInicial2 numeric(8,2), @IntervaloFinal2 numeric(8,2), @ValorAliquota2 numeric(8,2), @ValorDeducao2 numeric(8,2)

	select
	  @ValorDeducaoDependente2 = t.ValorDeducaoDependente
	from dbo.APITabela t
	where t.IdTabela = @IdTabela

	print 'Salário Bruto .....................: ' + cast(@Salario as varchar)
	print 'Dedução do INSS ...................: ' + cast(@ValorInss as varchar)
	print 'Dedução por Dependente ............: ' + cast(@ValorDeducaoDependente2 as varchar)
	print 'Quantidade de Dependentes .........: ' + cast(@QuantidadeDependentes as varchar)
	declare @ValorTotalDeducao2 numeric(8,2) = @ValorDeducaoDependente2 * @QuantidadeDependentes
	print 'Dedução Total por Dependentes .....: ' + cast(@ValorTotalDeducao2 as varchar)
	declare @SalarioBaseIrrf2 numeric(8,2) = @Salario - @ValorInss - @ValorTotalDeducao2
	print 'Salário Base para IRRF ............: ' + cast(@SalarioBaseIrrf2 as varchar)

	select
	  @IntervaloInicial2 = ti.IntervaloInicial,
	  @IntervaloFinal2 = ti.IntervaloFinal,
	  @ValorAliquota2 = ti.ValorAliquota,
	  @ValorDeducao2 = ti.ValorDeducao
	from dbo.APITabela t
	  inner join dbo.APITabelaItem ti on t.IdTabela = ti.IdTabela
	where t.IdTabela = @IdTabela
	  and @SalarioBaseIrrf2 between ti.IntervaloInicial and ti.IntervaloFinal

	declare @ValorCalculadoFaixa numeric(8,2) = @SalarioBaseIrrf2 * @ValorAliquota2 / 100
	set @ValorIrrf = @ValorCalculadoFaixa - @ValorDeducao2
	print 'IRRF - Faixa entre ' + cast(@IntervaloInicial2 as varchar) + ' e ' + cast(@IntervaloFinal2 as varchar) + ' - Alíquota ' + cast(@ValorAliquota2 as varchar) + '% - Valor Calculado da Faixa ' + cast(@ValorCalculadoFaixa as varchar) + ' - Valor Dedução da Faixa ' + cast(@ValorDeducao2 as varchar) + ' - Valor Calculado para o Salário ' + cast(@ValorIrrf as varchar)
end
