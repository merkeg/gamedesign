using System;
using System.IO;
using System.Xml.Serialization;
using Mapping.Parser;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace Mapping
{
    #if UNITY_EDITOR
    public class MapImporter : EditorWindow
    {
        
        [MenuItem("Tools/Tilemap loader window")]
        public static void ShowWindow()
        {
            GetWindow<MapImporter>("Tilemap loader");
        }

        public Tileset tileset;
        public String tilemapPath;
        public GameObject parent;
        public Vector3 scale = new Vector3(1, 1, 1);
        
        private void OnGUI()
        {
            GUILayout.Space(20);
            GUILayout.Label(new GUIContent("Tileset settings"), EditorStyles.boldLabel);
            Object obj = EditorGUILayout.ObjectField(new GUIContent("Tileset"), tileset, typeof(Tileset), true);
            
            GUILayout.Space(20);
            GUILayout.Label(new GUIContent("Tilemap settings"), EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            tilemapPath = EditorGUILayout.TextField("Tilemap Filepath", tilemapPath);
            if (GUILayout.Button("...", GUILayout.MaxWidth(20)))
            {
                string path = EditorUtility.OpenFilePanel("Select a map", Application.dataPath, "tmx");
                if (path.Length != 0)
                {
                    tilemapPath = path;
                    Repaint();
                }
            }
            EditorGUILayout.EndHorizontal();

            scale = EditorGUILayout.Vector3Field("Scale", scale);
            GUILayout.Space(20);
            
            
            if (GUILayout.Button("Load tilemap into Game"))
            {
                TilemapModel model = LoadTilemap();
                // Debug.Log(JsonUtility.ToJson(model));
                TilemapMapper.MapTilemapIntoGame(tileset, model, scale);
            }
            
            if (obj is Tileset)
            {
                tileset = (Tileset) obj;
            }
        }

        public TilemapModel LoadTilemap()
        {
            TilemapModel model;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TilemapModel));
                StreamReader reader = new StreamReader(tilemapPath);
                model = (TilemapModel) serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent("Error while loading tilemap: " + e.Message));
                throw;
            }

            return model;

        }
    }
    #endif
}