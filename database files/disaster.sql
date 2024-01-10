CREATE TABLE [db_donations].[dbo].[disaster] (
	id INT PRIMARY KEY IDENTITY,
	start_date DATE NOT NULL,
	end_date DATE NOT NULL,
	location VARCHAR(100) NOT NULL,
	description VARCHAR(150) NOT NULL,
	amount DECIMAL NOT NULL,
	type VARCHAR(150) NOT NULL
);