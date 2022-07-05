-- 1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
CREATE VIEW view_product_order_Damon
AS
SELECT p.ProductName, SUM(od.Quantity) as TotalOrderedQuantity
FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY ProductName

-- 2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
Create proc sp_product_order_quantity_Damon
@ProductID int,
@QuantityofOrder int out
as 
begin
select @QuantityofOrder = count(*)
from Orders o join [Order Details] od on o.OrderID = od.OrderID
where od.ProductID = @ProductID
end


-- 3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.
CREATE PROC sp_product_order_city_Damon
@productName varchar(20)
AS
BEGIN
SELECT TOP 5 o.ShipCity, SUM(od.Quantity) AS OrderQuantity
FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
INNER JOIN Orders o ON o.OrderID = od.OrderID
WHERE p.ProductName = @productName
GROUP BY ProductName, ShipCity
ORDER BY SUM(od.Quantity) DESC
END


-- 4. Create 2 new tables “people_your_last_name” “city_your_last_name”. City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.
create table city_Damon
(
ID int primary key identity(1,1),
City varchar(15)
)

create table people_Damon
(
ID int primary key identity(1,1),
Name varchar(30),
City int foreign key references city_Damon(ID) on delete set NULL
)

insert into city_Damon values ('Seattle')
insert into city_Damon values ('Green Bay')

insert into people_Damon values ('Aaron Rodgers', 2)
insert into people_Damon values ('Russell Wilson', 1)
insert into people_Damon values ('Jody Nelson', 2)

delete city_Damon
where City = 'Seattle'

insert into city_Damon values ('Madison')

update people_Damon
set City = 3
where city is null

create view Packers_JustinDamon
as
(
select p.Name
from people_Damon p join city_Damon c on p.City = c.ID
where c.City = 'Green Bay'
)

drop table people_Damon, city_Damon
drop view Packers_JustinDamon



-- 5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
CREATE PROC sp_birthday_employees_Damon
AS
BEGIN
CREATE TABLE birthday_employees_Damon(Id int primary key,
[first name] varchar(20),
[last name] varchar(20),
birthDate datetime)
INSERT INTO birthday_employees_Damon(Id, [first name], [last name], birthDate)
SELECT e.EmployeeID, e.FirstName, e.LastName, e.BirthDate FROM Employees e
WHERE month(e.birthDate) = 2
END

EXEC sp_birthday_employees_Damon
SELECT * FROM birthday_employees_Damon
DROP TABLE birthday_employees_Damon

-- 6. How do you make sure two tables have the same data?
-- You can use a "join" to check if the values are null.
-- You can use a "union" to check the number of values that are the same.
-- You can use "except" to check which values will become null.