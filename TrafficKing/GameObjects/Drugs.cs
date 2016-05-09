using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing.GameObjects
{
    public class Drugs : GameObject
    {
        public Drugs(Vector2 position)
            :base(position)
        {
            Position = position;
            Texture = AssetsManager.Drugs;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }
    }
}
