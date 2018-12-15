using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using Newtonsoft.Json;

public class XML2JSON {
    public XmlDocument ParseXMLData(string data){
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        return doc;
    }

    public string JsonToXml(XmlDocument doc){
        string json = JsonConvert.SerializeXmlNode(doc);
        return json;
    }

    
}
