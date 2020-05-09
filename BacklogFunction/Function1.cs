using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BacklogFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function started executed at: {DateTime.Now}");

            // Get the connection string from app settings and use it to create a connection.
            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                var text = "SELECT Id, Url FROM dbo.CrawlJobs";

                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        log.LogInformation($"{rdr["Url"]} feed being crawled");

                        //TODO: Functionallity to crawl the Url..

                        using (SqlConnection conn2 = new SqlConnection(str))
                        {
                            conn2.Open();
                            var storedProcedure = "dbo.usp_AddArticle";

                            using (SqlCommand sp = new SqlCommand(storedProcedure, conn2))
                            {
                                // 2. set the command object so it knows to execute a stored procedure
                                cmd.CommandType = CommandType.StoredProcedure;

                                // 3. add parameter to command, which will be passed to the stored procedure
                                cmd.Parameters.Add(new SqlParameter("@CustomerID", 1));

                                // execute the command
                                var articles = await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    // Execute the command and log the # rows affected.
                    var rows = await cmd.ExecuteNonQueryAsync();
                    log.LogInformation($"{rows} feeds found for update");
                }
            }

            log.LogInformation($"C# Timer trigger function finished executed at: {DateTime.Now}");

        }
    }
}
