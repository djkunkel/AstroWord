using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace AstroWordGame.Engine
{
    public struct GameSettings
    {

        public string Title { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
        public ConfigFlags WindowFlags { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameSettings"/> with default values for various game settings such as window size, icon path, log directory, content directory, and more.
        /// </summary>
        public GameSettings()
        {
            this.Title = Assembly.GetEntryAssembly()?.GetName().Name ?? "Sparkle";
            this.Width = 1280;
            this.Height = 720;
            this.WindowFlags = ConfigFlags.VSyncHint;
        }
    }
}
