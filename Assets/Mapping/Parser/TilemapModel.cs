using System;
using System.Collections.Generic;
using System.Globalization;

namespace Mapping.Parser
{
    public class TilemapModel
    {
        public int tileheight { get; set; }

        public int tilewidth { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public string backgroundcolor { get; set; }

        public IList<TilemapLayerModel> layers { get; set; }
    }


    public class TilemapLayerModel
    {
        public uint[] data { get; set; }

        public TilemapLayerObjectModel[] objects { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public int id { get; set; }

        public float opacity { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public CustomPropertyModel[] properties { get; set; }
    }
    
    public class CustomPropertyModel
    {
        public string name { get; set; }

        public string type { get; set; }

        public object value { get; set; }

        public T ValueAsType<T>()
        {
            return (T)Convert.ChangeType(this.value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
    
    public class TilemapLayerObjectModel
    {
        public float x { get; set; }

        public float y { get; set; }

        public float width { get; set; }

        public float height { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public bool point { get; set; }

        public string type { get; set; }

        public CustomPropertyModel[] properties { get; set; }
    }
}