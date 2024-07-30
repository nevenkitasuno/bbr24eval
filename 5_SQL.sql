--ex1
select d.*, s.name as squad_name, s.mission from Dwarves d
join Squads s on d.squad_id = s.squad_id
where d.squad_id is not null;

--ex2
select * from Dwarves
where profession = miner
and squad_id is null;

--ex3
select * from Tasks
where status = 'pending'
and priority = (select MAX(priority) from tasks
                where status = 'pending');

--ex4
select owner_id as dwarf_id, COUNT(item_id) as items_count
from Items
where owner_id is not null
group by owner_id;

--ex5
select s.*, COUNT(d.dwarf_id) as dwarves_count
from Squads s
left join Dwarves d on s.squad_id = d.squad_id
GROUP BY s.squad_id;

--ex6
select d.profession, COUNT(t.task_id) as unfinished_tasks
from Dwarves d
join Tasks t on d.dwarf_id = t.assigned_to
where t.status in ('pending', 'in_progress')
and t.priority = (select MAX(priority) from tasks
                where status in ('pending', 'in_progress'))
group by d.profession;

--ex7
select i.type, AVG(d.age) from Items i
join Dwarves d on i.owner_id = d.dwarf_id
group by i.type;

--ex8
select d.* from Dwarves d
join items i on d.dwarf_id = i.owner_id
where d.age > (select MAX(age) from Dwarves)
and i.item_id is null;