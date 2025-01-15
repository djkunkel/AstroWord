using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using AstroWordGame.Scenes.Shared;
using Raylib_cs;

namespace AstroWordGame.Scenes.Play
{
    internal class PlayScene : Layer
    {
        public PlayScene(Rectangle drawArea) : base(drawArea)
        {
            AddChild(new StarsLayer(drawArea, 50, 100));
            AddChild(new StarsLayer(drawArea, 75, 60));
            AddChild(new StarsLayer(drawArea, 100, 25));
            AddChild(new ShipLayer(drawArea));
        }
    }
}
