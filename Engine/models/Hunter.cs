using System;
using System.Collections.Generic;
using Engine.field;

namespace Engine.models
{
    public class Hunter: Character
    {
        public override Coordinate GetNextMove(Field field)
        {
            //Реализуем, если потребуется автоматизировать охотников
            throw new NotImplementedException();
        }

        protected override List<Coordinate> GetAvailableMoves()
        {
            //Реализуем, если потребуется автоматизировать охотников
            throw new NotImplementedException();
        }
    }
}
