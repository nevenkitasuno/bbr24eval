--ex1
select d.*, s.name as squad_name, s.mission from dwarves d
join squads s on d.squad_id = s.squad_id
where d.squad_id is not null;

--ex2
select * from dwarves
where profession = miner
and squad_id is null;