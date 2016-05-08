using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing
{
    public class World
    {
        private DrugsBoat _drugsBoat;
        private PoliceBoat _policeBoat;

        public World()
        {
            _drugsBoat  = new DrugsBoat(new Vector2(100, 100));
            _policeBoat = new PoliceBoat(new Vector2(600, 580));
        }


        // __________________________________________________________________________________________
        // all update functions
        // __________________________________________________________________________________________
        public void Update(GameTime gameTime)
        {
            _drugsBoat.Update(gameTime);
            _policeBoat.Update(gameTime);
        }


        // __________________________________________________________________________________________
        // draw
        // __________________________________________________________________________________________
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw background
            spriteBatch.Draw(AssetsManager.Dock, Vector2.Zero, Color.White);
            
            _drugsBoat.Draw(spriteBatch);
            _policeBoat.Draw(spriteBatch);
        }
    }
}
