using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using Raylib_cs;

namespace AstroWordGame.Scenes.Play
{
    internal class BulletLayer : Layer
    {
        Vector2[] projectiles;
        int shotsFired = 0;
        float shotSpeed = 600;

        public BulletLayer(Rectangle drawArea) : base(drawArea)
        {
            Reset();
        }

        [MemberNotNull(nameof(projectiles))]
        internal void Reset()
        {
            projectiles = new Vector2[12];
        }

        internal IEnumerable<Vector2> ActiveProjectiles
        {
            get
            {
                foreach (var bullet in projectiles)
                {
                    if (bullet.Y > 0)
                        yield return bullet;
                }
            }
        }

        public override void Update(float frameTime)
        {

            //update projectiles
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y > 0)
                {
                    projectiles[i].Y = projectiles[i].Y - (shotSpeed * frameTime);
                }
            }


            base.Update(frameTime);
        }

        public override void Draw()
        {
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y > 0)
                {
                    //Raylib.DrawCircle((int)projectiles[i].X, (int)projectiles[i].Y, 4.0f, Color.Green);
                    Raylib.DrawCircleV(projectiles[i], 4.0f, Color.Green);
                }
            }


            base.Draw();
        }

        internal void Fire(Vector2 gunPosition)
        {
            bool fired = false;
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (!fired && Raylib.IsKeyPressed(KeyboardKey.Space) && projectiles[i].Y <= 0)
                {
                    fired = true;
                    shotsFired++;
                    projectiles[i].Y = gunPosition.Y + 4f;
                    projectiles[i].X = gunPosition.X;
                }
            }
        }

        internal void DestroyBullet(Vector2 bullet)
        {
            //it would be great to not have to find one to delete like this
            for (int i = 0; i <= projectiles.Length; i++)
            {
                if (projectiles[i] == bullet)
                {
                    projectiles[i].Y = 0;
                    break;
                }
            }
        }
    }
}
