
declare @DataInicial date = '2021-11-15'
declare @DataFinal date = '2022-01-14'
declare @IdUsuario int = 1

declare @Valor varchar(30) = ''


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* retornando os parâmetros necessários                                                                                                                                           */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

/* 01. Horário de Entrada                                                                                                                                                         */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

exec dbo.RetornarParametroDoUsuario 1, @IdUsuario, @DataFinal, @Valor output
print '@Valor = ' + @Valor

declare @HorarioEntrada time = cast(@Valor as time)
print '@HorarioEntrada = ' + cast(@HorarioEntrada as varchar)

/* 02. Horário de Saída                                                                                                                                                           */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

exec dbo.RetornarParametroDoUsuario 2, @IdUsuario, @DataFinal, @Valor output
print '@Valor = ' + @Valor

declare @HorarioSaida time = cast(@Valor as time)
print '@HorarioSaida = ' + cast(@HorarioSaida as varchar)

/* 03. Intervalo Diário                                                                                                                                                           */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

exec dbo.RetornarParametroDoUsuario 3, @IdUsuario, @DataFinal, @Valor output
print '@Valor = ' + @Valor

declare @IntervaloDiario time = cast(@Valor as time)
print '@IntervaloDiario = ' + cast(@IntervaloDiario as varchar)

declare @HorasDiarias time = cast(@HorarioSaida as datetime) - cast(@HorarioEntrada as datetime) - cast(@IntervaloDiario as datetime)
print '@HorasDiarias = ' + cast(@HorasDiarias as varchar)

/* 04. Tolerância Diária                                                                                                                                                          */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

exec dbo.RetornarParametroDoUsuario 4, @IdUsuario, @DataFinal, @Valor output
print '@Valor = ' + @Valor

declare @Tolerancia time = cast(@Valor as time)
print '@Tolerancia = ' + cast(@Tolerancia as varchar)

/* 05. Limite para Banco de Horas Diário                                                                                                                                          */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

exec dbo.RetornarParametroDoUsuario 5, @IdUsuario, @DataFinal, @Valor output
print '@Valor = ' + @Valor

declare @LimiteHorasDiarias time = cast(@Valor as time)
print '@LimiteHorasDiarias = ' + cast(@LimiteHorasDiarias as varchar)


declare @ResumoPonto table (
	Id int,
	DataPonto date,
	HoraPonto1 time,
	HoraPonto2 time,
	Decorrido1 time,
	Intervalo time,
	HoraPonto3 time,
	HoraPonto4 time,
	Decorrido2 time,
	TotalDiario time,
	Operacao char(1),
	Saldo time,
	HoraAusencia1 time,
	HoraAusencia2 time,
	DecorridoAusencia time,
	OperacaoComAusencia char(1),
	SaldoComAusencia time,
	SaldoAcumBanco time,
	SaldoAcumReceber time
)


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* preparando a tabela inicial, com o intervalo de datas solicitado e os pontos encontrados para o usuário, além dos cálculos básicos dentro do mesmo dia                         */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

declare @DataPonto date = @DataInicial
while (@DataPonto <= @DataFinal)
begin
	insert into @ResumoPonto (Id, DataPonto)
	values ((select isnull(count(Id), 0) + 1 from @ResumoPonto), @DataPonto)

	declare cursor_PontosUsuario cursor keyset for
		select row_number() over (order by p.HoraPonto) Sequencia, p.HoraPonto
		from APIPonto p
		where p.IdUsuario = @IdUsuario
		  and p.DataPonto = @DataPonto
		order by p.IdPonto
	declare @Sequencia int, @HoraPonto time

	open cursor_PontosUsuario

	fetch first from cursor_PontosUsuario into @Sequencia, @HoraPonto

	while @@fetch_status = 0
	begin
		if (@Sequencia = 1)
			update @ResumoPonto set HoraPonto1 = @HoraPonto
			where DataPonto = @DataPonto
		else if (@Sequencia = 2)
		begin
			update @ResumoPonto set HoraPonto2 = @HoraPonto, Decorrido1 = cast(@HoraPonto as datetime) - cast(HoraPonto1 as datetime)
			where DataPonto = @DataPonto

			update @ResumoPonto set TotalDiario = Decorrido1
			where DataPonto = @DataPonto
		end
		else if (@Sequencia = 3)
			update @ResumoPonto set HoraPonto3 = @HoraPonto, Intervalo = cast(@HoraPonto as datetime) - cast(HoraPonto2 as datetime)
			where DataPonto = @DataPonto
		else if (@Sequencia = 4)
		begin
			update @ResumoPonto set HoraPonto4 = @HoraPonto, Decorrido2 = cast(@HoraPonto as datetime) - cast(HoraPonto3 as datetime)
			where DataPonto = @DataPonto

			update @ResumoPonto set TotalDiario = cast(Decorrido1 as datetime) + cast(Decorrido2 as datetime)
			where DataPonto = @DataPonto
		end

		fetch next from cursor_PontosUsuario into @Sequencia, @HoraPonto
	end

	close cursor_PontosUsuario

	deallocate cursor_PontosUsuario

	set @DataPonto = dateadd(day, 1, @DataPonto)
end


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* atualizando com as ausência encontradas para o usuário                                                                                                                         */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

update r set
  r.HoraAusencia1 = a.HoraInicialAusencia,
  r.HoraAusencia2 = a.HoraFinalAusencia,
  r.DecorridoAusencia = cast(a.HoraFinalAusencia as datetime) - cast(a.HoraInicialAusencia as datetime)
from @ResumoPonto r
  inner join APIAusencia a on r.DataPonto = a.DataAusencia and a.IdUsuario = @IdUsuario


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* realizando os cálculos acumulados dentre todos os registros                                                                                                                    */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

declare @Operacao char(1)
declare @Saldo time
declare @OperacaoComAusencia char(1)
declare @SaldoComAusencia time
declare @SaldoDiarioBanco time
declare @SaldoDiarioReceber time
declare @SaldoAcumBanco time = '00:00'
declare @SaldoAcumReceber time = '00:00'

declare cursor_ResumoPonto cursor keyset for
	select r.Id, r.TotalDiario, isnull(r.DecorridoAusencia, '00:00') DecorridoAusencia
	from @ResumoPonto r
	where r.TotalDiario is not null
	order by r.Id
declare @Id int, @TotalDiario time, @DecorridoAusencia time

open cursor_ResumoPonto

fetch first from cursor_ResumoPonto into @Id, @TotalDiario, @DecorridoAusencia

while @@fetch_status = 0
begin
	/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
	/* calculando a operação e o saldo diário SEM CONSIDERAR a ausência                                                                                                               */
	/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

	if (cast(@TotalDiario as datetime) > cast(@HorasDiarias as datetime) + cast(@Tolerancia as datetime))
	begin
		set @Operacao = '+'
		set @Saldo = cast(@TotalDiario as datetime) - cast(@HorasDiarias as datetime)

		update @ResumoPonto set Operacao = @Operacao, Saldo = @Saldo
		where Id = @Id
	end
	else if (cast(@TotalDiario as datetime) < cast(@HorasDiarias as datetime) - cast(@Tolerancia as datetime))
	begin
		set @Operacao = '-'
		set @Saldo = cast(@HorasDiarias as datetime) - cast(@TotalDiario as datetime)

		update @ResumoPonto set Operacao = @Operacao, Saldo = @Saldo
		where Id = @Id
	end
	else
	begin
		set @Operacao = ''
		set @Saldo = '00:00'
	end


	/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
	/* calculando a operação e o saldo diário CONSIDERANDO a ausência                                                                                                                 */
	/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

	if (@DecorridoAusencia = '00:00')
	begin
		/* como NÃO EXISTE ausência neste dia, apenas replicar o que já foi calculado anteriormente */
		set @OperacaoComAusencia = @Operacao
		set @SaldoComAusencia = @Saldo

		if (@OperacaoComAusencia <> '' and @SaldoComAusencia <> '00:00')
			update @ResumoPonto set OperacaoComAusencia = @OperacaoComAusencia, SaldoComAusencia = @SaldoComAusencia
			where Id = @Id
	end
	else
	begin
		/* como EXISTE ausência neste dia, calcular considerando as somas de TotalDiario e DecorridoAusencia - neste caso NÃO levar em consideração a Tolerancia */
		/*if (cast(@TotalDiario as datetime) + cast(@DecorridoAusencia as datetime) > cast(@HorasDiarias as datetime))
		begin
			set @OperacaoComAusencia = '+'
			set @SaldoComAusencia = cast(@TotalDiario as datetime) + cast(@DecorridoAusencia as datetime) - cast(@HorasDiarias as datetime)

			update @ResumoPonto set OperacaoComAusencia = @OperacaoComAusencia, SaldoComAusencia = @SaldoComAusencia
			where Id = @Id
		end
		else*/ if (cast(@TotalDiario as datetime) + cast(@DecorridoAusencia as datetime) < cast(@HorasDiarias as datetime))
		begin
			set @OperacaoComAusencia = '-'
			set @SaldoComAusencia = cast(@HorasDiarias as datetime) - cast(@TotalDiario as datetime) - cast(@DecorridoAusencia as datetime)

			update @ResumoPonto set OperacaoComAusencia = @OperacaoComAusencia, SaldoComAusencia = @SaldoComAusencia
			where Id = @Id
		end
		else
		begin
			set @OperacaoComAusencia = ''
			set @SaldoComAusencia = '00:00'
		end
	end


	/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
	/* calculando os saldos acumulados para banco e a receber CONSIDERANDO a ausência                                                                                                 */
	/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

	if (@OperacaoComAusencia = '+')
	begin
		if (@SaldoComAusencia > @LimiteHorasDiarias)
		begin
			set @SaldoDiarioBanco = @LimiteHorasDiarias
			set @SaldoDiarioReceber = cast(@SaldoComAusencia as datetime) - cast(@LimiteHorasDiarias as datetime)
		end
		else
		begin
			set @SaldoDiarioBanco = @SaldoComAusencia
			set @SaldoDiarioReceber = '00:00'
		end

		set @SaldoAcumBanco = cast(@SaldoAcumBanco as datetime) + cast(@SaldoDiarioBanco as datetime)
		set @SaldoAcumReceber = cast(@SaldoAcumReceber as datetime) + cast(@SaldoDiarioReceber as datetime)

		update @ResumoPonto set SaldoAcumBanco = @SaldoAcumBanco, SaldoAcumReceber = @SaldoAcumReceber
		where Id = @Id
	end
	else if (@OperacaoComAusencia = '-')
	begin
		set @SaldoDiarioBanco = @SaldoComAusencia

		set @SaldoAcumBanco = cast(@SaldoAcumBanco as datetime) - cast(@SaldoDiarioBanco as datetime)

		update @ResumoPonto set SaldoAcumBanco = @SaldoAcumBanco, SaldoAcumReceber = @SaldoAcumReceber
		where Id = @Id
	end

	fetch next from cursor_ResumoPonto into @Id, @TotalDiario, @DecorridoAusencia
end

close cursor_ResumoPonto

deallocate cursor_ResumoPonto


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* retornando os dados finais do processamento                                                                                                                                    */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

select *
from @ResumoPonto r
order by r.Id
