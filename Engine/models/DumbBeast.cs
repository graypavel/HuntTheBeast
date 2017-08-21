using System;
using System.Collections.Generic;
using Engine.field;
using Engine.interfaces;

namespace Engine.models
{
    public class DumbBeast : AbstactBeast, IWalker
    {
        public void Walk()
        {
            throw new NotImplementedException();
        }

        public void Move(Coordinate position)
        {
            throw new NotImplementedException();
        }

        public override Coordinate GetNextMove(Field field)
        {
            var moves = GetAvailableMoves(field);
            if (moves.Count == 0)
                throw new Exception("Зверь загнан в ловушку!");
            var rnd = new Random();
            var randomPosition = moves[rnd.Next(moves.Count)];
            return randomPosition;
        }

        protected override List<Coordinate> GetAvailableMoves(Field field)
        {
            var moves = new List<Coordinate>();
            var up = new Coordinate(Position.x - 1, Position.y);
            if (field.IsPositionFreeToMove(up))
                moves.Add(up);
            var down = new Coordinate(Position.x + 1, Position.y);
            if (field.IsPositionFreeToMove(down))
                moves.Add(down);
            var left = new Coordinate(Position.x, Position.y - 1);
            if (field.IsPositionFreeToMove(left))
                moves.Add(left);
            var right = new Coordinate(Position.x, Position.y + 1);
            if (field.IsPositionFreeToMove(right))
                moves.Add(right);
            return moves;
        }


    }
}
