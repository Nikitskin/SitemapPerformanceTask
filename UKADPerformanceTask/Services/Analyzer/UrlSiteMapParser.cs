using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Analyzer
{
    public class UrlSiteMapParser : IAnalyzer
    {
        private const string DEFAULT = "DEFAULT";

        public List<string> ReturnSiteMap(string url)
        {
            List<string> urls = new List<string>();
            if (!string.IsNullOrEmpty(url))
            {
                
                XmlReader xmlReader = new XmlTextReader(string.Format("{0}sitemap.xml", url));
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