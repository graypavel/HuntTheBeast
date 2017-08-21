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
            field.MoveCharacter(beast.Position, movePosition);
        }

        private AbstactBeast FindBeast()
        {
            for (var i = 0; i < field.Width; i++)
            for (var j = 0; j < field.Height; j++)
            {
                var position = new Coordinate(i, j);
                var tile = field.GetTile(position);
                if (tile.Character is AbstactBeast)
                    return (AbstactBeast) tile.Character;
            }
            throw new Exception("Зверь на поле не найден!");
        }

        //private List<Coordinate> GetAvailableMoves(Coordinate position)
        //{
        //    var moves = new List<Coordinate>();
        //    var up = new Coordinate(position.x - 1, position.y);
        //    if(field.IsPositionFreeToMove(up))
        //        moves.Add(up);
        //    var down = new Coordinate(position.x + 1, position.y);
        //    if (field.IsPositionFreeToMove(down))
        //        moves.Add(down);
        //    var left = new Coordinate(position.x, position.y - 1);
        //    if (field.IsPositionFreeToMove(left))
        //        moves.Add(left);
        //    var right = new Coordinate(position.x, position.y + 1);
        //    if (field.IsPositionFreeToMove(right))
        //        moves.Add(right);
        //    return moves;
        //}
    }
}
