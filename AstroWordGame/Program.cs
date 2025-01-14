/*******************************************************************************************
* Raylib Stars demo
* 
* unlicense (see LICENSE.md)
* 
* Copyright 2025 DJ Kunkel
*
********************************************************************************************/

using System.Numerics;
using System;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Starfield.Utils;
using AstroWordGame.Engine;
using AstroWordGame;
using AstroWordGame.Scenes.Shared;

namespace Starfield;

public class BasicWindow
{
    public static int Main()
    {


        GameSettings settings = new GameSettings
        {
            Title = "AstroWord",
            Height = 900,
            Width = 600,
            WindowFlags = ConfigFlags.VSyncHint
        };

        var game = new AstroWord(settings);


        //init window and graphics context
        SetConfigFlags(settings.WindowFlags);
        InitWindow(settings.Width, settings.Height, settings.Title);


       
        // Main game loop
        while (!WindowShouldClose())
        {


            var frameTime = GetFrameTime();

            // Update
            //----------------------------------------------------------------------------------
            game.Update(frameTime);

           

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.Black);

            game.Draw();

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}