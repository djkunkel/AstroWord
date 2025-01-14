using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Shared;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace AstroWordGame.Scenes.Play
{
    internal class WelcomeScene : Scene
    {
        public WelcomeScene(Game game) : base(game)
        {
            Layers.Add("stars", new StarsLayer(game, this, 50, 1000));
        }

        public override void Draw()
        {

            base.Draw();

            DrawText("Press enter to play", 20, 50, 20, Color.Green);

        }

    }
}
