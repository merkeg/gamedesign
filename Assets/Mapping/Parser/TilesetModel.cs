using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Mapping.Parser
{
    [Serializable]
    [XmlRoot("tileset")]
    public class TilesetModel
    {
        [XmlAttribute("version")]
        public string version;
        
        [XmlAttribute("tiledversion")]
        public string tiledVersion;
        
        [XmlAttribute("name")]
        public string name;
        
        [XmlAttribute("tilewidth")]
        public string tileWidth;

        [XmlAttribute("tileheight")] 
        public string tileHeight;
        
        [XmlAttribute("tilecount")] 
        public string tileCount;
        
        [XmlAttribute("columns")] 
        public string columns;
        
        
        [XmlElement("image")] public TilesetImageModel image;

        public static TilesetModel Parse(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TilesetModel));
            var stringReader = new StringReader(xml);
            var xmlReader = new XmlTextReader(stringReader);
            return serializer.Deserialize(xmlReader) as TilesetModel;
        }
    }
    
    [Serializable]
    [XmlRoot("image")]
    public class TilesetImageModel
    {
        [XmlAttribute("source")] 
        public string source;
        
        [XmlAttribute("width")] 
        public string width;

        [XmlAttribute("height")] 
        public string height;
    }
}