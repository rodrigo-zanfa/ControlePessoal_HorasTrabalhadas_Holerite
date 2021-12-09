
declare @dataInicial datetime = '2021-11-15'
declare @dataFinal datetime = '2021-12-14'
declare @idUsuario int = 1
declare @horasDiarias time = '08:00'
declare @tolerancia time = '00:10'
declare @limiteHorasDiarias time = '02:00'

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
	SaldoAcumBanco time,
	SaldoAcumReceber time
)


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* preparando a tabela inicial, com o intervalo de datas solicitado e os pontos encontrados para o usuário, além dos cálculos básicos dentro do mesmo dia                         */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

declare @dataPonto date = @dataInicial
while (@dataPonto <= @dataFinal)
begin
	insert into @ResumoPonto (Id, DataPonto)
	values ((select isnull(count(Id), 0) + 1 from @ResumoPonto), @dataPonto)

	declare cursor_PontosUsuario cursor keyset for
		select row_number() over (order by cast(p.DataHoraPonto as time)) sequencia, cast(p.DataHoraPonto as time) HoraPonto
		from APIPonto p
		where p.IdUsuario = @idUsuario
		  and cast(p.DataHoraPonto as date) = @dataPonto
		order by p.IdPonto
	declare @sequencia int, @HoraPonto time

	open cursor_PontosUsuario

	fetch first from cursor_PontosUsuario into @sequencia, @HoraPonto

	while @@fetch_status = 0
	begin
		if (@sequencia = 1)
			update @ResumoPonto set HoraPonto1 = @HoraPonto
			where DataPonto = @dataPonto
		else if (@sequencia = 2)
			update @ResumoPonto set HoraPonto2 = @HoraPonto, Decorrido1 = cast(@HoraPonto as datetime) - cast(HoraPonto1 as datetime)
			where DataPonto = @dataPonto
		else if (@sequencia = 3)
			update @ResumoPonto set HoraPonto3 = @HoraPonto, Intervalo = cast(@HoraPonto as datetime) - cast(HoraPonto2 as datetime)
			where DataPonto = @dataPonto
		else if (@sequencia = 4)
		begin
			update @ResumoPonto set HoraPonto4 = @HoraPonto, Decorrido2 = cast(@HoraPonto as datetime) - cast(HoraPonto3 as datetime)
			where DataPonto = @dataPonto

			update @ResumoPonto set TotalDiario = cast(Decorrido1 as datetime) + cast(Decorrido2 as datetime)
			where DataPonto = @dataPonto
		end

		fetch next from cursor_PontosUsuario into @sequencia, @HoraPonto
	end

	close cursor_PontosUsuario

	deallocate cursor_PontosUsuario

	set @dataPonto = dateadd(day, 1, @dataPonto)
end


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* realizando os cálculos acumulados dentre todos os registros                                                                                                                    */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

declare @Operacao char(1)
declare @Saldo time
declare @SaldoDiarioBanco time
declare @SaldoDiarioReceber time
declare @SaldoAcumBanco time = '00:00'
declare @SaldoAcumReceber time = '00:00'

declare cursor_ResumoPonto cursor keyset for
	select r.Id, r.TotalDiario
	from @ResumoPonto r
	order by r.Id
declare @Id int, @TotalDiario time

open cursor_ResumoPonto

fetch first from cursor_ResumoPonto into @Id, @TotalDiario

while @@fetch_status = 0
begin
	--if (cast(@TotalDiario as datetime) >= cast(@horasDiarias as datetime))
	--	set @Operacao = '+'
	--else
	--	set @Operacao = '-'

	if (cast(@TotalDiario as datetime) > cast(@horasDiarias as datetime) + cast(@tolerancia as datetime))
	begin
		set @Operacao = '+'
		set @Saldo = cast(@TotalDiario as datetime) - cast(@horasDiarias as datetime)

		update @ResumoPonto set Operacao = @Operacao, Saldo = @Saldo
		where Id = @Id
	end
	else if (cast(@TotalDiario as datetime) < cast(@horasDiarias as datetime) - cast(@tolerancia as datetime))
	begin
		set @Operacao = '-'
		set @Saldo = cast(@horasDiarias as datetime) - cast(@TotalDiario as datetime)

		update @ResumoPonto set Operacao = @Operacao, Saldo = @Saldo
		where Id = @Id
	end
	else
	begin
		set @Operacao = ''
		set @Saldo = '00:00'
	end

	if (@Operacao = '+')
	begin
		if (@Saldo > @limiteHorasDiarias)
		begin
			set @SaldoDiarioBanco = @limiteHorasDiarias
			set @SaldoDiarioReceber = cast(@Saldo as datetime) - cast(@limiteHorasDiarias as datetime)
		end
		else
		begin
			set @SaldoDiarioBanco = @Saldo
			set @SaldoDiarioReceber = '00:00'
		end

		set @SaldoAcumBanco = cast(@SaldoAcumBanco as datetime) + cast(@SaldoDiarioBanco as datetime)
		set @SaldoAcumReceber = cast(@SaldoAcumReceber as datetime) + cast(@SaldoDiarioReceber as datetime)

		update @ResumoPonto set SaldoAcumBanco = @SaldoAcumBanco, SaldoAcumReceber = @SaldoAcumReceber
		where Id = @Id
	end
	else if (@Operacao = '-')
	begin
		set @SaldoDiarioBanco = @Saldo

		set @SaldoAcumBanco = cast(@SaldoAcumBanco as datetime) - cast(@SaldoDiarioBanco as datetime)

		update @ResumoPonto set SaldoAcumBanco = @SaldoAcumBanco
		where Id = @Id
	end

	fetch next from cursor_ResumoPonto into @Id, @TotalDiario
end

close cursor_ResumoPonto

deallocate cursor_ResumoPonto


/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
/* retornando os dados finais do processamento                                                                                                                                    */
/* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

select *
from @ResumoPonto r
order by r.Id
