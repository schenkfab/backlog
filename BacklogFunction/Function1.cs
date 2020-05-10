using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace BacklogFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async void Run([TimerTrigger("0 */60 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function started executed at: {DateTime.Now}");

            // Get the connection string from app settings and use it to create a connection.
            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                var text = "SELECT Id, Url FROM dbo.CrawlJobs";
                Console.WriteLine("HI");

                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        log.LogInformation($"{rdr["Url"]} feed being crawled");

                        List<Article> articles = GetArticles(rdr["Url"].ToString());

                        foreach (Article a in articles)
                        {
                            using (SqlConnection conn2 = new SqlConnection(str))
                            {
                                conn2.Open();
                                var storedProcedure = "dbo.usp_AddArticle";

                                using (SqlCommand sp = new SqlCommand(storedProcedure, conn2))
                                {
                                    // 2. set the command object so it knows to execute a stored procedure
                                    sp.CommandType = CommandType.StoredProcedure;

                                    // 3. add parameter to command, which will be passed to the stored procedure
                                    sp.Parameters.Add(new SqlParameter("@Name", a.Name));
                                    sp.Parameters.Add(new SqlParameter("@Picture", a.Image));
                                    sp.Parameters.Add(new SqlParameter("@Description", a.Description));
                                    sp.Parameters.Add(new SqlParameter("@Date", a.Created));
                                    sp.Parameters.Add(new SqlParameter("@FeedId", Int32.Parse(rdr["Id"].ToString())));
                                    sp.Parameters.Add(new SqlParameter("@Link", a.Link));

                                    // execute the command
                                    var art = await sp.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        // Set the last crawled date of rdr["Id"] to the current date:
                        using (SqlConnection conn3 = new SqlConnection(str))
                        {
                            conn3.Open();
                            string storedProcedure = "dbo.usp_FinishCrawl";

                            using (SqlCommand sp = new SqlCommand(storedProcedure, conn3))
                            {
                                sp.CommandType = CommandType.StoredProcedure;
                                sp.Parameters.Add(new SqlParameter("@FeedId", Int32.Parse(rdr["Id"].ToString())));

                                await sp.ExecuteNonQueryAsync();
                            }
                        }

                        log.LogInformation($"{rdr["Url"]} feed being crawled");                   
                    }
                }
            }

            log.LogInformation($"C# Timer trigger function finished executed at: {DateTime.Now}");

        }

        public static List<Article> GetArticles(string url)
        {
            List<Article> articles = new List<Article>();

            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                string subject = item.Title.Text;
                string summary = item.Summary.Text;
                string image = feed.ImageUrl.ToString();
                string link = item.Links[0].Uri.ToString();
                string created = item.PublishDate.UtcDateTime.ToString("yyyy-MM-dd HH':'mm':'ss");

                articles.Add(new Article() { Name = subject, Description = summary, Image = image, Link = link, Created = created });
            }


            return articles;
        }

        public class Article
        {
            public string Name { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public string Created { get; set; }
            public string Link { get; set; }
        }
    }
}
