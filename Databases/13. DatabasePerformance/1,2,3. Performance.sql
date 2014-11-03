---------------------------------------------------------------------
-- Homework Task 1 -
---------------------------------------------------------------------

CREATE TABLE Logs(
	LogId int PRIMARY KEY IDENTITY,
	LogText varchar(100) NOT NULL,
	LogDate datetime,
)

DECLARE @Counter int = 1
WHILE @Counter < 10000000
BEGIN
  INSERT INTO Logs(LogText, LogDate)
  VALUES('Text' + CONVERT(varchar, @Counter), GETDATE())
  SET @Counter = @Counter + 1
END

select * from Logs
where LogDate BETWEEN '2013-07-18 19:30:00.000' AND '2013-07-18 19:40:00.000'

------------------------------------------------------------------------
--Homework Task 2 -
------------------------------------------------------------------------

CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE LogDate BETWEEN '2013-07-18 19:30:00.000' AND '2013-07-18 19:31:00.000'

DROP INDEX IDX_Logs_LogDate ON Logs

------------------------------------------------------------------------
--Homework Task 3
------------------------------------------------------------------------
SELECT CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Logs'

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK__Logs__5E548648516D3733
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE CONTAINS(LogText, 'Text')
