using System;
using System.IO;
using System.Xml;

namespace CabApplication.Common
{
    public class MultiLanguageHelper
    {
        private XmlDocument _Document;
        public XmlDocument Document
        {
            set { _Document = value; }
            get { return _Document; }
        }

        private string _XMLConfigFile = "";
        public string XMLConfigFile
        {
            set { _XMLConfigFile = value; }
            get { return _XMLConfigFile; }
        }

        private string _LanguageCode = "";
        public string LanguageCode
        {
            set { _LanguageCode = value; }
            get { return _LanguageCode; }
        }

        public MultiLanguageHelper(string languageCode)
        {
            LanguageCode = languageCode;
            XMLConfigFile = GetLanguageConfigFileName();

            if (Document == null)
            {
                StreamReader file = new StreamReader(XMLConfigFile);
                Document = new XmlDocument();
                Document.Load(file);
            }
        }

        private string GetLanguageConfigFileName()
        {
            return @"Languages\Language_" + LanguageCode + ".xml";
        }

        public string GetLanguageString(string sectionName, string configName)
        {
            string result = "";
            try
            {
                XmlNodeList configNodes = Document.SelectNodes("//" + configName);
                foreach (XmlNode node in configNodes)
                {
                    if (node.Name == configName && node.ParentNode.Name == sectionName)
                    {
                        result = node.InnerText;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                string msg = "Can not find the language settings node: " + sectionName + " - " + configName;
                Framework.Core.Logging.LoggerHelper.WriteDebugLog(msg);
            }
            return result;
        }
    }
}
