using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace Services.Analyzer
{
    public class UrlSiteMapParser : IAnalyzer
    {
        private string _url;
        private const string DEFAULT = "DEFAULT";

        public UrlSiteMapParser(string Url)
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

        public List<string> ReturnSiteMap()
        {
            List<string> urls = new List<string>();
            if (!string.IsNullOrEmpty(_url))
            {
                
                XmlReader xmlReader = new XmlTextReader(string.Format("{0}sitemap.xml", _url));
                XPathDocument document = new XPathDocument(xmlReader);
                XPathNavigator xNav = document.CreateNavigator();
                XmlNamespaceManager xmlNamespaceManager = getNamespaces(xmlReader, xNav);

                foreach(var namespc in xmlNamespaceManager)
                {
                    XPathNodeIterator iterator = xNav.Select(string.Format("//{0}:loc", 
                        string.IsNullOrEmpty(namespc.ToString()) ? DEFAULT : namespc), xmlNamespaceManager);

                    foreach (XPathNavigator node in iterator)
                    {
                        urls.Add(node.Value);
                    }
                }
            }
            return urls;
        }

        private XmlNamespaceManager getNamespaces(XmlReader xmlReader, XPathNavigator xNav)
        {
            XmlNamespaceManager resolver = new XmlNamespaceManager(xmlReader.NameTable);

            IDictionary<string, string> localNamespaces = null;
            while (xNav.MoveToFollowing(XPathNodeType.Element))
            {
                localNamespaces = xNav.GetNamespacesInScope(XmlNamespaceScope.Local);
                foreach (var localNamespace in localNamespaces)
                {
                    resolver.RemoveNamespace(localNamespace.Key, localNamespace.Value);
                    string prefix = string.IsNullOrEmpty(localNamespace.Key) ? DEFAULT : localNamespace.Key;
                    resolver.AddNamespace(prefix, localNamespace.Value);
                }
            }
            return resolver;
        }
    }
}