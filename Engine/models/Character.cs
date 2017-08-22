using System.Collections.Generic;
using Engine.field;

namespace Engine.models
{
    public abstract class Character
    {
        public Coordinate Position;

        protected abstract List<Coordinate> GetAvailableMoves();

        protected bool CanMoveToTile(Tile.TileType type)
        {
            switch (type)
            {
                case Tile.TileType.Common:
                    return true;
                case Tile.TileType.Trap:
                    return false;
                default:
                    return false;
            }
        }
    }
}
