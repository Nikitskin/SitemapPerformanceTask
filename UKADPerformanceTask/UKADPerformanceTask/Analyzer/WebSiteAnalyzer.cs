using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace UKADPerformanceTask.Analyzer
{
    public class WebSiteAnalyzer
    {
        private string _url;

        public WebSiteAnalyzer(string Url)
        {
            if (!string.IsNullOrEmpty(Url))
            {
                _url = Url;
            }
            else
            {
                _url = string.Empty;
            }
        }

        public List<string> returnSiteMap()
        {
            List<string> urls = new List<string>();
            if (!string.IsNullOrEmpty(_url))
            {
                
                XmlReader xmlReader = new XmlTextReader(string.Format("{0}sitemap.xml", _url));
                XPathDocument document = new XPathDocument(xmlReader);
                XPathNavigator navigator = document.CreateNavigator();

                var namespaces = navigator.GetNamespacesInScope(XmlNamespaceScope.All);
                XmlNamespaceManager resolver = new XmlNamespaceManager(xmlReader.NameTable);
                resolver.AddNamespace(namespaces.Keys.FirstOrDefault(), namespaces.Values.FirstOrDefault());
                //resolver.AddNamespace("sitemap", "https://www.sitemaps.org/schemas/sitemap/0.9");

                XPathNodeIterator iterator = navigator.Select("//sitemap:loc", resolver);
                
                foreach(XPathNavigator node in iterator)
                {
                    urls.Add(node.Value);
                }

            }
            return urls;
        }

    }
}