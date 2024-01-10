CREATE TABLE [db_donations].[dbo].[goods_category] (
	id INT PRIMARY KEY IDENTITY,
	category VARCHAR(150) NOT NULL UNIQUE,
	sequence INT NOT NULL
);

INSERT INTO [db_donations].[dbo].[goods_category]
VALUES ('Clothes',1),('Non-Perishable Foods',2),('Add-New-Item',3);
