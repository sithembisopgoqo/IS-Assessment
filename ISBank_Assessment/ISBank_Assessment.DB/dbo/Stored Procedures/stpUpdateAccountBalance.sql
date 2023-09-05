create PROCEDURE stpUpdateAccountBalance (
    @AccountNumber1 varchar(50) = null,
    @AccountNumber2 varchar(50) = null,
    @amount money = null

) AS 
BEGIN
    SET NOCOUNT ON;

   UPDATE Accounts
        SET outstanding_balance = COALESCE(outstanding_balance, 0) - COALESCE(@amount, 0)
        WHERE account_number = @AccountNumber1;

    UPDATE Accounts
        SET outstanding_balance = COALESCE(outstanding_balance, 0) + COALESCE(@amount, 0)
        WHERE account_number = @AccountNumber2;
END;