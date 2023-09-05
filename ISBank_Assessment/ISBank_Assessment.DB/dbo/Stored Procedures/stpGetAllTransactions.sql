-- =============================================
--Store procedure name is --> stpGetAllTransactions
CREATE PROCEDURE stpGetAllTransactions
-- Add the parameters for the stored procedure here
    @AccountCode nvarchar(30)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Select statements for procedure here
    Select * from Transactions
	where account_code like '%'+@AccountCode+'%'
END