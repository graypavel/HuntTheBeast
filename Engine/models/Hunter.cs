using System;
using Engine.field;
using Engine.interfaces;

namespace Engine.models
{
    public class Hunter: Character, IWalker
    {
        public void Walk()
        {
            throw new NotImplementedException();
        }

        public override Coordinate GetNextMove(Field field)
        {
            //Реализуем, если потребуется автоматизировать охотников
            throw new NotImplementedException();
        }
    }
}
