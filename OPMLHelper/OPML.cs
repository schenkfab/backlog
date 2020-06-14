using System;
using System.Collections.Generic;
using System.Xml;

namespace OPMLHelper
{
    public class OPML
    {
        public List<Outline> outlines;

        public OPML(string location)
        {
            outlines = new List<Outline>();
            XmlDocument doc = new XmlDocument();
            doc.Load(location);
            foreach (XmlNode child in doc.ChildNodes)
            {
                if (child.Name.Equals("opml", StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach(XmlNode headbody in child.ChildNodes)
                    {
                        if (headbody.Name.Equals("body", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach (XmlNode outline in headbody.ChildNodes)
                            {
                                var ol = new Outline();
                                ol.Title = outline.Attributes["title"].Value;
                                ol.Feeds = new List<RSS>();
                                foreach (XmlNode rss in outline.ChildNodes)
                                {
                                    RSS feed = new RSS();
                                    feed.Title = rss.Attributes["title"].Value;
                                    feed.xmlUrl = rss.Attributes["xmlUrl"].Value;
                                    FeedHelper feedHelper = new FeedHelper(feed.xmlUrl);
                                    if (feedHelper.isLoaded)
                                    {
                                        feed.Found = true;
                                    } else
                                    {
                                        feed.Found = false;
                                        feed.Error = feedHelper.Error;
                                    }
                                    ol.Feeds.Add(feed);
                                }
                                outlines.Add(ol);
                            }
                        }
                    }
                }
            }
        }
    }
}
