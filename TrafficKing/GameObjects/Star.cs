using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing.GameObjects
{
    public class Star:GameObject
    {
        public Star(Vector2 position)
            : base(position)
        {
            Position = position;
            Texture = AssetsManager.Star;
        }
    }
}
