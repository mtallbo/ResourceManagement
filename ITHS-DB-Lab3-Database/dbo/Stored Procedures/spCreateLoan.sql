create procedure spCreateLoan
(
	@loanerId int,
	@borrowerId int,
	@resourceEntityId int,
	@startDate date,
	@endDate date
)

as
/*
Den lånar om dessa villkor fylls
*Exemplaret finns inte i låntabellen
*Exemplaret finns inte i lånetabellen där returvärde är null(dvs den är utlånad)
*Exemplaret finns och har ett returvärde
*/
begin try
	insert into
		[dbo].[Loans]
		(
		[LoanerId],
		[BorrowerId],
		[ResourceEntityId],
		[StartDate],
		[EndDate]
		)
	values
		(
		@loanerId,
		@borrowerId,
		@resourceEntityId,
		@startDate,
		@endDate
	)
END try
begin catch
	select ERROR_NUMBER(), ERROR_MESSAGE();
end catch
