CREATE DATABASE "ArkSoft_DevTest";

USE "ArkSoft_DevTest";

CREATE TABLE "Customer"(
	custID INT IDENTITY(0,1) PRIMARY KEY,
	custName VARCHAR(150) NOT NULL,
	custAddress VARCHAR(250) NOT NULL,
	custTelephone VARCHAR(10),
	custContactName VARCHAR(150),
	custContactEmail VARCHAR(150),
	vatNumber VARCHAR(10)
);