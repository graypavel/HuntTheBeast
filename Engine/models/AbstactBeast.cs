using System.Collections.Generic;
using Engine.field;

namespace Engine.models
{
    public abstract class AbstactBeast: Character
    {
        protected abstract List<Coordinate> GetAvailableMoves(Field field);
    }
}
