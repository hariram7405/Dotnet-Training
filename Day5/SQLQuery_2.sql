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
-- CREATE TABLES


INSERT INTO users (name, email, role) VALUES
('HariRam', 'hariram.7405@gmail.com', 'Software Developer'),
('Mani', 'mani@gmail.com', 'Team Manager'),
('Shiva', 'shiv3467@gmail.com', 'Tester'),
('Priya', 'priya@gmail.com', 'Developer');

-- INSERT PROJECTS

INSERT INTO projects (projectName, startDate, endDate) VALUES
('AI Analytics', '2025-10-05', '2025-12-05'),
('Smart 4.0', '2025-11-12', '2025-12-12'),
('Issue Tracker', '2024-10-11', '2025-10-11');

-- INSERT STATUSES

INSERT INTO status (statusName) VALUES
('NEW'),
('IN PROGRESS'),
('CLOSED');

-- INSERT BUGS

INSERT INTO bug (title, description, createdDate, priority, projectId, assignedTo, statusId) VALUES
('UX Issue', 'App UI is not friendly', '2025-10-11', 'High', 1, 1, 1),
('DB error', 'DB connection failed', '2025-08-11', 'Low', 2, 2, 2),
('Middleware issue', 'OS is not compatible', '2025-10-11', 'Medium', 3, 3, 3);

-- VALIDATION QUERIES 

SELECT * FROM users;
SELECT * FROM projects;
SELECT * FROM status;
SELECT * FROM bug;
