using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficKing.Strategy;

namespace TrafficKing
{
    public class PoliceStation
    {
        private IList<PoliceBoat> policeBoats;

        public PoliceStation()
        {
            this.policeBoats = new List<PoliceBoat>();
        }

        public void createBoat(PoliceBoat p)
        {
            this.policeBoats.Add(p);
        }

        public IList<PoliceBoat> getPoliceBoats()
        {
            return this.policeBoats;
        }
    }
}
