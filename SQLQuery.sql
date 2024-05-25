
/*CREATE THE DATABASE*/
USE [master]
CREATE DATABASE BlazorAppDb
GO

/*USE THE DATABASE*/
USE [BlazorAppDb]
GO

/*CREATE TABLE*/

CREATE TABLE Items (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT 0,
);

GO


/*Optional*/
/*Seed test data*/
INSERT INTO Items (Name, Description, Price, CreatedAt, IsDeleted)
VALUES
('Item1', 'Description1', 10.00, '2023-01-01 12:00:01', 0),
('Item2', 'Description2', 20.00, '2023-01-02 12:00:02', 0),
('Item3', 'Description3', 30.00, '2023-01-03 12:00:03', 0),
('Item4', 'Description4', 40.00, '2023-01-04 12:00:04', 0),
('Item5', 'Description5', 50.00, '2023-01-05 12:00:05', 0),
('Item6', 'Description6', 60.00, '2023-01-06 12:00:06', 0),
('Item7', 'Description7', 70.00, '2023-01-07 12:00:07', 0),
('Item8', 'Description8', 80.00, '2023-01-08 12:00:08', 0),
('Item9', 'Description9', 90.00, '2023-01-09 12:00:09', 0),
('Item10', 'Description10', 100.00, '2023-01-10 12:00:10', 0),
('Item11', 'Description11', 110.00, '2023-01-11 12:00:11', 0),
('Item12', 'Description12', 120.00, '2023-01-12 12:00:12', 0),
('Item13', 'Description13', 130.00, '2023-01-13 12:00:13', 0),
('Item14', 'Description14', 140.00, '2023-01-14 12:00:14', 0),
('Item15', 'Description15', 150.00, '2023-01-15 12:00:15', 0),
('Item16', 'Description16', 160.00, '2023-01-16 12:00:16', 0),
('Item17', 'Description17', 170.00, '2023-01-17 12:00:17', 0),
('Item18', 'Description18', 180.00, '2023-01-18 12:00:18', 0),
('Item19', 'Description19', 190.00, '2023-01-19 12:00:19', 0),
('Item20', 'Description20', 200.00, '2023-01-20 12:00:20', 0),
('Item21', 'Description21', 210.00, '2023-01-21 12:00:21', 0),
('Item22', 'Description22', 220.00, '2023-01-22 12:00:22', 0),
('Item23', 'Description23', 230.00, '2023-01-23 12:00:23', 0),
('Item24', 'Description24', 240.00, '2023-01-24 12:00:24', 0),
('Item25', 'Description25', 250.00, '2023-01-25 12:00:25', 0),
('Item26', 'Description26', 260.00, '2023-01-26 12:00:26', 0),
('Item27', 'Description27', 270.00, '2023-01-27 12:00:27', 0),
('Item28', 'Description28', 280.00, '2023-01-28 12:00:28', 0),
('Item29', 'Description29', 290.00, '2023-01-29 12:00:29', 0),
('Item30', 'Description30', 300.00, '2023-01-30 12:00:30', 0),
('Item31', 'Description31', 310.00, '2023-01-31 12:00:31', 0),
('Item32', 'Description32', 320.00, '2023-02-01 12:00:32', 0),
('Item33', 'Description33', 330.00, '2023-02-02 12:00:33', 0),
('Item34', 'Description34', 340.00, '2023-02-03 12:00:34', 0),
('Item35', 'Description35', 350.00, '2023-02-04 12:00:35', 0),
('Item36', 'Description36', 360.00, '2023-02-05 12:00:36', 0),
('Item37', 'Description37', 370.00, '2023-02-06 12:00:37', 0),
('Item38', 'Description38', 380.00, '2023-02-07 12:00:38', 0),
('Item39', 'Description39', 390.00, '2023-02-08 12:00:39', 0),
('Item40', 'Description40', 400.00, '2023-02-09 12:00:40', 0),
('Item41', 'Description41', 410.00, '2023-02-10 12:00:41', 0),
('Item42', 'Description42', 420.00, '2023-02-11 12:00:42', 0),
('Item43', 'Description43', 430.00, '2023-02-12 12:00:43', 0),
('Item44', 'Description44', 440.00, '2023-02-13 12:00:44', 0),
('Item45', 'Description45', 450.00, '2023-02-14 12:00:45', 0),
('Item46', 'Description46', 460.00, '2023-02-15 12:00:46', 0),
('Item47', 'Description47', 470.00, '2023-02-16 12:00:47', 0),
('Item48', 'Description48', 480.00, '2023-02-17 12:00:48', 0),
('Item49', 'Description49', 490.00, '2023-02-18 12:00:49', 0),
('Item50', 'Description50', 500.00, '2023-02-19 12:00:50', 0);

