using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using Raylib_cs;

namespace AstroWordGame.Scenes.Shared
{
    internal class StarsLayer : Layer
    {
        public StarsLayer(Rectangle drawArea, float speed, int count) : base(drawArea)
        {
            _speed = speed;
            _count = count;
            _width = DrawArea.Width;
            _height = DrawArea.Height;

            _stars = new Vector2[_count];
            _starColors = new Color[_count];

            for (int i = 0; i < _count; i++)
            {
                var intensity = Raylib.GetRandomValue(128, 255);
                _starColors[i] = new Color(intensity, intensity, intensity, 255);
                _stars[i].X = Raylib.GetRandomValue(0, (int)_width);
                _stars[i].Y = Raylib.GetRandomValue(0, (int)_height);
            }
        }

        Vector2[] _stars { get; init; }
        Color[] _starColors { get; init; }


        private float _width;
        private float _height;
        private float _speed;
        private int _count;

 

        public override void Update(float frameTime)
        {
            for (int i = 0; i < _count; i++)
            {
                _stars[i].Y = _stars[i].Y + _speed * frameTime;
                if (_stars[i].Y > _height)
                {
                    _stars[i].Y = 0;
                    _stars[i].X = Raylib.GetRandomValue(0, (int)_width);
                }
            }
        }
        public override void Draw()
        {
            for (int i = 0; i < _count; i++)
            {
                Raylib.DrawCircle((int)_stars[i].X, (int)_stars[i].Y, 1, _starColors[i]);
            }
        }


    }
}
