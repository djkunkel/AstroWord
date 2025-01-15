using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using Raylib_cs;


namespace AstroWordGame.Scenes.Play
{
    internal class ShipLayer : Layer
    {
        Vector2[] projectiles;
        Vector2[] letters;
        Vector2 position;

        private float width;
        private float height;

        float shipSize = 40;
        float shipSpeed = 500;
        float shotSpeed = 600;

        int shotsFired = 0;

        Stopwatch letterTimer = new Stopwatch();

    

        public ShipLayer(Rectangle drawArea) : base(drawArea)
        {
            width = drawArea.Width;
            height = drawArea.Height;
            Reset();
           
        }

        [MemberNotNull(nameof(projectiles), nameof(letters))]
        internal void Reset()
        {
            shotsFired = 0;
            position = new Vector2(width / 2, height - 75);
            projectiles = new Vector2[20];
            letters = new Vector2[50];
        }

        internal IEnumerable<Vector2> ActiveProjectiles
        {
            get
            {
                foreach(var bullet in projectiles)
                {
                    if(bullet.Y>0)
                        yield return bullet;
                }
            }
        }



        public override void Update(float frameTime)
        {
            if (!letterTimer.IsRunning)
            {
                letterTimer.Start();
            }

            //movement
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                position.X = Math.Max(shipSize / 2, position.X - shipSpeed * frameTime);
            }
            else if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                position.X = Math.Min(width - shipSize / 2, position.X + shipSpeed * frameTime);
            }


            //update projectiles
            bool fired = false;
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y > 0)
                {
                    projectiles[i].Y = projectiles[i].Y - shotSpeed * frameTime;
                }

                if (!fired && Raylib.IsKeyPressed(KeyboardKey.Space) && projectiles[i].Y <= 0)
                {
                    fired = true;
                    shotsFired++;
                    projectiles[i].Y = position.Y + 4f;
                    projectiles[i].X = position.X;
                }
            }

            //move all letters
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i].Y > 0)
                {
                    letters[i].Y = letters[i].Y + shipSize * frameTime;
                }
                else
                {
                    if (letters[i].Y > height)
                        letters[i].Y = 0;
                }
            }

            //throw a letter out?
            if (letterTimer.ElapsedMilliseconds > 3000)
            {
                letterTimer.Restart();
                //find the first 0 letter that isn't being used right now
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i].Y == 0)
                    {
                        letters[i].Y = 1;
                        letters[i].X = Raylib.GetRandomValue(0, (int)width);
                        break;
                    }
                }
            }



        }

        public override void Draw()
        {
            Raylib.DrawTriangle(
                new Vector2(position.X + shipSize / 2, position.Y + shipSize),
                new Vector2(position.X, position.Y),
                new Vector2(position.X - shipSize / 2, position.Y + shipSize),
                Color.Red
            );

            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y > 0)
                {
                    Raylib.DrawCircle((int)projectiles[i].X, (int)projectiles[i].Y, 4.0f, Color.Green);
                }
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i].Y > 0)
                {
                    Raylib.DrawText("A", (int)letters[i].X, (int)letters[i].Y, 40, Color.Gold);
                }
            }

            Raylib.DrawText($"Shots fired: {shotsFired}", 10, (int)height - 25, 20, Color.Magenta);
        }

        
    }
}
