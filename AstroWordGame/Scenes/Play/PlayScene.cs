using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Shared;
using Raylib_cs;

namespace AstroWordGame.Scenes.Play
{
    internal class PlayScene : Layer
    {
        public PlayScene(Rectangle drawArea) : base(drawArea)
        {
            AddChild(new StarsLayer(drawArea, 50, 100));
            AddChild(new StarsLayer(drawArea, 75, 60));
            AddChild(new StarsLayer(drawArea, 100, 25));
            bulletLayer = AddChild(new BulletLayer(drawArea));
            shipLayer = AddChild(new ShipLayer(drawArea));
            letterLayer = AddChild(new LettersLayer(drawArea));

        }

        private readonly BulletLayer bulletLayer;
        private readonly ShipLayer shipLayer;
        private readonly LettersLayer letterLayer;

        private string word = "";


        private int score = 0;

       

        public override void Update(float frameTime)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.R))
            {
                shipLayer.Reset();
                score = 0;
                word = "";
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                bulletLayer.Fire(shipLayer.ShipPosition);
            }

            //are any projectiles hitting letters?
            float targetSize = 40.0f;
            foreach(var target in letterLayer.ActiveLetters)
            {
                foreach(var bullet in bulletLayer.ActiveProjectiles)
                {
                    if(bullet.X >= target.Position.X &&
                    bullet.X <= target.Position.X + targetSize &&
                    bullet.Y >= target.Position.Y &&
                    bullet.Y <= target.Position.Y + targetSize)
                    {
                        letterLayer.DestroyLetter(target);
                        bulletLayer.DestroyBullet(bullet);
                        word = word + target.Letter;
                        score = score + 100;
                    }
                }
            }
            

            base.Update(frameTime);
        }


       

        public override void Draw()
        {
            Raylib.DrawText($"Bullets: {bulletLayer.ActiveProjectiles.Count()}", 20, 20, 20, Color.Red);
            Raylib.DrawText($"Score: {score}", 20, 40, 20, Color.Red);
            Raylib.DrawText($"Collected: {word}", 20, 60, 20, Color.Red);
            base.Draw();
        }

        public void Reset()
        {
            shipLayer.Reset();
        }
    }
}
