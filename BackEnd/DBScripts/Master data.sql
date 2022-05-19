INSERT INTO District( [ProvienceId],[Name],IsActive ) VALUES
( 6, 'Ampara', 1),
( 8, 'Anuradhapura', 1),
( 7, 'Badulla', 1),
( 6, 'Batticaloa', 1),
( 1, 'Colombo',1),
(3, 'Galle', 1),
( 1, 'Gampaha', 1),
( 3, 'Hambantota', 1),
( 9, 'Jaffna', 1),
( 1, 'Kalutara', 1),
( 2, 'Kandy', 1),
( 5, 'Kegalle', 1),
( 9, 'Kilinochchi', 1),
( 4, 'Kurunegala', 1),
( 9, 'Mannar', 1),
( 2, 'Matale', 1),
( 3, 'Matara', 1),
( 7, 'Monaragala', 1),
( 9, 'Mullaitivu', 1),
( 2, 'Nuwara Eliya', 1),
( 8, 'Polonnaruwa', 1),
( 4, 'Puttalam', 1),
( 5, 'Ratnapura', 1),
( 6, 'Trincomalee', 1),
( 9, 'Vavuniya', 1);


INSERT INTO [dbo].[Provience] ( [Name],IsActive) VALUES
('Western', 1),
('Central', 1),
('Southern', 1),
( 'North Western', 1),
( 'Sabaragamuwa', 1),
( 'Eastern', 1),
( 'Uva', 1),
( 'North Central', 1),
( 'Northern', 1);

INSERT INTO [dbo].[Category]
           ([Name]
           ,[IsActive])
     VALUES
           ('Auto Diesel',1),
		   ('Kerosine',1),		   
		    ('Petrol 92',1),
		   ('Petrol 95',1),
		   ('Super Diesel',1),
		   ('Laugfs Gas 12.5Kg',1),
		   ('Laugfs Gas 5Kg',1),
		   ('Litro Gas 12.5Kg',1),
		   ('Litro Gas 5Kg',1)

INSERT INTO [dbo].[Company]
           ([Name]
           ,[IsActive])
     VALUES
           ('Cepetco',1),
		   ('IOC',1),
		   ('Laugfs',1),
		   ('Litro',1)