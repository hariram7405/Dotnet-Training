DROP DATABASE IF EXISTS BugTrackerDB;



CREATE DATABASE BugTrackerDB;



USE BugTrackerDB;


-- 1. Create Table: Users
 
CREATE TABLE Users (
    UserId INT IDENTITY(1000,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    UserEmail NVARCHAR(100) NOT NULL UNIQUE,
    Role NVARCHAR(50) NOT NULL
);


 
-- 2. Create Table: Projects
 
CREATE TABLE Projects (
    ProjectId INT IDENTITY(2000,1) PRIMARY KEY,
    ProjectName NVARCHAR(100) NOT NULL,
    ProjectDomain NVARCHAR(100) NOT NULL,
    ProjectStartDate DATE NOT NULL,
    ProjectEndDate DATE NOT NULL,
    ProjectDescription NVARCHAR(MAX) NOT NULL
);


 
-- 3. Create Table: Status
 
CREATE TABLE Status (
    StatusId INT IDENTITY(3000,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL CHECK (StatusName IN ('IN PROGRESS','OPEN','CLOSED'))
);


 
-- 4. Create Table: Bugs
 
CREATE TABLE Bugs (
    BugId INT IDENTITY(4000,1) PRIMARY KEY,
    BugName NVARCHAR(100) NOT NULL,
    BugDescription NVARCHAR(MAX) NOT NULL,
    BugReported DATE NOT NULL,
    BugProjectId INT FOREIGN KEY REFERENCES Projects(ProjectId),
    BugReportedBy NVARCHAR(100) NOT NULL,
    BugAssignedTo INT FOREIGN KEY REFERENCES Users(UserId),
    BugStatus INT FOREIGN KEY REFERENCES Status(StatusId)
);


 
-- Insert Data: Users
 
INSERT INTO Users (UserName, UserEmail, Role) VALUES
('HariRam', 'hariram.7405@gmail.com', 'Software Developer'),
('Mani', 'mani@gmail.com', 'Team Manager'),
('Shiva', 'shiv3467@gmail.com', 'Tester'),
('Priya', 'priya@gmail.com', 'Developer');


 
-- Insert Data: Projects
 
INSERT INTO Projects (ProjectName, ProjectDomain, ProjectStartDate, ProjectEndDate, ProjectDescription) VALUES
('AI Analytics', 'Artificial Intelligence', '2025-10-05', '2025-12-05', 'AI-powered analytics dashboard for real-time business intelligence.'),
('Smart 4.0', 'IoT & Automation', '2025-11-12', '2025-12-12', 'Smart automation platform integrating IoT devices.'),
('Issue Tracker', 'Software Tools', '2024-10-11', '2025-10-11', 'Bug and issue tracking system for software teams.');


 
-- Insert Data: Status
 
INSERT INTO Status (StatusName) VALUES
('OPEN'),
('IN PROGRESS'),
('CLOSED');


 
-- Insert Data: Bugs
 
INSERT INTO Bugs (BugName, BugDescription, BugReported, BugProjectId, BugReportedBy, BugAssignedTo, BugStatus) VALUES
('UI Overlap Issue', 'Buttons overlap on smaller screen resolutions.', '2025-10-11', 2000, 'HariRam', 1003, 3000),
('Database Timeout', 'The database times out under high load.', '2025-08-11', 2001, 'Mani', 1002, 3001),
('Login Failure', 'Users unable to login after recent deployment.', '2025-07-15', 2002, 'Priya', 1000, 3001),
('Email Not Sent', 'Notification emails are not sent on new bug creation.', '2025-07-20', 2000, 'Shiva', 1001, 3002);
