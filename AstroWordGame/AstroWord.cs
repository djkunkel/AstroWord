using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Play;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace AstroWordGame
{
    internal class AstroWord : Game
    {
        

        public AstroWord(GameSettings settings) : base(settings)
        {
            Scenes.Add("welcome", new WelcomeScene(this));
            Scenes.Add("play", new PlayScene(this));
            ActivateScene("welcome");

        }

        bool paused = false;

        public override void Update(float frameTime)
        {

            switch (ActiveSceneKey)
            {
                case "welcome":
                    if (IsKeyPressed(KeyboardKey.Enter)) {
                        ActivateScene("play");
                    }
                    break;
                case "play":
                    if (IsKeyPressed(KeyboardKey.Q))
                    {
                        ActivateScene("welcome");
                    }
                    if (IsKeyPressed(KeyboardKey.P)) {
                        paused = !paused;
                    }
                    break;
            }

            if (!paused)
            {
                base.Update(frameTime);
            }
        }
    }
}
