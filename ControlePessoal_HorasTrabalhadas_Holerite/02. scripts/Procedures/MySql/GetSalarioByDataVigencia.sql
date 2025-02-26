
delimiter $$

create procedure GetSalarioByDataVigencia (
    in p_IdUsuario int,
    in p_DataVigencia date
)
begin
    declare IdSalario int;

    select s.IdSalario
    into IdSalario
    from APISalario s
    where s.IdUsuario = p_IdUsuario
      and s.DataVigenciaInicial <= p_DataVigencia
    order by s.DataVigenciaInicial desc
    limit 1;

    select
      s.IdSalario,
      s.IdUsuario,
      s.DataVigenciaInicial,
      s.Valor,
      s.DataHoraInclusao,
      s.DataHoraAlteracao
    from APISalario s
    where s.IdSalario = IdSalario;
end$$

delimiter ;
