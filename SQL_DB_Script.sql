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

select 'data source=' + @@servername + ';initial catalog=' + db_name() + 
case type_desc when 'WINDOWS_LOGIN' then ';trusted_connection=true' 
else ';user id=' + suser_name() + ';password=<>' 
end as ConnectionString from sys.server_principals 
where name = suser_name();

SELECT * FROM "Customer";