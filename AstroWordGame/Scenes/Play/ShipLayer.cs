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
        
        Vector2 position;

        private float width;
        private float height;

        float shipSize = 40;
        float shipSpeed = 500;
          

        public ShipLayer(Rectangle drawArea) : base(drawArea)
        {
            width = drawArea.Width;
            height = drawArea.Height;
            Reset();
           
        }

        [MemberNotNull()]
        internal void Reset()
        {
            position = new Vector2(width / 2, height - 75);
        }

       
        public Vector2 ShipPosition
        {
            get { return position; }
        }


        public override void Update(float frameTime)
        {
            //movement
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                position.X = Math.Max(shipSize / 2, position.X - shipSpeed * frameTime);
            }
            else if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                position.X = Math.Min(width - shipSize / 2, position.X + shipSpeed * frameTime);
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
        }

        
    }
}
