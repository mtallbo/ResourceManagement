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
	if exists(select * from Loans where ResourceEntityId = @resourceEntityId and ReturnDate is null)
        begin
            --'Item not available'
			return 0
        end
	if exists(select * from ResourceEntities where ResourceEntities.Id = @resourceEntityId and ResourceEntities.LostByLoanId is not null)
		begin
            --'Item is missing'
			return 0
        end
	if not exists(select * from ResourceEntities where ResourceEntities.Id = @resourceEntityId)
        begin
            --'Item does not exist'
			return 0
        end
	if (@loanerId = @borrowerId)
		begin
			--'You cannot loan from yourself'
			return 0
		end
	else
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
