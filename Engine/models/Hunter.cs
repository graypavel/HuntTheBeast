using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.interfaces;

namespace Engine.models
{
    public class Hunter: Character, IWalker
    {
        public Coordinate Position;

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
