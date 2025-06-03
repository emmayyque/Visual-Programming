CREATE PROCEDURE GetProducts
AS 
BEGIN
SELECT * FROM Products
END

CREATE PROCEDURE GetProduct
@id int
AS 
BEGIN
SELECT * FROM Products WHERE id = @id
END

CREATE PROCEDURE DeleteProduct
@id int
AS 
BEGIN
DELETE FROM Products WHERE id = @id
END

CREATE PROCEDURE UpdateProduct
@id int, @name nvarchar(MAX), @brand nvarchar(MAX), @price int, @quantity int
AS 
BEGIN
UPDATE Products SET name = @name, brand = @brand, price = @price, quantity = @quantity WHERE id = @id
END

CREATE PROCEDURE InsertProduct
@id int, @name nvarchar(MAX), @brand nvarchar(MAX), @price int, @quantity int
AS 
BEGIN
INSERT INTO Products (id, name, brand, price, quantity) VALUES (@id, @name, @brand, @price, @quantity)
END