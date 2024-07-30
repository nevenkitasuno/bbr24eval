--ex1
select * from Squads
where leader_id is null;

--ex2
select * from Dwarves
where age > 150
and profession = 'Warrior';

--ex3
select distinct d.* from Dwarves d
join Items i on i.owner_id = d.dwarf_id
where i.type = 'Weapon'

--ex4
select d.dwarf_id, COUNT(t.task_id) as tasks_count
from Dwarves d
join Tasks t on d.dwarf_id = t.assigned_to
group by d.dwarf_id, t.status;

--ex5
select t.* from Tasks t
join Dwarves d on d.dwarf_id = t.assigned_to
join Squads s on s.squad_id = d.squad_id
where s.name = 'weapon';

--ex6
select * from Relationships
where relationship in ('Супруг', 'Родитель', 'Ребёнок')