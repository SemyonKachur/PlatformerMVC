using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "LevelGeneratorData", menuName = "Level/LevelGeneratorData")]
    public class LevelGeneratorData : ScriptableObject
    {
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _mapHeight;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _factorSmooth;
        [SerializeField] [Range(0, 100)] private int _fillPercent;

        public Tile GroundTile { get => _groundTile; set => _groundTile = value; }
        public int MapWidth { get => _mapWidth; set => _mapWidth = value; }
        public int MapHeight { get => _mapHeight; set => _mapHeight = value; }
        public int FactorSmooth { get => _factorSmooth; set => _factorSmooth = value; }
        public int FillPercent { get => _fillPercent; set => _fillPercent = value; }
        public bool Borders { get => _borders; set => _borders = value; }
    }
}
