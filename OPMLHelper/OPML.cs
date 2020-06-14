using System;
using System.Xml;

namespace OPMLHelper
{
    public class OPML
    {
        public OPML(string location)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(location);
            foreach (XmlNode child in doc.ChildNodes)
            {
                Console.WriteLine(child);
            }
        }
    }
}
