using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Play;
using AstroWordGame.Scenes.Welcome;
using Raylib_cs;


namespace AstroWordGame
{
    internal class AstroWord : Layer
    {
        public AstroWord(Rectangle drawArea) : base(drawArea)
        {
            welcomeScene = AddChild(new WelcomeScene(drawArea));
            playScene = AddChild(new PlayScene(drawArea));

            currentScene = Children[0];
        }

        bool paused = false;
        private readonly Layer welcomeScene;
        private readonly Layer playScene;
        private Layer currentScene;

        public override void Update(float frameTime)
        {

            if (currentScene == welcomeScene)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    currentScene = playScene;
                }
            }
            else if (currentScene == playScene)
            {

                if (Raylib.IsKeyPressed(KeyboardKey.Q))
                {
                    currentScene = welcomeScene;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.P))
                {
                    paused = !paused;
                }

            }

          
            if (!paused)
            {
                base.Update(frameTime);
            }

        }

        public override IEnumerable<Layer> ActiveLayers
        {
            get
            {
                yield return currentScene;
            }
        }
    }
}
