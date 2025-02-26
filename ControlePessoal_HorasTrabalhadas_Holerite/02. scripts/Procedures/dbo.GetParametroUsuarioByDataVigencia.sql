
create or alter procedure GetParametroUsuarioByDataVigencia
    @p_IdParametro int,
    @p_IdUsuario int,
    @p_DataVigencia date
as
begin
    declare @Sequencia int
    declare @IdParametroUsuario int

    select top 1
      @Sequencia = row_number() over (order by pu.DataVigenciaInicial desc),
      @IdParametroUsuario = pu.IdParametroUsuario
    from dbo.APIParametroUsuario pu
    where pu.IdParametro = @p_IdParametro
      and pu.IdUsuario = @p_IdUsuario
      and pu.DataVigenciaInicial <= @p_DataVigencia

    select
      pu.IdParametroUsuario,
      pu.IdParametro,
      pu.IdUsuario,
      pu.DataVigenciaInicial,
      pu.Valor,
      pu.DataHoraInclusao,
      pu.DataHoraAlteracao
    from dbo.APIParametroUsuario pu
    where pu.IdParametroUsuario = @IdParametroUsuario
end
