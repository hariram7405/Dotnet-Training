-- Users Table
CREATE TABLE users (
    userid INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100),
    email NVARCHAR(100) UNIQUE,
    role NVARCHAR(50)
);

-- Projects Table
CREATE TABLE projects (
    projectId INT IDENTITY(1,1) PRIMARY KEY,
    projectName NVARCHAR(100),
    startDate DATE,
    endDate DATE
);

-- Status Table
CREATE TABLE status (
    statusId INT IDENTITY(1,1) PRIMARY KEY,
    statusName NVARCHAR(50)
);

-- Bugs Table with Foreign Keys
CREATE TABLE bug (
    bugId INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(200),
    description NVARCHAR(MAX),
    createdDate DATE,
    priority NVARCHAR(50),
    projectId INT,
    assignedTo INT,
    statusId INT,

    FOREIGN KEY (projectId) REFERENCES projects(projectId),
    FOREIGN KEY (assignedTo) REFERENCES users(userid),
    FOREIGN KEY (statusId) REFERENCES status(statusId)
);
SELECT * FROM INFORMATION_SCHEMA.TABLES;