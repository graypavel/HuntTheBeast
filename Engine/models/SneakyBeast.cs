using System.Collections.Generic;
using System.Linq;
using Engine.field;

namespace Engine.models
{
    public class SneakyBeast: Beast
    {
        protected override List<Coordinate> GetAvailableMoves()
        {
            var allMoves = base.GetAvailableMoves();
            return allMoves.Where(move => !Field.IsTrapInPosition(move)).ToList();
        }
    }
}
