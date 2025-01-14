using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWordGame.Engine
{
    internal class Scene
    {
        protected Dictionary<string, Layer> Layers = new();
        protected Game Game;

        public Scene(Game game)
        {
            Game = game;
        }

        public void Init()
        {
            foreach (var layer in Layers.Values)
            {
                layer.Init();
            }
        }

        public virtual void Update(float frameTime)
        {
            foreach (var layer in ActiveLayers)
            {
                layer.Update(frameTime);
            }
        }

        public virtual void Draw()
        {
            foreach (var layer in ActiveLayers)
            {
                layer.Draw();
            }
        }

        public virtual IEnumerable<Layer> ActiveLayers
        {
            get
            {
                return Layers.Values;
            }
        }

    }
}
