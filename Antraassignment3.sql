-- 1. List all cities that have both Employees and Customers.

Select Distinct c.city
From dbo.customers c 
Where c.city IN (
Select p.city
From dbo.employees p)

-- 2. List all cities that have Customers but no Employee.
		-- a. Use sub-query

		Select Distinct c.city
		From dbo.customers c 
		Where c.city NOT IN (
		Select p.city
		From dbo.employees p)

		-- b. Do not use sub-query

		Select Distinct c.city
		From dbo.customers c 
		Except
		Select p.city
		From dbo.employees p

-- 3. List all products and their total order quantities throughout all orders.

Select p.ProductName, SUM(od.quantity) as [Total Orders]
From dbo.Products p, dbo.Orders o, dbo.[Order Details] od
Where o.OrderID = od.OrderID AND od.ProductID = p.ProductID
Group By p.ProductName

-- 4. List all Customer Cities and total products ordered by that city.

Select t.city, count(*) [Total Products]
From (Select c.city, od.productid, count(*) as [Total Products]
From dbo.orders o, dbo.customers c, dbo.[Order Details] od
Where o.OrderID = od.OrderID AND c.CustomerID = o.CustomerID
Group By c.city, od.productid) t
Group By t.city

-- 5. List all Customer Cities that have at least two customers.
		-- a. Use union

		Select City From Customers
		Except
		Select city from Customers
		group by city
		having count(*) = 1
		Union
		Select City from Customers
		Group by city
		Having count(*) = 0

		-- b. Use sub-query and no union

		Select City From Customers
		Except
		Select city from Customers
		group by city
		having count(*) = 1

-- 6. List all Customer Cities that have ordered at least two different kinds of products.

Create View cityProducts
As 
Select c.city, od.productid, count(*) as [Total Products]
From dbo.orders o, dbo.customers c, dbo.[Order Details] od
Where o.orderid = od.orderid AND c.customerid = o.customerid
Group By c.city, od.productid

Select distinct t.city
From cityProducts t, cityProducts i
Where t.city = i.city AND t.productid <> i.productid

-- 7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

Select Distinct c.contactname
From dbo.orders o, dbo.customers c
Where c.customerid = o.customerid and c.City <> o.ShipCity

-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

Select Distinct Top 5 (p.ProductName), o.ShipCity, AVG(od.Unitprice) as [Average Price]
From dbo.Products p,dbo.orders o, dbo.[Order Details] od
where o.OrderID = od.OrderID AND od.ProductID = p.ProductID AND p.UnitPrice = od.UnitPrice
Group BY p.ProductName, od.UnitPrice, o.ShipCity

-- 9. List all cities that have never ordered something but we have employees there.
		-- a. Use sub-query

		Select distinct e.city
		From dbo.Employees e
		Where e.city Not In (
		Select o.ShipCity 
		From dbo.Orders o)

		-- b. Do not use sub-query

		Select distinct e.city
		From dbo.Employees e
		Except
		Select o.ShipCity From dbo.Orders o

-- 10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

Select Distinct o.ShipCity, sum(od.Quantity)
From dbo.Orders o, dbo.[Order Details] od
Group By o.ShipCity, od.Quantity

-- 11. How do you remove the duplicates record of a table?

-- Distinct reserved word to delete duplicates and group by to join columns.