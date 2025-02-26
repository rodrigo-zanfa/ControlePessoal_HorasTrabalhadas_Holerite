
delimiter $$

create procedure GetParametroUsuarioByDataVigencia (
    in p_IdParametro int,
    in p_IdUsuario int,
    in p_DataVigencia date
)
begin
    declare IdParametroUsuario int;

    select pu.IdParametroUsuario
    into IdParametroUsuario
    from APIParametroUsuario pu
    where pu.IdParametro = p_IdParametro
      and pu.IdUsuario = p_IdUsuario
      and pu.DataVigenciaInicial <= p_DataVigencia
    order by pu.DataVigenciaInicial desc
    limit 1;

    select
      pu.IdParametroUsuario,
      pu.IdParametro,
      pu.IdUsuario,
      pu.DataVigenciaInicial,
      pu.Valor,
      pu.DataHoraInclusao,
      pu.DataHoraAlteracao
    from APIParametroUsuario pu
    where pu.IdParametroUsuario = IdParametroUsuario;
end$$

delimiter ;
