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
            print 'Item not available'
        end
	else if not exists(select * from ResourceEntities where ResourceEntities.Id = @resourceEntityId)
        begin
            print 'Item does not exist'
        end
	else if exists(select * from ResourceEntities where ResourceEntities.EntityId = @resourceEntityId and ResourceEntities.LostByLoanId is null)
		begin
            print 'Item is missing'
        end
	else if (@loanerId = @borrowerId)
		begin
			print 'You cannot loan from yourself'
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
