
create or alter procedure GetSalarioByDataVigencia
    @p_IdUsuario int,
    @p_DataVigencia date
as
begin
    declare @Sequencia int
    declare @IdSalario int

    select top 1
      @Sequencia = row_number() over (order by s.DataVigenciaInicial desc),
      @IdSalario = s.IdSalario
    from dbo.APISalario s
    where s.IdUsuario = @p_IdUsuario
      and s.DataVigenciaInicial <= @p_DataVigencia

    select
      s.IdSalario,
      s.IdUsuario,
      s.DataVigenciaInicial,
      s.Valor,
      s.DataHoraInclusao,
      s.DataHoraAlteracao
    from dbo.APISalario s
    where s.IdSalario = @IdSalario
end
