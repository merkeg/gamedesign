using System;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

namespace Mapping.Parser
{
    [Serializable]
    [XmlRoot("map")]
    public class TilemapModel
    {
        [XmlAttribute("version")]
        public string _version;
        
        [XmlAttribute("tiledversion")]
        public string _tiledversion;
        
        [XmlAttribute("orientation")]
        public string _orientation;
        
        [XmlAttribute("renderorder")]
        public string _renderorder;
        
        [XmlAttribute("width")]
        public string _width;
        
        [XmlAttribute("height")]
        public string _height;
        
        [XmlAttribute("tilewidth")]
        public string _tilewidth;
        
        [XmlAttribute("tileheight")]
        public string _tileheight;
        
        [XmlAttribute("infinite")]
        public string _infinite;
        
        [XmlAttribute("nextlayerid")]
        public string _nextlayerid;
        
        [XmlAttribute("nextobjectid")]
        public string _nextobjectid;

        [XmlElement("tileset")]
        public TilemapTilesetModel Tileset;
        
        [XmlElement("layer", typeof(TilemapLayerModel))]
        public TilemapLayerModel[] Layers;
    }

    [Serializable]
    [XmlRoot("tileset")]
    public class TilemapTilesetModel
    {
        [XmlAttribute("firstgid")]
        public string _firstgid;
        
        [XmlAttribute("source")]
        public string _source;
    }

    [Serializable]
    [XmlRoot("layer")]
    public class TilemapLayerModel
    {
        [XmlAttribute("id")]
        public string _id;
        
        [XmlAttribute("name")]
        public string _name;
        
        [XmlAttribute("width")]
        public string _width;
        
        [XmlAttribute("height")]
        public string _height;
        
        public int Id => int.Parse(_id);
        public int Width => int.Parse(_width);
        public int Height => int.Parse(_height);
        
        [XmlElement("data")]
        public TilemapLayerDataModel Data;
        
        [XmlElement("properties")]
        public TilemapLayerPropertiesModel Properties;
        
        public T GetProperty<T>(string name)
        {
            if (Properties == null)
            {
                return default;
            }
            
            TilemapLayerPropertyModel propertyModel = Properties.Properties.FirstOrDefault(a => a.name.Equals(name));

            if (propertyModel == null)
            {
                return default;
            }

            return (T) Convert.ChangeType(propertyModel.value, typeof(T), CultureInfo.InvariantCulture);
        }
    }

    [Serializable]
    [XmlRoot("data")]
    public class TilemapLayerDataModel
    {
        [XmlAttribute("encoding")]
        public string _encoding;
        
        [XmlElement("chunk", typeof(TilemapLayerDataChunkModel))]
        public TilemapLayerDataChunkModel[] Chunks;
    }

    [Serializable]
    [XmlRoot("properties")]
    public class TilemapLayerPropertiesModel
    {
        [XmlElement("property", typeof(TilemapLayerPropertyModel))]
        public TilemapLayerPropertyModel[] Properties;
        
    }
    
    [Serializable]
    [XmlRoot("property")]
    public class TilemapLayerPropertyModel
    {
        [XmlAttribute("name")]
        public string name;
        
        [XmlAttribute("type")]
        public string type;
        
        [XmlAttribute("value")]
        public string value;
    }

    [Serializable]
    [XmlRoot("chunk")]
    public class TilemapLayerDataChunkModel
    {
        [XmlAttribute("x")]
        public string _x;
        
        [XmlAttribute("y")]
        public string _y;
        
        [XmlAttribute("width")]
        public string _width;
        
        [XmlAttribute("height")]
        public string _height;

        [XmlText]
        public string _value;

        public int[] Tiles
        {
            get
            {
                string cleared = _value.Replace("\n", "");
                string[] arr = cleared.Split(',');
                return Array.ConvertAll(arr, s => int.Parse(s));
            }
        }

        public int X => int.Parse(_x);
        public int Y => int.Parse(_y);
        public int Width => int.Parse(_width);
        public int Height => int.Parse(_height);
    }
}