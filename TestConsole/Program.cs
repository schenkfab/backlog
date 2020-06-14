using System;
using OPMLHelper;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new OPML("/Users/faschenk/Downloads/sql-server.opml.xml");

            foreach (var item in helper.outlines)
            {
                Console.WriteLine(item.Title);
                foreach (var feed in item.Feeds)
                {
                    Console.WriteLine(feed.Title + ": " + feed.Found);
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
