using System.Collections.Generic;
using Engine.field;

namespace Engine.models
{
    public abstract class Character
    {
        public Coordinate Position;
        public abstract Coordinate GetNextMove(Field field);

        protected abstract List<Coordinate> GetAvailableMoves();
    }
}
