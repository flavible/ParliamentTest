using System;
using System.Xml;
using System.IO;
using CommonsDomain;
using System.Net;

namespace ParliamentServices
{
    public class ParliamentService {
        public string URI { get; set; }

        public XmlDocument GetXMLFromURI(string extension) {
            Console.WriteLine(URI+extension);
            string xmlString = (new WebClient()).DownloadString(URI+extension);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            return doc;
        }

        public string GetXmlValue(XmlNode xnode, string cnode) {
            try
            {
                return xnode.SelectSingleNode(cnode).InnerText;
            }catch(Exception e) {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public string GetXmlAttribute(XmlNode xNode, string attribute) {
            try{
                return xNode.Attributes[attribute].Value;
            }catch(Exception e) {
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}
