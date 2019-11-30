CREATE PROCEDURE [dbo].[ResourceEntityAvailability]
	@ResourceId int
as
select
	RE.Id, RE.ResourceId, RE.EntityId, RE.IdentificationNumber, RE.LostByLoanId, CASE WHEN RE.LostByLoanId IS NOT NULL THEN 'Lost'
																				WHEN LO.StartDate IS NOT NULL AND LO.ReturnDate IS NULL THEN 'Loaned'
																				ELSE 'Available' END AS [Availability]
from
	ResourceEntities RE
left join
	Loans LO
on
	RE.Id = LO.ResourceEntityId
where
	RE.ResourceId = @ResourceId and LO.ReturnDate is null
go
