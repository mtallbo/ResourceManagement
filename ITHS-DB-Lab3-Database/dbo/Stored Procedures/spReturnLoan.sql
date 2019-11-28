create procedure spReturnLoan
(
	@loanId int
)
as
begin	
	update 
		[Loans]
	set
		ReturnDate = getdate()
	where
		@loanId = id
end
