using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Shared;

namespace AstroWordGame.Scenes.Play
{
    internal class PlayScene : Scene
    {
        public PlayScene(Game game) : base(game)
        {
            Layers.Add("star1", new StarsLayer(game.Settings, 50, 100));
            Layers.Add("star2", new StarsLayer(game.Settings, 75, 60));
            Layers.Add("star3", new StarsLayer(game.Settings, 100, 25));
            Layers.Add("ship", new ShipLayer(game.Settings));  
        }
    }
}
