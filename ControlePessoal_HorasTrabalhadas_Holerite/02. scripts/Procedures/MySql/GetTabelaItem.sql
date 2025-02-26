
delimiter $$

create procedure GetTabelaItem (
    in p_IdTabelaTipo int,
    in p_DataVigencia date
)
begin
    declare IdTabela int;

    select t.IdTabela
    into IdTabela
    from APITabela t
    where t.IdTabelaTipo = p_IdTabelaTipo
      and t.DataVigenciaInicial <= p_DataVigencia
    order by t.DataVigenciaInicial desc
    limit 1;

    select
      ti.IdTabelaItem,
      ti.IdTabela,
      ti.IntervaloInicial,
      ti.IntervaloFinal,
      ti.ValorAliquota,
      ti.ValorDeducao,
      ti.DataHoraInclusao,
      ti.DataHoraAlteracao
    from APITabela t
      inner join APITabelaItem ti on t.IdTabela = ti.IdTabela
    where t.IdTabela = IdTabela
    order by ti.IntervaloInicial;
end$$

delimiter ;
