using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace OPMLHelper
{
    public class OPML
    {
        public List<Outline> outlines;

        public OPML(string xml)
        {
            outlines = new List<Outline>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
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
                                var ol = new Outline
                                {
                                    Title = outline.Attributes["title"].Value,
                                    Feeds = new List<RSS>()
                                };
                                List<XmlNode> nodes = new List<XmlNode>();
                                foreach(XmlNode n in outline.ChildNodes)
                                {
                                    nodes.Add(n);
                                }

                                Parallel.ForEach(nodes, n =>
                                {
                                    RSS feed = new RSS
                                    {
                                        Title = n.Attributes["title"].Value,
                                        xmlUrl = n.Attributes["xmlUrl"].Value
                                    };
                                    FeedHelper feedHelper = new FeedHelper(feed.xmlUrl);
                                    if (feedHelper.isLoaded)
                                    {
                                        feed.Found = true;
                                    }
                                    else
                                    {
                                        feed.Found = false;
                                        feed.Error = feedHelper.Error;
                                    }
                                    ol.Feeds.Add(feed);
                                });
                                outlines.Add(ol);
                            }
                        }
                    }
                }
            }
        }
    }
}
