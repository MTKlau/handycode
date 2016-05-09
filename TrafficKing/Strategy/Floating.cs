using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing.Strategy
{
    public class Floating : Status
    {
        public Floating()
        {
            
        }

        public override Color setColor()
        {
            return Color.Blue;
        }
    }
}
