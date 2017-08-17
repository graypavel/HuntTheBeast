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

        public Tile(TileType tileType)
        {
            Type = tileType;
        }
        
    }
}
