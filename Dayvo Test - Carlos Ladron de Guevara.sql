-- 1. Type of the most expensive property.

select
     `type`
from
     Property
order by
     value_in_euros desc
limit
     1;
     
-- 2. Name of the countries of which our database contains no people.
    
select
     cou.name
from
     Country as cou
     left join Person as per on per.country_id = cou.id
group by
     cou.id
having
     count(per.country_id) = 0;
     
-- 3. Average value of vehicles (properties of type = 'vehicle')

select
     avg(value_in_euros) as averageValue
from
     Property
where
     `type` = 'vehicle';
     
-- 4. Name of the person with more vehicles (properties of type = 'vehicle').
select 
	 name 
from 
	 (
		select
		     per.name,
		     pro. `type`,
		     count(pro. `type`) as total
		from
		     Person as per
		     inner join Property as pro on pro.person_id = per.id
		where
		     type = 'vehicle'
		group by
		     per.name,
		     pro. `type`
     ) as temp
order by 
     total desc 
limit 
	 1;
	
-- 5. Name of the people who have properties outside of their countries.
select
     per.name
from
     Person as per
     inner join Property as pro on pro.person_id = per.id
     and pro.country_id <> per.country_id

-- 6. List of people with their names and the total value of their properties, but display only those with more than 500.000 of total property value.
select
     per.name,
     sum(pro.value_in_euros) as total
from
     Person as per
     inner join Property as pro on pro.person_id = per.id
group by
     pro.person_id
having
     sum(pro.value_in_euros) > 500000;
     
     

