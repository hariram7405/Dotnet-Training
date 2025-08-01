
CREATE DATABASE BugTrackerLite;
GO


USE BugTrackerLite;
GO


CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL
);

CREATE TABLE Tickets (
    TicketId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(100) CHECK (Status IN ('Open', 'Closed', 'Resolved')),
    CreatedDate DATE NOT NULL,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId)
);

CREATE TABLE Tags (
    TagId INT IDENTITY(1,1) PRIMARY KEY,
    TagName NVARCHAR(100) NOT NULL
);


CREATE TABLE TicketTags (
    TicketId INT NOT NULL,
    TagId INT NOT NULL,
    PRIMARY KEY (TicketId, TagId),
    FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId),
    FOREIGN KEY (TagId) REFERENCES Tags(TagId)
);
