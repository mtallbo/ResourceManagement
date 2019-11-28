--Försenade lån 
create view OverdueLoans as

select
	US.FirstName, US.LastName, RS.[Name] as ResourceName,
	DATEDIFF(DAY,LO.EndDate, LO.ReturnDate) as DaysLate
from
	Loans LO
inner join
	[User] US
on
	LO.BorrowerId = Us.Id
inner join
	ResourceEntities RE
on
	LO.ResourceEntityId = RE.Id
inner join
	Resources RS
on
	RE.ResourceId = Rs.Id
where
	LO.ReturnDate > Lo.EndDate