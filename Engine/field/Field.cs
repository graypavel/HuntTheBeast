using System;
using Engine.models;

namespace Engine.field
{
    public class Field
    {
        public int Width { get; }
        public int Height { get; }


        private Tile[,] Tiles { get; }

        public Field(Tile[,] tiles)
        {
            Tiles = tiles;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
        }

        public Tile GetTile(Coordinate position)
        {
            return Tiles[position.x, position.y];
        }

        public void AddHunter(Hunter hunter)
        {
            Tiles[hunter.Position.x, hunter.Position.y].Character = hunter;
        }

        public void AddMonster(Beast beast)
        {
            Tiles[beast.Position.x, beast.Position.y].Character = beast;
        }

        public bool IsPositionFreeToMove(Coordinate position)
        {
            var tileToMove = Tiles[position.x,position.y];
            switch (tileToMove.Type)
            {
                case Tile.TileType.Trap:
                    return false;
            }
            return Tiles[position.x, position.y].Character == null;
        }

        public void MoveCharacter(Coordinate source, Coordinate destination)
        {
            if(Tiles[source.x,source.y].Character == null)
                throw new Exception("В позиции источнике нет персонажа");
        }
    }
}
