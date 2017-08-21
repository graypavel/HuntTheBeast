using System;
using System.Collections.Generic;
using Engine.field;

namespace Engine.models
{
    public class Beast : Character
    {
        protected Field Field;

        public override Coordinate GetNextMove(Field field)
        {
            Field = field;
            var moves = GetAvailableMoves();
            if (moves.Count == 0)
                throw new Exception("Зверю некуда идти!");
            return SelectMove(moves);
        }

        protected override List<Coordinate> GetAvailableMoves()
        {
            var moves = new List<Coordinate>();
            var up = new Coordinate(Position.X - 1, Position.Y);
            if (Field.IsPositionFree(up))
                moves.Add(up);
            var down = new Coordinate(Position.X + 1, Position.Y);
            if (Field.IsPositionFree(down))
                moves.Add(down);
            var left = new Coordinate(Position.X, Position.Y - 1);
            if (Field.IsPositionFree(left))
                moves.Add(left);
            var right = new Coordinate(Position.X, Position.Y + 1);
            if (Field.IsPositionFree(right))
                moves.Add(right);
            return moves;
        }

        protected Coordinate SelectMove(List<Coordinate> moves)
        {
            var rnd = new Random();
            var randomPosition = moves[rnd.Next(moves.Count)];
            return randomPosition;
        }
    }
}
