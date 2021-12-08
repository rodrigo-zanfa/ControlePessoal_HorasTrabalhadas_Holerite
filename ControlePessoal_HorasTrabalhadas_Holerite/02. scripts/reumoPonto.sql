
declare @dataInicial datetime = '2021-12-01'
declare @dataFinal datetime = '2021-12-31'
declaRE @idUsuario int = 1

declare @ResumoPonto table (
	Id int,
	DataPonto date,
	HoraPonto1 time,
	HoraPonto2 time,
	Decorrido1 time,
	HoraPonto3 time,
	HoraPonto4 time,
	Decorrido2 time,
	TotalDiario time
)

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
		if @sequencia = 1
			update @ResumoPonto set HoraPonto1 = @HoraPonto
			where DataPonto = @dataPonto
		else if @sequencia = 2
			update @ResumoPonto set HoraPonto2 = @HoraPonto, Decorrido1 = cast(@HoraPonto as datetime) - cast(HoraPonto1 as datetime)
			where DataPonto = @dataPonto
		else if @sequencia = 3
			update @ResumoPonto set HoraPonto3 = @HoraPonto
			where DataPonto = @dataPonto
		else if @sequencia = 4
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

select * from @ResumoPonto rp
order by rp.Id
