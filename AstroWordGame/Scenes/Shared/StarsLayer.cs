﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace AstroWordGame.Scenes.Shared
{
    internal class StarsLayer : Layer
    {

        public StarsLayer(GameSettings settings, float speed, int count) : base(settings)
        {
            _speed = speed;
            _count = count;

            stars = new Vector2[_count];
            starColors = new Color[_count];
        }



        Vector2[] stars { get; init; }
        Color[] starColors { get; init; }


        private int _width;
        private int _height;
        private float _speed;
        private int _count;

        public override void Init()
        {
            _width = Settings.Width;
            _height = Settings.Height;

            for (int i = 0; i < _count; i++)
            {
                var intensity = GetRandomValue(128, 255);
                starColors[i] = new Color(intensity, intensity, intensity, 255);
                stars[i].X = GetRandomValue(0, _width);
                stars[i].Y = GetRandomValue(0, _height);
            }
        }

        public override void Update(float frameTime)
        {
            for (int i = 0; i < _count; i++)
            {
                stars[i].Y = stars[i].Y + _speed * frameTime;
                if (stars[i].Y > _height)
                {
                    stars[i].Y = 0;
                    stars[i].X = GetRandomValue(0, _width);
                }
            }
        }
        public override void Draw()
        {
            for (int i = 0; i < _count; i++)
            {
                DrawCircle((int)stars[i].X, (int)stars[i].Y, 1, starColors[i]);
            }
        }


    }
}
