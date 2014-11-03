--What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
-- SQL is structured query language. Declarative language for query and manipulation of relational data
--Data Manipulation Language (DML) -> SELECT, INSERT, UPDATE, DELETE
--Data Definition Language (DDL) -> CREATE, DROP, ALTER, GRANT, REVOKE

--What is Transact-SQL (T-SQL)?
--Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.

--4 task Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments

--5 task - Write a SQL query to find all department names.
SELECT Name FROM Departments

--6 task - Write a SQL query to find the salary of each employee. 
SELECT FirstName + ' ' + LastName, Salary
FROM Employees

--7 task - Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName FROM Employees
WHERE MiddleName is not null
UNION
SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE MiddleName is null

--8 task - Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM Employees

--9 task - Write a SQL query to find all different employee salaries.
SELECT distinct Salary FROM Employees

--10 task - Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT * FROM Employees 
WHERE JobTitle = 'Sales Representative'

--11 task - Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE FirstName like 'Sa%'

--12 task - Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE LastName like '%ei%'

--13 task - Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees
WHERE Salary > 20000 and Salary < 30000 --BETWEEN 20000 and 30000

--14 TASK - Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees
WHERE Salary in (25000, 14000, 12500, 23600)

--15 task - Write a SQL query to find all employees that do not have manager.
SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE ManagerId is null

--16 task - Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC 

--17 task - Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName + ' ' + LastName AS FullName, Salary FROM Employees
ORDER BY Salary DESC

--18 task - Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText AS Address
FROM Employees e
JOIN Addresses a
ON e.AddressId = a.AddressId

--19 task Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText AS Address
FROM Employees e, Addresses a
WHERE e.AddressId = a.AddressId

--20 task - Write a SQL query to find all employees along with their manager.
SELECT emp.FirstName + ' ' + emp.LastName AS FullName, mng.FirstName + ' ' + mng.LastName AS Manager
FROM Employees emp
JOIN Employees mng
ON emp.ManagerID = mng.EmployeeID

--21 task - Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT emp.FirstName + ' ' + emp.LastName AS FullName, mng.FirstName + ' ' + mng.LastName AS Manager, adr.AddressText AS Address
FROM Employees emp
JOIN Employees mng
ON emp.ManagerID = mng.EmployeeID
JOIN Addresses adr
ON emp.AddressID = adr.AddressID

--22 task - Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

--23 task - Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName AS FullName, mng.FirstName + ' ' + mng.LastName as Manager
FROM Employees e
LEFT JOIN Employees mng
ON e.ManagerID = mng.EmployeeId

SELECT e.FirstName + ' ' + e.LastName AS FullName, mng.FirstName + ' ' + mng.LastName AS Manager
FROM Employees mng
RIGHT JOIN Employees e
ON e.ManagerID = mng.EmployeeId

--24 TASK - Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS FullName, d.Name, E.HireDate
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND YEAR(e.HireDate) BETWEEN 2002 AND 2003