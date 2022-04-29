using System.IO;
using Mapping.Parser;
using UnityEditor;
using UnityEngine;

namespace Mapping
{
    public class MapImporter : MonoBehaviour
    {
        [MenuItem("Tools/Import Tiled Map (json)...")]
        static void ImportMap()
        {
            string path = EditorUtility.OpenFilePanel("Select a map", Application.dataPath, "json");
            if (path.Length != 0)
            {
                string json = File.ReadAllText(path);
                TilemapModel model = TilemapPaser.ParseTilemap(json);
            }
        }
    }
}