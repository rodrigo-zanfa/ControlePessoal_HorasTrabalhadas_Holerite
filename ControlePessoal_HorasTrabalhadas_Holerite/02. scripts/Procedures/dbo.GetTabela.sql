
create or alter procedure GetTabela
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
      t.IdTabela,
      t.IdTabelaTipo,
      t.DataVigenciaInicial,
      t.Descricao,
      t.ValorDeducaoDependente,
      t.DataHoraInclusao,
      t.DataHoraAlteracao
    from dbo.APITabela t
    where t.IdTabela = @IdTabela
end
