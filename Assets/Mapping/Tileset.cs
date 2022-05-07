using UnityEngine;
using UnityEngine.Tilemaps;

namespace Mapping
{
    [CreateAssetMenu(fileName = "Tileset", menuName = "Tools/Tileset", order = 0)]
    public class Tileset : ScriptableObject
    {
        public Tile[] tiles;
    }
}