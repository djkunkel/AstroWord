using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace AstroWordGame.Engine
{
    internal class EmptyLayer : Layer
    {
        public override void Draw()
        {
            
        }

        public override void Update(float frameTime)
        {
            
        }

        public static readonly EmptyLayer Empty = new(new Rectangle(0,0,0,0));

        private EmptyLayer(Rectangle drawArea) : base(drawArea)
        {
        }
    }
}
