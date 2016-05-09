using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing.Strategy
{
    public abstract class Status
    {
        public virtual Color setColor()
        {
            return Color.White;
        }

        public virtual Vector2 setSpeed()
        {
            return new Vector2(0, 0);
        }
    }
}
