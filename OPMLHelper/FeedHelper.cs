using System;
using System.Xml;
using System.ServiceModel.Syndication;

namespace OPMLHelper
{
    public class FeedHelper
    {
        public bool isLoaded { get; set; }
        public string Error { get; set; }
        public FeedHelper(string url)
        {
            try
            {
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                if (feed.Title.Text == null)
                {
                    isLoaded = false;
                }
                else
                {
                    isLoaded = true;
                }
                reader.Close();
            } catch (Exception ex)
            {
                Error = ex.Message;
                isLoaded = false;
            }
        }
    }
}
