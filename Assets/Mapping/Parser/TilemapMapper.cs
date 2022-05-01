using UnityEngine;
using UnityEngine.Tilemaps;

namespace Mapping.Parser
{
    public class TilemapMapper
    {
        public static GameObject MapTilemapIntoGame(Tileset tileset, TilemapModel model, Vector3 scale)
        {
            GameObject parent = GetBaseGameObject();

            int sortingOrder = 0;
            foreach (TilemapLayerModel layer in model.Layers)
            {
                bool collision = layer.GetProperty<bool>("collision");
                GameObject layerObject = GetTilemapGameObject(layer._name, parent.transform, sortingOrder++, collision);
                Tilemap tilemap = layerObject.GetComponent<Tilemap>();

                foreach (TilemapLayerDataChunkModel chunk in layer.Data.Chunks)
                {
                    int[] data = chunk.Tiles;
                    Vector2Int chunkOffset = new Vector2Int(chunk.X, chunk.Y);

                    for (int x = 0; x < data.Length; x++)
                    {
                        if (data[x] == 0)
                        {
                            continue;
                        }
                        int xPos = x % chunk.Width;
                        int yPos = x / chunk.Width;
                        Vector3Int position = new Vector3Int(chunkOffset.x + xPos, -chunkOffset.y - yPos, 0);
                        tilemap.SetTile(position, tileset.tiles[data[x] - 1]);
                    }
                    
                    
                }
            }

            parent.transform.localScale = scale;
            return parent;
        }

        internal static GameObject GetBaseGameObject()
        {
            GameObject obj = new GameObject("Tilemap Grid");
            obj.AddComponent<Grid>();

            return obj;
        }

        internal static GameObject GetTilemapGameObject(string name, Transform parent, int sortingOrder, bool collision = false)
        {
            GameObject obj = new GameObject(name);
            obj.transform.parent = parent;
            obj.AddComponent<Tilemap>();
            var renderer = obj.AddComponent<TilemapRenderer>();
            renderer.sortingLayerName = "MidGround0";
            renderer.sortingOrder = sortingOrder;
            obj.layer = 10;
            if (collision)
            {
                obj.AddComponent<TilemapCollider2D>();
            }
            return obj;
        }
    }
}