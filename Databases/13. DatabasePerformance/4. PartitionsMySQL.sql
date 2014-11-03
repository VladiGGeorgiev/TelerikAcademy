USE Performancedb;
CREATE TABLE Logs(
	LogId int AUTO_INCREMENT,
	LogDate datetime NOT NULL,
	LogText nvarchar(20) NOT NULL,
	CONSTRAINT Logs_PrimaryKey PRIMARY KEY(LogId)
);
DROP TABLE Logs;

DELIMITER $$
CREATE PROCEDURE InsertValues()
BEGIN
	DECLARE counter INT DEFAULT 0;
	START TRANSACTION;
	WHILE counter < 1000000 DO
		INSERT INTO Logs(LogDate, LogText)
		VALUES(CURDATE(), CONCAT('Text', CAST(counter AS CHAR)) );
		SET counter = counter + 1;
	END WHILE;
	COMMIT;
END $$
DROP PROCEDURE InsertValues

CALL InsertValues()

-- -----------------------------------------------
-- Partitioning create new table
-- -----------------------------------------------

CREATE TABLE PartitionLogs (
	LogId int NOT NULL AUTO_INCREMENT,
	LogDate datetime NOT NULL,
	LogText nvarchar(20) NOT NULL,
	CONSTRAINT Logs_PrimaryKey PRIMARY KEY(LogId, LogDate)
)
PARTITION BY RANGE( YEAR(LogDate) ) (
    PARTITION p0 VALUES LESS THAN (2010),
    PARTITION p1 VALUES LESS THAN (2011),
    PARTITION p2 VALUES LESS THAN (2012),
    PARTITION p3 VALUES LESS THAN (2013),
    PARTITION p4 VALUES LESS THAN MAXVALUE
);

DELIMITER $$
CREATE PROCEDURE InsertPartitionValues()
BEGIN
	DECLARE counter INT DEFAULT 0;
	DECLARE minDate datetime;
	DECLARE maxDate datetime;
	SET minDate = '2010-01-01 00:00:00';
	SET maxDate = '2014-01-01 00:00:00';
	START TRANSACTION;
	WHILE counter < 1000000 DO
		INSERT INTO PartitionLogs(LogDate, LogText)
		VALUES(
			TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, minDate, maxDate)), minDate), 
			CONCAT('Text', CAST(counter AS CHAR))
		);
		SET counter = counter + 1;
	END WHILE;
	COMMIT;
END $$
DROP PROCEDURE InsertPartitionValues

CALL InsertPartitionValues();

-- Select all values from different partitions
SELECT * FROM PartitionLogs PARTITION (p1);
SELECT * FROM PartitionLogs PARTITION (p2);
SELECT * FROM PartitionLogs PARTITION (p3);
SELECT * FROM PartitionLogs PARTITION (p4);







