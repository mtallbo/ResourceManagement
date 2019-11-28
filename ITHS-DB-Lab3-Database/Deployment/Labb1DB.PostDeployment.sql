/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [Role] ON

INSERT INTO 
	[Role]  (  Id, [Name], PermissionLevel ) 
SELECT  
	1, 'Global Admin', 500
WHERE  
	NOT EXISTS (SELECT * FROM [Role] WHERE Id = 1)

INSERT INTO 
	[Role]  (  Id, [Name], PermissionLevel ) 
SELECT  
	2, 'Resource Admin', 400
WHERE  
	NOT EXISTS (SELECT * FROM [Role] WHERE Id = 2)

INSERT INTO 
	[Role]  (  Id, [Name], PermissionLevel ) 
SELECT  
	3, 'Loan Admin', 300
WHERE  
	NOT EXISTS (SELECT * FROM [Role] WHERE Id = 3)

INSERT INTO 
	[Role]  (  Id, [Name], PermissionLevel ) 
SELECT  
	4, 'Borrower', 200
WHERE  
	NOT EXISTS (SELECT * FROM [Role] WHERE Id = 4)

SET IDENTITY_INSERT [User] OFF