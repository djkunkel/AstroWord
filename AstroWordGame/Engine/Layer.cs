using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWordGame.Engine
{
    internal abstract class Layer : IDisposable
    {
        protected Game Game {get; init;}
        protected Scene Scene {get; init;}


        public Layer(Game game, Scene scene)
        {
            Game = game;
            Scene = scene;
        }


        public abstract void Init();
        public abstract void Update(float frameTime);

        public virtual void AfterUpdate() { }

        public abstract void Draw();

        public virtual void Dispose()
        {

        }
    }
}
