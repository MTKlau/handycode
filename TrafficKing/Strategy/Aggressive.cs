using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficKing.GameObjects;

namespace TrafficKing.Strategy
{
    public class Aggressive : Status
    {
        private Busted busted;

        public Aggressive()
        {
            busted = new Busted(new Vector2(0, 0));
        }

        public void checkCollision(PoliceBoat p, DrugsBoat d)
        {
            if(p.getRectangle().Intersects(d.getRectangle()))
            {
                busted.setBusted(true);
            }
        }

        public override Color setColor()
        {
            return Color.Red;
        }

        public override Vector2 setSpeed()
        {
            return new Vector2(4, 4);
        }
    }
}
