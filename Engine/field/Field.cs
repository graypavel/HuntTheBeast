using System.Collections.Generic;
using Engine.models;

namespace Engine.field
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Tile[,] Tiles { get; set; }

        private List<Hunter> Hunters;
        public List<Beast> Monsters;

        public Field(Tile[,] tiles)
        {
            Tiles = tiles;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            Hunters = new List<Hunter>();
            Monsters = new List<Beast>();
        }

        

        public bool IsPositionFreeToMove(Coordinate position)
        {
            var tyleToMove = Tiles[position.x,position.y];
            switch (tyleToMove.Type)
            {
                case Tile.TileType.Trap:
                    return false;
            }
            foreach (var hunter in Hunters)
            {
                if (hunter.Position == position)
                    return false;
            }
            return true;
        }
    }
}
