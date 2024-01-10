CREATE TABLE [db_donations].[dbo].[goods] (
	id INT PRIMARY KEY IDENTITY,
	date DATE NOT NULL,
	number_of_items INT NOT NULL,
	category VARCHAR(150) NOT NULL,
	description VARCHAR(200) NOT NULL,
	donor VARCHAR(150) NULL
);