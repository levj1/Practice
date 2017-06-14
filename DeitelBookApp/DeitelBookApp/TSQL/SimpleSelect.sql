-- Weather Observation Station 4
select count(*) - count(distinct txtPropertyName) as difference from propertyaddress

--Weather Observation Station 5
select top 1 name, min(datalength(name)) as [length] from association 
group by name,datalength(name)
order by [length], name

select top 1 name, max(datalength(name)) as [length] from association 
group by name,datalength(name)
order by [length] desc, name desc

-- Weather Observation Station 6
select distinct name from association where name like 'a%' or name like 'e%' or name like 'i%' or name like 'o%' or name like 'u%'
order by name 
 

-- Weather Observation Station 7
select distinct name from association where name like '%a' or name like '%e' or name like '%i' or name like '%o' or name like '%u'
order by name 

-- Weather Observation Station 8
select distinct name from association where (name like '%a' and (name like 'a%' or name like 'e%' or name like 'i%' or name like 'o%' or name like 'u%'))
or (name like '%e' and (name like 'a%' or name like 'e%' or name like 'i%' or name like 'o%' or name like 'u%'))
or (name like '%i' and (name like 'a%' or name like 'e%' or name like 'i%' or name like 'o%' or name like 'u%'))
or (name like '%o' and (name like 'a%' or name like 'e%' or name like 'i%' or name like 'o%' or name like 'u%'))
or (name like '%u' and (name like 'a%' or name like 'e%' or name like 'i%' or name like 'o%' or name like 'u%'))
order by name 

-- Weather Observation Station 9 (do not start with a vowel)
select distinct name from association where name not like 'a%' and name not like 'e%' and name not like 'i%' and name not like 'o%' and name not like 'u%'
order by name 
 
 -- Weather Observation Station 9 (do not end with a vowel)
select distinct name from association where name not like '%a' and name not like '%e' and name not like '%i' and name not like '%o' and name not like '%u'
order by name 

 -- Weather Observation Station 12 (do not either start or end with a vowel)
select distinct name from association where name not like '%a' and name not like 'a%' and  name not like '%e' and name not like 'e%' and 
 name not like '%i' and name not like 'i%' and  name not like '%o' and name not like 'o%' and  name not like '%u' and name not like 'u%' 


 -- Higher Than 75 Marks
select associd, name, numManagerID from association
where numManagerID >= 75
order by right(name,3)