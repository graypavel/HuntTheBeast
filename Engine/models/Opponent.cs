using System;
using Engine.field;

namespace Engine.models
{
    public class Opponent
    {
        private Field field;

        public void MakeMove(Field gameField)
        {
            field = gameField;
            var beastPosition = GetBeastPosition();
        }

        private Coordinate GetBeastPosition()
        {
            for (var i = 0; i < field.Width; i++)
            for (var j = 0; j < field.Height; j++)
            {
                var position = new Coordinate(i, j);
                var tile = field.GetTile(position);
                if (tile.Character is Beast)
                    return position;
            }
            throw new Exception("Зверь на поле не найден!");
        }
    }
}
