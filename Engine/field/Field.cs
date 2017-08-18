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
        private List<Beast> Monsters;

        public Field(Tile[,] tiles)
        {
            Tiles = tiles;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            Hunters = new List<Hunter>();
            Monsters = new List<Beast>();
        }

        public void AddHunter(Hunter hunter)
        {
            Hunters.Add(hunter);
            Tiles[hunter.Position.x, hunter.Position.y].Character = hunter;
        }

        public void AddMonster(Beast beast)
        {
            Monsters.Add(beast);
            Tiles[beast.Position.x, beast.Position.y].Character = beast;
        }

        public bool IsPositionFreeToMove(Coordinate position)
        {
            var tyleToMove = Tiles[position.x,position.y];
            switch (tyleToMove.Type)
            {
                case Tile.TileType.Trap:
                    return false;
            }
            return Tiles[position.x, position.y].Character == null;
        }
    }
}
