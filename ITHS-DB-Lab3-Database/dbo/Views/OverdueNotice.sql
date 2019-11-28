--FIXA MISSING
create view OverdueNotice as
select
	US.Id, US.FirstName, US.LastName, SUM(RS.Cost) as TotalCost
from
	Loans LO
inner join
	ResourceEntities RE
on
	LO.ResourceEntityId  = RE.Id
inner join
	Resources RS
on
	RE.ResourceId = RS.Id
inner join
	[User] US
on
	LO.BorrowerId = US.Id 
group by
	US.Id, US.FirstName, US.LastName