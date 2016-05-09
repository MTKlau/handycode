using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing.Strategy
{
    public class Patrolling : Status
    {
        public Patrolling()
        {
            
        }

        public override Color setColor()
        {
            return Color.Green;
        }

        public override Vector2 setSpeed()
        {
            return new Vector2(2, 2);
        }
    }
}
