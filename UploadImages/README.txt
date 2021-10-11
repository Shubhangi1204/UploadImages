CREATE TABLE Account (
    Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    Name varchar(1000) NOT NULL,
);

CREATE UNIQUE INDEX Idx_Account
ON Account (Id,Name);

********************************************

CREATE TABLE Posts (
    Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    Caption varchar(1000),
    Image varbinary(max) NOT NULL,
    CreatorId BIGINT FOREIGN KEY REFERENCES Account(Id),
    CreatorName varchar(1000) NOT NULL,
    CreatedAt datetime NOT NULL
);


*********************************************

CREATE TABLE Comments (
    Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    Content varchar(max),
    PostId BIGINT FOREIGN KEY REFERENCES Posts(Id),
    CreatorId BIGINT FOREIGN KEY REFERENCES Account(Id),
    CreatorName varchar(1000) NOT NULL,
    CreatedAt datetime NOT NULL
);