CREATE VIEW LoanList AS
--Lista på lån och vem
select
	LO.Id, LO.BorrowerId, US.FirstName, US.LastName, LO.StartDate, LO.EndDate, LO.ReturnDate
from
	Loans LO
inner join
	[User] US
on
	LO.BorrowerId = US.Id
