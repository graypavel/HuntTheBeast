namespace Engine.field
{
    public class FieldTemplate
    {
        public const int MaxWidth = 50;
        public const int MaxHeight = 50;

        public readonly int Width;
        public readonly int Height;
        public readonly int HuntersCount;
        public readonly int MonstersCount;
        public readonly int TrapsCount;

        public FieldTemplate(int width, int height, int hunters, int monsters, int traps)
        {
            Width = width;
            Height = height;
            HuntersCount = hunters;
            MonstersCount = monsters;
            TrapsCount = traps;
        }
    }
}
