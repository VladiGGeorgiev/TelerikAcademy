--1.Write a SQL query to find the names and salaries of the employees 
--that take the minimal salary in the company. Use a nested SELECT statement

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary
FROM Employees e
WHERE e.Salary IN (SELECT MIN(Salary) FROM Employees)

--2. Write a SQL query to find the names and salaries of the employees that have a salary
-- that is up to 10% higher than the minimal salary for the company.
DECLARE @MinSalary int
SET @MinSalary = (SELECT MIN(Salary) FROM Employees)

SELECT e.FirstName + ' ' + e.LastName as [Full Name], e.Salary
FROM Employees e
WHERE e.Salary BETWEEN @MinSalary AND @MinSalary * 1.1

--3. Write a SQL query to find the full name, salary and department of the employees that take
-- the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName as [Full Name], e.Salary, d.Name
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = (
	SELECT MIN(Salary) FROM Employees
	WHERE DepartmentID = e.DepartmentID
)

--4.Write a SQL query to find the average salary in the department #1.
SELECT MIN(d.Name) as [Department], AVG(e.Salary) 
FROM Employees e
JOIN Departments d
ON e.DepartmentID = 1

--5.Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(e.Salary) [Average Sales salaries]
FROM Employees e
JOIN Departments d
ON d.Name = 'Sales'

--6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) as [Sales Employees Count]
FROM Employees e
JOIN Departments d
on d.Name = 'Sales'

--7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*)
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--8. Write a SQL query to find the number of all employees that have NO manager.
SELECT COUNT(*)
FROM Employees e
WHERE e.ManagerID IS NULL

--9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name as Department, AVG(e.Salary)
FROM Departments d
JOIN Employees e
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name as Town, d.Name as Department, COUNT(*) as [Employees count]
FROM Employees e
JOIN Addresses a
	ON e.AddressId = a.AddressId
JOIN Towns t
	ON a.TownId = t.TownId
JOIN Departments d
	ON d.DepartmentId = e.DepartmentId
GROUP BY t.Name, d.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. 
--Display their first name and last name.

SELECT mng.FirstName, mng.LastName, COUNT(*) AS [Employees count]
FROM Employees e
JOIN Employees mng
	ON e.ManagerID = mng.EmployeeID
GROUP BY mng.FirstName, mng.LastName
	HAVING COUNT(*) = 5

--12.Write a SQL query to find all employees along with their managers. 
--For employees that do not have manager display the value "(no manager)".
SELECT 
	e.FirstName + ' ' + e.LastName as [Employee], 
	COALESCE(mng.FirstName + ' ' + mng.LastName, 'No manager') as [Manager]
FROM Employees e
LEFT JOIN Employees mng
ON e.ManagerID = mng.EmployeeID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5
-- characters long. Use the built-in LEN(str) function.
SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

--14.Write a SQL query to display the current date and time in the following format "day.month.year
-- hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
declare @myTime as DateTime
set @myTime = GETDATE()
select FORMAT(@myTime, 'dd.MM.yyyy HH:mm:ss:fff')

--15 task
CREATE TABLE Users (
	UserId INT IDENTITY,
	Username nvarchar(30) NOT NULL,
	Password nvarchar(30) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLoginTime datetime NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY(UserId),
	CONSTRAINT CHK_Password CHECK (LEN(Password) >= 5),
	coNSTRAINT UNQ_User UNIQUE(Username)
)

INSERT INTO Users(Username, Password, FullName, LastLoginTime)
VALUES
	('Minka', '12312', 'Minka Svircholini', GETDATE()),
	('Duda', '12312', 'Duda Prychkata', GETDATE()),
	('Jivko', '12312', 'Jivko Stamatov', GETDATE())


--16 task
CREATE VIEW [Display Users] AS
SELECT FullName FROM Users
WHERE DAY(LastLoginTime) = DAY(GETDATE())

--17 task 
CREATE TABLE Groups(
	Id int IDENTITY,
	Name nvarchar(50) NOT NULL,
	CONSTRAINT UNQ_Name UNIQUE(Name),
	CONSTRAINT PK_Groups PRIMARY KEY(Id)
) 

--18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table. 
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users ADD GroupId int

ALTER Table users
add constraint FK_Users_groups 
FOreign key(GroupId)
References Groups(id)

INSERT INTO Groups 
VALUES ('Telerik')

INSERT INTO Users
VALUES ('Nakov', '312341', 'Svetlin Nakov', GETDATE(), 1)

select * from Users

--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups
VALUES
	('Microsoft'), ('Infragistics'), ('IBM'), ('VMWare')

INSERT INTO Users 
Values
	('Didka', '0001230', 'Dimitrichka', GETDATE(), 2),
	('Jivka', '0021300', 'Jivka Petrakieva', GETDATE(), 3)

INSERT INTO Users
VALUES 
	('Ivana', '34234124', 'Ivana Peshova', '2010-03-10 00:00:00.000', 2),
	('Misha', '23123412', 'Ivana Peshova', '2010-03-10 00:00:00.000', 2),
	('Gosha', '55342312', 'Ivana Peshova', '2010-03-10 00:00:00.000', 2)

SELECT * FROM Users
SELECT * FROM Groups
--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username = 'Pepo',
	Password = '39128',
	LastLoginTime = GETDATE()
Where Username = 'Pesho'

UPDATE Groups
SET Name = 'Telerik AD'
WHERE Name = 'Telerik'
--21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Groups
WHERE Name = 'IBM'

SELECT * FROM Users
SELECT * FROM Groups

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
	--Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
	--Use the same for the password, and NULL for last login time.
INSERT INTO Users(Username, Password, FullName, LastLoginTime, GroupId)
SELECT 
	FirstName + LastName, 
	LastName + FirstName, 
	FirstName + ' ' + LastName, 
	GETDATE(), 
	1
FROM Employees

select * from Users

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET	Password = ' NULL '
WHERE DATEDIFF(day, LastLoginTime, '2010-03-10 00:00:00.000') >= 0

--24. Write a SQL statement that deletes all users without passwords (NULL password).
BEGIN TRAN
DELETE FROM Users
WHERE Password = ' NULL '
ROLLBACK TRAN

--25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name as Department, e.JobTitle, AVG(e.Salary) as [Average Salary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT d.Name as Department, e.JobTitle, MIN(e.Salary) as [Min Salary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
---------------------------------------------------

SELECT d.name as Department, e.JobTitle, e.FirstName, MIN(e.Salary)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (
	SELECT MIN(Salary) FROM Employees
	WHERE JobTitle = e.JobTitle
)
group by d.Name, e.JobTitle, e.FirstName
Order by d.Name

--27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(*)
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--28. Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*)
FROM Employees emp
JOIN Employees mng
	ON emp.ManagerID = mng.EmployeeID
JOIN Addresses a
	ON a.AddressID = emp.AddressID
JOIN Towns t
	ON t.TownID = a.TownID
WHERE emp.EmployeeID IN (SELECT DISTINCT ManagerId FROM Employees)
GROUP BY t.Name

--29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
--	Dont forget to define identity, primary key and appropriate foreign key. 
--	Issue few SQL statements to insert, update and delete of some data in the table.
--	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--  For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	Id int IDENTITY,
	EmployeeId int ,
	[Date] datetime NOT NULL,
	Task nvarchar(50) NOT NULL,
	[Hours] int NOT NULL,
	Comments nvarchar(50) NOT NULL
	CONSTRAINT PK_WorkHours PRIMARY KEY(Id),
	CONSTRAINT FK_Id_EmployeeId FOREIGN KEY(Id) REFERENCES Employees(EmployeeID)
)

CREATE TABLE WorkHoursLogs(
	Id INT IDENTITY PRIMARY KEY,
	OldRecord varchar(200) NOT NULL,
	NewRecord varchar(200) NOT NULL,
	Command nvarchar(50) NOT NULL
)

INSERT INTO WorkHours
VALUES
	(1, GETDATE(), 'Create class', 3, 'Very cool task'),
	(1, GETDATE(), 'Fix bugs', 2, 'Shits'),
	(2, GETDATE(), 'Create class', 3, 'Very cool task'),
	(2, GETDATE(), 'Fix bugs', 2, 'Shits')

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLogs(OldRecord, NewRecord, Command)
	VALUES(
		(select ' Date: ' + CAST([Date] as nvarchar(50)) + ' Task: ' + Task + ' Hours: ' + CAST([Hours] as nvarchar(50)) + ' Comment: ' + Comments from Deleted),
		(select ' Date: ' + CAST([Date] as nvarchar(50)) + ' Task: ' + Task + ' Hours: ' + CAST([Hours] as nvarchar(50)) + ' Comment: ' + Comments from Inserted),
		('UPDATE')
	)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLogs(OldRecord, NewRecord, Command)
	VALUES(
		'',
		(SELECT ' Date: ' + CAST([Date] as nvarchar(50)) + ' Task: ' + Task + ' Hours: ' + CAST([Hours] as nvarchar(50)) + ' Comment: ' + Comments FROM Inserted),
		('INSERT')
	)
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
	INSERT INTO WorkHoursLogs(OldRecord, NewRecord, Command)
	VALUES(
		(SELECT ' Date: ' + CAST([Date] as nvarchar(50)) + ' Task: ' + Task + ' Hours: ' + CAST([Hours] as nvarchar(50)) + ' Comment: ' + Comments FROM Deleted),
		(''),
		('DELETE')
	)
GO


UPDATE WorkHours
SET Task = 'New task',
Date = GETDATE(),
Hours = 12,
Comments = 'Fuckin shit'
WHERE Id = 3

INSERT INTO WorkHours
VALUES (
	2, GETDATE(), 'Incredible task', 3, 'Very nice task'
)

DELETE FROM WorkHours
WHERE Id = 2

--30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
DELETE FROM Employees
	SELECT * FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
ROLLBACK TRAN

--31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN
--32. Find how to use temporary tables in SQL Server. 
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
CREATE TABLE #TemporaryTable(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
	SELECT EmployeeID, ProjectID
	FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable