CREATE TABLE [db_donations].[dbo].[monetary] (
	id INT PRIMARY KEY IDENTITY,
	date DATE NOT NULL,
	amount DECIMAL NOT NULL,
	donor VARCHAR(150) NULL
);