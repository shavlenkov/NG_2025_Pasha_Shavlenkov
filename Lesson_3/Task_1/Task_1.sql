USE Crowdfunding;

BEGIN TRANSACTION;

BEGIN TRY
    CREATE TABLE Users (
        Id INT IDENTITY PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        SecondName NVARCHAR(100) NOT NULL
    );

    CREATE TABLE Categories (
        Id INT IDENTITY PRIMARY KEY,
        Description NVARCHAR(255) NOT NULL
    );

    CREATE TABLE Projects (
        Id INT IDENTITY PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL,
        Description NVARCHAR(1000) NOT NULL,
        CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
        CreatorId INT NOT NULL,
        CategoryId INT NOT NULL,
        FOREIGN KEY (CreatorId) REFERENCES Users(Id),
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
    );

    CREATE TABLE Comments (
        Id INT IDENTITY PRIMARY KEY,
        Text NVARCHAR(1000) NOT NULL,
        Date DATETIME NOT NULL DEFAULT GETDATE(),
        UserId INT NOT NULL,
        ProjectId INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES Users(Id),
        FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
    );

    CREATE TABLE Votes (
        Id INT IDENTITY PRIMARY KEY,
        UserId INT NOT NULL,
        ProjectId INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES Users(Id),
        FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
    );

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;

    PRINT 'Migration failed: ' + ERROR_MESSAGE();
END CATCH;
 
GO
 
CREATE PROCEDURE CreateProject
    @Name NVARCHAR(255),
    @Description NVARCHAR(1000),
    @CreatorId INT,
    @CategoryId INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        IF (@Name IS NULL OR
            @Name = '' OR
            @Description IS NULL OR
            @Description = '' OR
            @CreatorId IS NULL OR
            @CategoryId IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;

            PRINT 'Invalid parameters';

            RETURN;
        END;

        INSERT INTO Projects (Name, Description, CreationDate, CreatorId, CategoryId)
        VALUES (@Name, @Description, GETDATE(), @CreatorId, @CategoryId);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        PRINT 'Procedure failed: ' + ERROR_MESSAGE();
    END CATCH;
END;

GO

CREATE PROCEDURE CreateComment
    @Text NVARCHAR(1000),
    @UserId INT,
    @ProjectId INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        IF (@Text IS NULL OR
            @Text = '' OR
            @UserId IS NULL OR
            @ProjectId IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;

            PRINT 'Invalid parameters';
            
            RETURN;
        END;

        INSERT INTO Comments (Text, Date, UserId, ProjectId)
        VALUES (@Text, GETDATE(), @UserId, @ProjectId);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        PRINT 'Procedure failed: ' + ERROR_MESSAGE();
    END CATCH;
END;
 
GO
 
CREATE PROCEDURE GetProjectInfo
    @ProjectId INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        IF (@ProjectId IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;
            
            PRINT 'Invalid parameters';
            
            RETURN;
        END;

        SELECT
            Projects.Id AS ProjectId, 
            Projects.Name AS ProjectName,
            Projects.Description AS ProjectDescription, 
            Projects.CreationDate AS ProjectCreationDate,
            Categories.Description AS CategoryDescription,
            Users.Name + ' ' + Users.SecondName AS CreatorFullName,
            COUNT(Votes.Id) AS VoteCount
        FROM Projects
        LEFT JOIN Categories ON Projects.CategoryId = Categories.Id
        LEFT JOIN Users ON Projects.CreatorId = Users.Id
        LEFT JOIN Votes ON Projects.Id = Votes.ProjectId
        WHERE Projects.Id = @ProjectId
        GROUP BY 
            Projects.Id,
            Projects.Name, 
            Projects.Description, 
            Projects.CreationDate, 
            Categories.Description, 
            Users.Name,
            Users.SecondName;

        SELECT 
            Comments.Id AS CommentId,
            Comments.Text AS CommentText,
            Comments.Date AS CommentDate,
            Users.Name + ' ' + Users.SecondName AS UserFullName
        FROM Comments
        INNER JOIN Users ON Comments.UserId = Users.Id
        WHERE Comments.ProjectId = @ProjectId
        ORDER BY Comments.Date;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        PRINT 'Procedure failed: ' + ERROR_MESSAGE();
    END CATCH;
END;

GO

CREATE PROCEDURE GetPaginatedProjects
    @PageNumber INT,
    @PageSize INT,
    @CategoryId INT = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        IF (@PageNumber IS NULL OR @PageSize IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;

            PRINT 'Invalid parameters';

            RETURN;
        END;

        SELECT 
            Projects.Id AS ProjectId, 
            Projects.Name AS ProjectName,
            Projects.Description AS ProjectDescription, 
            Projects.CreationDate AS ProjectCreationDate,
            Categories.Description AS CategoryDescription
        FROM Projects
        INNER JOIN Categories ON Projects.CategoryId = Categories.Id
        WHERE (@CategoryId IS NULL OR Projects.CategoryId = @CategoryId)
        AND (@StartDate IS NULL OR Projects.CreationDate >= @StartDate)
        AND (@EndDate IS NULL OR Projects.CreationDate <= @EndDate)
        ORDER BY Projects.CreationDate
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        PRINT 'Procedure failed: ' + ERROR_MESSAGE();
    END CATCH;
END;

GO

CREATE PROCEDURE AddVote
    @UserId INT,
    @ProjectId INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        IF (@UserId IS NULL OR @ProjectId IS NULL)
        BEGIN
            ROLLBACK TRANSACTION;

            PRINT 'Invalid parameters';

            RETURN;
        END;

        INSERT INTO Votes (UserId, ProjectId)
        VALUES (@UserId, @ProjectId);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        PRINT 'Procedure failed: ' + ERROR_MESSAGE();
    END CATCH;
END;
