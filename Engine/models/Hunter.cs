using System;
using Engine.interfaces;

namespace Engine.models
{
    public class Hunter: Character, IWalker
    {
        public override void Move(Coordinate position)
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
