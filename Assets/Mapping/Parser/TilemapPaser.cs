using System.IO;
using UnityEngine;

namespace Mapping.Parser
{
    public class TilemapPaser
    {
        public static TilemapModel ParseTilemap(string json)
        {
            return JsonUtility.FromJson<TilemapModel>(json);
        }
    }
}