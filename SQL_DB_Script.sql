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

INSERT INTO "Customer" (custName, custAddress, custTelephone, custContactName, custContactEmail, vatNumber) VALUES
('Jessabel Boucher', 'there', '0987654321', 'Zoey Boucher', 'amb222@gmail.com', '122567890'),
('Johnny Letterman', '44 Road Street', '0987654321', 'Melissa Johnston', 'johnston@34.com', '5463738289'),
('Letïcia Morman', '26 Blom Streat', '1234567890', 'Henrie Potgieter', 'Melissa@co.za', '7394956353'),
('Melanie Botha', '78 Gemsbok', '8575940202', 'Hanelie Moolman', 'moolman@yahoo.com', '5354739292'),
('Yasmine Galecki', '289 Boxman Street', '3456789765', 'Tyler Renaid', 'yler@yahoo.co.za', '3456789876'),
('Abbigail Longman', '65 Ramran', '2345678937', 'Johnnie Weeteman', 'j0my@1034gmail.com', '5462310361'),
('Gerhardus Nooddan', '27 Dingman Streat', '0426745138', 'Claudia Harbinger', 'clodz@lie.za', '2624935624'),
('Donavan Leon', '56 Complex Road', '0987654321', 'Amber Kenny', 'kenny@bing.com', '2131047251'),
('Polly Paul', '45 Donavan Street', '0136248356', 'Esmeralda Nowell', 'hhh@bing.co.za', '1305363475'),
('Harper Donald', '19 Springbok Way', '0647429472', 'Louisa Kent', 'kent@gmail.com', '6242549162'),
('Kenny Kent', '87 Hemingway', '0142465385', 'Jessie Bells', 'kent23@gmail.com', '1363468374'),
('William DeWalt', '46 DeWatt Way', '0746473942', 'Henry Hall', 'hall@ri.co.za', '7579348294'),
('Esmeralda Du Preez', '16 Avenue Road', '0987654321', 'Linda Swan', 'swannepoei34@gmail.com', '8492916134'),
('Roger Twane', '89 Luweville', '045528284', 'Jessica Noah', 'noah23@yahoo.com', '9183746574'),
('James albert dean', 'xcvbnm./', '0732515658', 'fghj', 'BeepBoop@poop.fart', '4457556962'),
('iutresdf', 'dfyuikjb', NULL, NULL, NULL, NULL);