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
            var beast = FindBeast();
            var movePosition = beast.GetNextMove(field);
            if(field.IsTrapInPosition(movePosition))
                throw new Exception("Зверь попался в ловушку!");
            field.MoveCharacter(beast.Position, movePosition);
        }

        private Character FindBeast()
        {
            for (var i = 0; i < field.Width; i++)
            for (var j = 0; j < field.Height; j++)
            {
                var position = new Coordinate(i, j);
                var tile = field.GetTile(position);
                if (tile.Character != null && !(tile.Character is Hunter))
                    return tile.Character;
            }
            throw new Exception("Зверь на поле не найден!");
        }
    }
}
