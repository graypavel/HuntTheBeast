namespace Engine.models
{
    public abstract class Character
    {
        public Coordinate Position;

        public abstract void Move(Coordinate position);
    }
}
