ALTER VIEW dbo.CrawlJobs
AS
SELECT TOP 5 Id, Url
  FROM dbo.Feeds
 WHERE DATEDIFF_BIG(HOUR, LastCrawl, GETDATE()) > 24

GO

ALTER PROCEDURE dbo.usp_AddArticle
    @Name NVARCHAR(512),
    @Picture NVARCHAR(512) = NULL,
    @Description NVARCHAR(512),
    @Date DATETIME2(7),
    @FeedId BIGINT,
    @Author NVARCHAR(512) = NULL
AS
BEGIN
    DECLARE @exists INT = 0

    IF NOT EXISTS (SELECT *
      FROM dbo.Articles
     WHERE Name = @Name AND FeedId = @FeedId AND Date = @Date)
    BEGIN

        INSERT INTO dbo.Articles (Name, Picture, Description, Date, FeedId, Author, CreatedDate, UpdatedDate)
        VALUES (@Name, @Picture, @Description, @Date, @FeedId, @Author, GETDATE(), GETDATE())

    END
END

GO

-- EXEC dbo.usp_AddArticle @Name = 'Test', @Picture = NULL, @Description = 'Test Test', @Date = '2019-01-01', @FeedId = 1, @Author= 'Me'

-- SELECT * FROM dbo.Articles

GO

CREATE PROCEDURE dbo.usp_FinishCrawl
    @FeedId BIGINT
AS
BEGIN
    UPDATE dbo.Feeds
       SET LastCrawl = GETDATE()
     WHERE Id = @FeedId
END