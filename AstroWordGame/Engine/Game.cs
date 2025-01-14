using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWordGame.Engine
{
    internal class Game
    {

        protected Dictionary<string, Scene> Scenes = new();
        public GameSettings Settings { get; init; }

        private Scene _activeScene;
        private string _activeSceneKey;

        public Scene ActiveScene { get { return _activeScene; } }
        public string ActiveSceneKey { get { return _activeSceneKey; } }

        protected void ActivateScene(string sceneKey)
        {
            var sceen = Scenes.GetValueOrDefault(sceneKey);
            if (sceen == null)
                throw new InvalidOperationException($"Scene {sceneKey} does not exist in game.");
            _activeScene = sceen;   
            _activeSceneKey = sceneKey; 
            _activeScene.Init();
        }

        public Game(GameSettings settings)
        {
            Settings = settings;
            _activeScene = new EmptyScene(this);
        }

        public virtual void Update(float frameTime)
        {
            ActiveScene.Update(frameTime);
        }

        public virtual void Draw()
        {
            ActiveScene.Draw();
        }


    }
}
