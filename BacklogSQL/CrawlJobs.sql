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
    @Link NVARCHAR(512),
    @Author NVARCHAR(512) = NULL
AS
BEGIN
    DECLARE @exists INT = 0

    IF NOT EXISTS (SELECT *
      FROM dbo.Articles
     WHERE Name = @Name AND FeedId = @FeedId)
    BEGIN
        INSERT INTO dbo.Articles (Name, Picture, Description, Date, FeedId, Author, CreatedDate, UpdatedDate, Link)
        VALUES (@Name, @Picture, @Description, @Date, @FeedId, @Author, GETDATE(), GETDATE(), @Link)
    END
END

GO

-- EXEC dbo.usp_AddArticle @Name = 'Test', @Picture = NULL, @Description = 'Test Test', @Date = '2019-01-01', @FeedId = 1, @Author= 'Me'

-- SELECT * FROM dbo.Articles

GO

CREATE PROCEDURE [dbo].[usp_FinishCrawl]
    @FeedId BIGINT
AS
BEGIN
    UPDATE dbo.Feeds
       SET LastCrawl = GETDATE()
     WHERE Id = @FeedId

    INSERT INTO dbo.BoardItems (CreatedDate, UpdatedDate, Status, UserId, ArticleId, SubscriptionId)
    SELECT GETDATE(), GETDATE(), 0, s.UserId, a.Id, s.Id FROM [dbo].[Subscriptions] s
    INNER JOIN dbo.Articles a ON a.FeedId = s.FeedId
    LEFT JOIN dbo.BoardItems bi ON bi.UserId = s.UserId AND bi.ArticleId = a.Id AND bi.SubscriptionId = s.id
    WHERE bi.Id IS NULL
END