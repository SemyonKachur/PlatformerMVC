using UnityEngine;
using UnityEngine.Tilemaps;

namespace Level
{
    public class MarchingSquaresGeneratorLevel
    {
        private SquareGrid _squareGrid;
        private Tilemap _tileMapGround;
        private Tile _tileGround;

        public void GenerateGrid(int[,] map, float squareSize)
        {
            _squareGrid = new SquareGrid(map, squareSize);
        }

        public void DrawTilesOnMap(Tilemap tileMapGround, Tile tileGround)
        {
            if (_squareGrid == null)
                return;

            _tileMapGround = tileMapGround;
            _tileGround = tileGround;

            for (var x = 0; x < _squareGrid.Squares.GetLength(0); x++)
            {
                for (var y = 0; y < _squareGrid.Squares.GetLength(1); y++)
                {

                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopLeft.Active,
                        _squareGrid.Squares[x, y].TopLeft.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopRight.Active,
                        _squareGrid.Squares[x, y].TopRight.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomRight.Active,
                        _squareGrid.Squares[x, y].BottomRight.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomLeft.Active,
                        _squareGrid.Squares[x, y].BottomLeft.Position);
                }
            }
        }

        private void DrawTileInControlNode(bool active, Vector3 position)
        {
            if (active)
            {
                var positionTile = new Vector3Int((int)position.x, (int)position.y, 0);
                _tileMapGround.SetTile(positionTile, _tileGround);
            }
        }
    }

    public class Node
    {
        public Vector3 Position;

        public Node(Vector3 _pos)
        {
            Position = _pos;
        }
    }

    public class ControlNode : Node
    {
        public bool Active;

        public ControlNode(Vector3 pos, bool active) : base(pos)
        {
            Active = active;
        }
    }

    public class Square
    {
        public ControlNode TopLeft, TopRight, BottomRight, BottomLeft;

        public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomRight, ControlNode bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
        }
    }

    public class SquareGrid
    {
        public Square[,] Squares;

        public SquareGrid(int[,] map, float squareSize)
        {
            var nodeCountX = map.GetLength(0);
            var nodeCountY = map.GetLength(1);
            var mapWidth = nodeCountX * squareSize;
            var mapHeight = nodeCountY * squareSize;

            var controlNodes = new ControlNode[nodeCountX, nodeCountY];

            for (var x = 0; x < nodeCountX; x++)
            {
                for (var y = 0; y < nodeCountY; y++)
                {
                    var position = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2, -mapHeight / 2 + y * squareSize + squareSize / 2);
                    controlNodes[x, y] = new ControlNode(position, map[x, y] == 1);
                }
            }

            Squares = new Square[nodeCountX - 1, nodeCountY - 1];

            for (var x = 0; x < nodeCountX - 1; x++)
            {
                for (var y = 0; y < nodeCountY - 1; y++)
                {
                    Squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1],
                        controlNodes[x + 1, y], controlNodes[x, y]);
                }
            }
        }
    }
}
