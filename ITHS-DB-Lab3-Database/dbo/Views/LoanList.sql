CREATE VIEW LoanList AS
--Lista på lån och vem
SELECT        
LO.Id, US2.FirstName +' ' +US2.LastName as LoanerFullName, US.FirstName + ' ' +US.LastName as BorrowerFullName, LO.StartDate, LO.EndDate, LO.ReturnDate
FROM            
	dbo.Loans AS LO 
INNER JOIN
    dbo.[User] AS US 
ON LO.BorrowerId = US.Id
INNER JOIN
	dbo.[User] as US2
on LO.LoanerId = US2.Id