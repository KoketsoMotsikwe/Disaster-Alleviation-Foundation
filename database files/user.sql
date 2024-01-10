CREATE TABLE [db_donations].[dbo].[user] (
	id INT PRIMARY KEY IDENTITY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	user_name VARCHAR(100) NOT NULL UNIQUE,
	user_type VARCHAR(100) NOT NULL,
	password VARCHAR(300) NOT NULL,
);

-- username: admin
-- password: admin
INSERT INTO [db_donations].[dbo].[user]
VALUES ('admin', 'admin', 'admin', 'Employee', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=');