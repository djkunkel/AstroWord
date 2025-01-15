using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Shared;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace AstroWordGame.Scenes.Welcome
{
    internal class WelcomeScene : Layer
    {
        public WelcomeScene(Rectangle drawArea) : base(drawArea)
        {
            AddChild(new StarsLayer(drawArea, 50, 1000));
        }

        public override void Draw()
        {

            base.Draw();

            DrawText("Press enter to play", 20, 50, 20, Color.Green);

        }

    }
}
