using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficKing.Strategy;

namespace TrafficKing
{
    public class PoliceBoat : GameObject
    {
        public Vector2 Direction;
        private Status status;
        private Boolean hitColleagueShip;

        public PoliceBoat(Vector2 position)
            : base(position)
        {
            Position = position;
            Texture     = AssetsManager.Policeboat;
            Origin      = new Vector2(Texture.Width / 2, Texture.Height / 2);
            Rotation    = MathHelper.ToRadians(45);
            this.hitColleagueShip = false;
            
            if (Game1.Instance.Random.NextDouble() < 0.5)
            {
                Direction = new Vector2(1, -1);
            }
            else
            {
                Direction = new Vector2(-1, -1);
            }

        }

        public void setHitColleagueDetection(Boolean b)
        {
            this.hitColleagueShip = b;
        }

        public Boolean getHitColleagueDetection()
        {
            return this.hitColleagueShip;
        }

        public void setStatus(Status s)
        {
            this.status = s;
            this.Color = s.setColor();
            this.Speed = s.setSpeed();
        }

        public override void Update(GameTime gameTime)
        {
            Position += Speed * Direction;

            checkCollision();
        }

        private void checkCollision()
        {
            Rectangle ViewBounds = Game1.Instance.GraphicsDevice.Viewport.Bounds;
            if (Position.X - Origin.X < 0 || Position.X + Origin.X > ViewBounds.Right) Direction.X *= -1;
            if (Position.Y - Origin.X < 0 || Position.Y + Origin.X > ViewBounds.Bottom - 60) Direction.Y *= -1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Direction.X == 1 &&  Direction.Y == 1)   Rotation = MathHelper.ToRadians(45);
            if (Direction.X == 1 &&  Direction.Y == -1)  Rotation = MathHelper.ToRadians(-45);
            if (Direction.X == -1 && Direction.Y == 1)   Rotation = MathHelper.ToRadians(135);
            if (Direction.X == -1 && Direction.Y == -1)  Rotation = MathHelper.ToRadians(-135);

            base.Draw(spriteBatch);
        }
    }
}
