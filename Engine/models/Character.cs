using Engine.field;

namespace Engine.models
{
    public abstract class Character
    {
        public abstract Coordinate GetNextMove(Field field);
        public Coordinate Position;
    }
}
