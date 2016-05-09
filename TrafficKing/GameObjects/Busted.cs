using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing.GameObjects
{
    public class Busted : GameObject
    {
        private Boolean busted;

        public Busted(Vector2 position)
            : base(position)
        {
            Position = position;
            Texture = AssetsManager.Busted;
            busted = false;
        }

        public void setBusted(Boolean b)
        {
            this.busted = b;
        }

        public Boolean getBusted()
        {
            return this.busted;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
