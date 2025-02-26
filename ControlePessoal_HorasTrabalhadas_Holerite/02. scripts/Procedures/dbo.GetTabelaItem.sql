
create or alter procedure GetTabelaItem
    @p_IdTabelaTipo int,
    @p_DataVigencia date
as
begin
    declare @Sequencia int
    declare @IdTabela int

    select top 1
      @Sequencia = row_number() over (order by t.DataVigenciaInicial desc),
      @IdTabela = t.IdTabela
    from dbo.APITabela t
    where t.IdTabelaTipo = @p_IdTabelaTipo
      and t.DataVigenciaInicial <= @p_DataVigencia

    select
      ti.IdTabelaItem,
      ti.IdTabela,
      ti.IntervaloInicial,
      ti.IntervaloFinal,
      ti.ValorAliquota,
      ti.ValorDeducao,
      ti.DataHoraInclusao,
      ti.DataHoraAlteracao
    from dbo.APITabela t
      inner join dbo.APITabelaItem ti on t.IdTabela = ti.IdTabela
    where t.IdTabela = @IdTabela
    order by ti.IntervaloInicial
end
