using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TrafficKing.GameObjects;
using TrafficKing.Strategy;

namespace TrafficKing
{
    public class World
    {
        private DrugsBoat drugsBoat;
        private PoliceStation policeStation;
        private Vector2 spawnPoint;
        private Busted busted;
        private int dangerLevel;
        private int bustedTime;

        private List<Drugs> drugsList = new List<Drugs>();
        private List<Star> stars = new List<Star>();

        public World()
        {
            drugsBoat = new DrugsBoat(new Vector2(200, 150));
            policeStation = new PoliceStation();
            spawnPoint = new Vector2(600, 580);
            policeStation.createBoat(new PoliceBoat(spawnPoint));
            dangerLevel = 1;
            busted = new Busted(new Vector2(0, 0));
            bustedTime = 0;
        }

        public void createNewDrugsPackage()
        {
            Random random = new Random();
            int xCoord = random.Next(0, 1000);
            int yCoord = random.Next(0, 600);
            Vector2 position = new Vector2(xCoord, yCoord);
            
            drugsList.Add(new Drugs(position));
        }

        private void checkStatus()
        {
            if (dangerLevel <= 5)
            {
                stars.Add(new Star(new Vector2(200 + 70 * dangerLevel, 10)));
                PoliceBoat newBoat = new PoliceBoat(spawnPoint);
                policeStation.createBoat(newBoat);
            }
        }

        public void pickUpDrugs()
        {
            foreach (Drugs d in drugsList.ToList())
            {
                Rectangle drugsRectangle = new Rectangle(
                (int)d.Position.X - (d.Texture.Width / 2),
                (int)d.Position.Y - (d.Texture.Height / 2),
                d.Texture.Width,
                d.Texture.Height);

                foreach (PoliceBoat p in policeStation.getPoliceBoats())
                {
                    if (p.getRectangle().Intersects(drugsRectangle))
                    {
                        drugsBoat.unregisterPolice(p);
                        drugsBoat.notifyPolice();
                        drugsList.Remove(d);
                    }

                    for (int i = 0; i < policeStation.getPoliceBoats().Count(); i++)
                    {
                        if (p.getRectangle().Contains(p.Position.X,p.Position.Y))
                        {
                        }
                        else
                        {
                        }
                    }                    

                    if (p.getRectangle().Intersects(drugsBoat.getRectangle()))
                    {
                        busted.setBusted(true);
                    }
                }

                if (drugsBoat.getRectangle().Intersects(drugsRectangle))
                {
                    dangerLevel++;
                    drugsBoat.setDangerLevel(dangerLevel);

                    checkStatus();

                    foreach (PoliceBoat p in policeStation.getPoliceBoats())
                    {
                        drugsBoat.registerPolice(p);
                    }
                    drugsBoat.notifyPolice();

                    drugsList.Remove(d);
                }
            }
        }

        // __________________________________________________________________________________________
        // all update functions
        // __________________________________________________________________________________________
        public void Update(GameTime gameTime)
        {
            drugsBoat.Update(gameTime);

            foreach (PoliceBoat p in policeStation.getPoliceBoats())
            {
                p.Update(gameTime);
            }

            pickUpDrugs();

            if (drugsList.Count < 5)
            {
                createNewDrugsPackage();
            }

            if (busted.getBusted() == true)
            {
                bustedTime++;
                
                if (bustedTime > 300)
                {
                    Game1.Instance.Exit();
                }
            }
        }


        // __________________________________________________________________________________________
        // draw
        // __________________________________________________________________________________________
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw background
            spriteBatch.Draw(AssetsManager.Dock, Vector2.Zero, Color.White);
            drugsBoat.Draw(spriteBatch);

            foreach (Star s in stars)
            {
                s.Draw(spriteBatch);
            }

            foreach (PoliceBoat p in policeStation.getPoliceBoats())
            {
                p.Draw(spriteBatch);
            }

            if (busted.getBusted() == true)
            {
                busted.Draw(spriteBatch);
            }
            else
            {
            }

            foreach (Drugs d in drugsList)
            {
                d.Draw(spriteBatch);
            }
        }
    }
}
