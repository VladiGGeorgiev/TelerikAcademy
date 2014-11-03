--1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
--Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE TABLE Persons(
	Id int PRIMARY KEY IDENTITY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	SSN nvarchar(20) NOT NULL
)

CREATE TABLE Accounts(
	Id int PRIMARY KEY IDENTITY,
	PersonId int NOT NULL,
	Balance money NOT NULL
	CONSTRAINT FK_Accont_Person FOREIGN KEY(PersonId)
		REFERENCES Persons(Id)
)

INSERT INTO Persons
VALUES
	('Peter', 'Ivanov', '1231412442'),
	('Minka', 'Svircholini', '5345345345'),
	('Jivka', 'Dudata', '5252353452')

INSERT INTO Accounts
VALUES
	(1, 3200),
	(2, 123122),
	(3, 10000)

ALTER PROC dbo.usp_SelectPersonsNames
AS
	SELECT FirstName + ' ' + LastName as [Full Name]
	FROM Persons
GO

EXEC dbo.usp_SelectPersonsNames

--2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC dbo.usp_ReturnPersonsWithMoreMoney(@money money)
AS
	SELECT p.FirstName + ' ' + p.LastName as [Full Name], a.Balance 
	FROM Persons p
	JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Balance > @money
GO

EXEC dbo.usp_ReturnPersonsWithMoreMoney 5000
--3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
--It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
ALTER FUNCTION dbo.ufn_CalculateRate(@sum money, @year_interest float, @months int)
RETURNS money
AS
BEGIN
	RETURN @sum + @sum * (@year_interest / 100 * (@months / 12.0))
END

SELECT dbo.ufn_CalculateRate(Balance, 6.5, 9.0)
FROM Accounts
--4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. 
--It should take the AccountId and the interest rate as parameters.
ALTER PROC dbo.usp_GiveInterestToAccount(@AccountId int, @InterestRate float)
AS
	UPDATE Accounts
	SET Balance = Balance + dbo.ufn_CalculateRate(Balance, @InterestRate, 1)
	WHERE @AccountId = Accounts.Id
GO

EXEC dbo.usp_GiveInterestToAccount 1, 7

--5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC dbo.usp_WithdrawMoney(@AccountId int, @Money money)
AS
	UPDATE Accounts
	SET Balance = Balance - @Money
	WHERE @AccountId = Accounts.Id
GO

CREATE PROC	dbo.usp_DepositMoney(@AccountId int, @Money money)
AS
	UPDATE Accounts
	SET Balance = Balance + @Money
	WHERE @AccountId = Accounts.Id
GO

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
	LogId int PRIMARY KEY IDENTITY,
	AccountId int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL
	CONSTRAINT FK_LogsAccounts FOREIGN KEY(AccountId)
	REFERENCES Accounts(Id)
)

CREATE TRIGGER tr_LogAccountChange ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	VALUES(
		(SELECT PersonId FROM inserted),
		(SELECT Balance FROM deleted),
		(SELECT Balance FROM inserted)
	)
GO

EXEC dbo.usp_DepositMoney 1, 999

--7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
CREATE PROC [dbo].[usp_FindNames](
@lettersToSearch NVARCHAR(50)
)
AS
	DECLARE @valid bit
	SET @valid = 0
						   
	SELECT e.FirstName AS [FIRST Names]
	FROM Employees e
	WHERE
	1 = (SELECT [dbo].[fn_NameContainingLetters](
		e.FirstName,
		@lettersToSearch)
	)
GO
 
--Procedure to search through Middle Names
CREATE PROC [dbo].[usp_FindMiddleNames](
@lettersToSearch NVARCHAR(50)
)
AS
	DECLARE @valid bit
	SET @valid = 0
						   
	SELECT e.MiddleName AS [Middle Names]
	FROM Employees e
	WHERE
	1 = (SELECT [dbo].[fn_NameContainingLetters](
			e.MiddleName,
			@lettersToSearch)
	)
GO
 
--Procedure to search through Last Names
CREATE PROC [dbo].[usp_FindLastNames](
@lettersToSearch NVARCHAR(50)
)
AS
	DECLARE @valid bit
	SET @valid = 0
						   
	SELECT e.LastName AS [LAST Names]
	FROM Employees e
	WHERE
	1 = (SELECT [dbo].[fn_NameContainingLetters](
		e.LastName,
		@lettersToSearch)
	)
GO
 
 
--Procedure to search through Towns
CREATE PROC [dbo].[usp_FindTowns](
@lettersToSearch NVARCHAR(50)
)
AS
	DECLARE @valid bit
	SET @valid = 0
						   
	SELECT t.Name AS [Towns]
	FROM Towns t
	WHERE
	1 = (SELECT [dbo].[fn_NameContainingLetters](
	t.Name,
	@lettersToSearch)
	   
 
-- The Function For Every String
CREATE FUNCTION [dbo].[fn_NameContainingLetters](
        @name NVARCHAR(50),
        @letters NVARCHAR(50)
        )
        RETURNS bit
AS
BEGIN
	DECLARE @contains bit
	SET @contains = 1
	DECLARE @curLetter NVARCHAR(1)
	DECLARE @counter INT
	SET @counter = 1

	WHILE(@counter <= LEN(@name))
		BEGIN
		SET @curLetter = SUBSTRING(@name, @counter, 1)
		IF (CHARINDEX(@curLetter, @letters) = 0)
				SET @contains = 0
		SET @counter = @counter + 1
		END
	RETURN @contains
END
 
EXEC [dbo].[usp_FindNames] @letterstosearch = 'oistmiahf'
EXEC [dbo].[usp_FindMiddleames] @letterstosearch = 'oistmiahf'
EXEC [dbo].[usp_FindLastNames] @letterstosearch = 'oistmiahf'
EXEC [dbo].[usp_FindTowns] @letterstosearch = 'oistmiahf'
--8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT e.FirstName, e.LastName, t.Name,
			o.FirstName, o.LastName
	FROM Employees e
	INNER JOIN Addresses a
			ON a.AddressID = e.AddressID
	INNER JOIN Towns t
			ON t.TownID = a.TownID, Employees o
	INNER JOIN Addresses a1
			ON a1.AddressID = o.AddressID
	INNER JOIN Towns t1
			ON t1.TownID = a1.TownID               

	OPEN empCursor
	DECLARE @firstName1 NVARCHAR(50)
	DECLARE @lastName1 NVARCHAR(50)
	DECLARE @town NVARCHAR(50)
	DECLARE @firstName2 NVARCHAR(50)
	DECLARE @lastName2 NVARCHAR(50)
	FETCH NEXT FROM empCursor
			INTO @firstName1, @lastName1, @town, @firstName2, @lastName2

	WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT @firstName1 + ' ' + @lastName1 +
					'     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
			FETCH NEXT FROM empCursor
					INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
		END

CLOSE empCursor
DEALLOCATE empCursor

--9. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
DECLARE empCursor CURSOR READ_ONLY FOR
SELECT e.FirstName, e.LastName, t.Name,	o.FirstName, o.LastName
FROM Employees e
INNER JOIN Addresses a
	ON a.AddressID = e.AddressID
INNER JOIN Towns t
	ON t.TownID = a.TownID,
Employees o
INNER JOIN Addresses a1
	ON a1.AddressID = o.AddressID
INNER JOIN Towns t1
	ON t1.TownID = a1.TownID               

OPEN empCursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)
FETCH NEXT FROM empCursor
INTO @firstName1, @lastName1, @town, @firstName2, @lastName2

WHILE @@FETCH_STATUS = 0
BEGIN
PRINT @firstName1 + ' ' + @lastName1 +
		'     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
FETCH NEXT FROM empCursor
		INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
END

CLOSE empCursor
DEALLOCATE empCursor
--10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. For example the following SQL statement should return a single string:
DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name+=e.FirstName+N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);