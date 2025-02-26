
delimiter $$

create procedure GetTabela (
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
      t.IdTabela,
      t.IdTabelaTipo,
      t.DataVigenciaInicial,
      t.Descricao,
      t.ValorDeducaoDependente,
      t.DataHoraInclusao,
      t.DataHoraAlteracao
    from APITabela t
    where t.IdTabela = IdTabela;
end$$

delimiter ;
