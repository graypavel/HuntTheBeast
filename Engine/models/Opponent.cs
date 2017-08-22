using System;
using Engine.field;
using Engine.interfaces;

namespace Engine.models
{
    public class Opponent
    {
        private Field field;

        public void MakeMove(Field gameField)
        {
            field = gameField;
            var beast = FindBeast();
            if (beast is ICowardBeast)
            {
                var runPosition = (beast as ICowardBeast).Run(field);
                if (field.IsTrapInPosition(runPosition))
                    throw new Exception("Зверь попался в ловушку!");
                field.MoveCharacter(beast.Position, runPosition);
            }
            else if (beast is IAgressiveBeast)
            {
                //var hunters = GetHuntersPosition(field)
                //var hunterPosition = DetectNearestHunter(hunters)
                //Chase(hunterPosition)
            }
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
