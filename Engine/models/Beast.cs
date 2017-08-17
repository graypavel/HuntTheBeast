using System;
using Engine.interfaces;

namespace Engine.models
{
    public class Beast : Character, IWalker
    {
        public void Walk()
        {
            throw new NotImplementedException();
        }

        public override void Move(Coordinate position)
        {
            throw new NotImplementedException();
        }
    }
}
