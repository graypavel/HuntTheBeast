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
            return Tiles[position.X, position.Y];
        }

        public void AddCharacter(Character character)
        {
            Tiles[character.Position.X, character.Position.Y].Character = character;
        }

        public bool IsPositionBlank(Coordinate position)
        {
            try
            {
                var tile = Tiles[position.X, position.Y];
                switch (tile.Type)
                {
                    case Tile.TileType.Trap:
                        return false;
                }
                return Tiles[position.X, position.Y].Character == null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsPositionFree(Coordinate position)
        {
            try
            {
                return Tiles[position.X, position.Y].Character == null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsTrapInPosition(Coordinate position)
        {
            return Tiles[position.X, position.Y].Type == Tile.TileType.Trap;
        }

        public void MoveCharacter(Coordinate source, Coordinate destination)
        {
            if(Tiles[source.X,source.Y].Character == null)
                throw new Exception("В позиции источнике нет персонажа");
            var sourceTile = GetTile(source);
            var destinationTile = GetTile(destination);
            destinationTile.Character = sourceTile.Character;
            destinationTile.Character.Position = destination;
            sourceTile.Character = null;
        }

        
    }
}
