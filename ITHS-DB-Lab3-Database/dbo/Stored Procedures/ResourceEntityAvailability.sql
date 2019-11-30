CREATE PROCEDURE [dbo].[ResourceEntityAvailability]
	@ResourceId int
as
select 
	RE.Id, RE.ResourceId, RE.EntityId, RE.IdentificationNumber, RE.LostByLoanId, CASE WHEN RE.LostByLoanId IS NOT NULL THEN 'Lost'
																				WHEN LO.StartDate IS NOT NULL AND LO.ReturnDate IS NULL THEN 'Loaned'
																				ELSE 'Available' END AS [Availability]
from 
	Loans LO
inner join(
	select MAX(id) MaxId
	from Loans
	group by Loans.ResourceEntityId) maxid on maxid.MaxId = LO.Id
left join
	ResourceEntities RE
on
	RE.Id = LO.ResourceEntityId
where
	RE.ResourceId = @ResourceId

go
