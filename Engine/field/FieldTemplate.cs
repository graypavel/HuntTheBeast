using System;

namespace Engine.field
{
    public class FieldTemplate
    {
        public const int MaxWidth = 50;
        public const int MaxHeight = 50;

        public int Width;
        public int Height;
        public int HuntersCount;
        public int MonstersCount;
        public int TrapsCount;

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
