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
using Starfield.Utils;
using AstroWordGame.Engine;
using AstroWordGame;
using AstroWordGame.Scenes.Shared;

namespace Starfield;

public class BasicWindow
{
    public static int Main()
    {
        
        /*
         * Plan of attack
         * 
         * 1. Layers should be reusable across scenes and given an area to draw into on init (a rectangle in screen coords)
         * 2. Layers should be given  on init a generic <T> scene they belong to so they can get state, or the base scene if they have no special state to care about (Stars)
         * 3. Game logic belongs to a scene or the Game. No logic or input should be handled in a layer.
         * 4. Layers and Scenes should reset to a default at init time as Init happens when a scene is switched
         *          Maybe Init() should take a reset param?
         * 5. Layers can have methods they can use to update their display state by the scene. For example the Scene could tell the projectile layer and the Letter layer, they need to explode something
         * 6. The SCENE should hold and track state and update state. Layers should not update scene state. They can have their own state (animations in progress, star positions, etc)
         * 7. Sounds should be played by the scenes logic. For example, on a hit of a letter, play the sound, tell the letter layer to explode a letter, tell the projective layer to remove a projectile.
         * 
         * 
         * 
         */



        GameSettings settings = new GameSettings
        {
            Title = "AstroWord",
            Height = 900,
            Width = 600,
            WindowFlags = ConfigFlags.VSyncHint
        };

        var game = new AstroWord(new Rectangle(0, 0, settings.Width, settings.Height));


        //init window and graphics context
        Raylib.SetConfigFlags(settings.WindowFlags);
        Raylib.InitWindow(settings.Width, settings.Height, settings.Title);


       
        // Main game loop
        while (!Raylib.WindowShouldClose())
        {


            var frameTime = Raylib.GetFrameTime();

            // Update
            //----------------------------------------------------------------------------------
            game.Update(frameTime);

           

            // Draw
            //----------------------------------------------------------------------------------
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            game.Draw();

            Raylib.EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        Raylib.CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}