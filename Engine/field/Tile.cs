using Engine.models;

namespace Engine.field
{
    public class Tile
    {
        public enum TileType
        {
            Common,
            Trap
        }

        public TileType Type { get; set; }
        public Character Character { get; set; }
        public Coordinate Coordinate { get; }

        public Tile(TileType tileType, Coordinate coordinate)
        {
            Type = tileType;
            Coordinate = coordinate;
        }
    }
}
