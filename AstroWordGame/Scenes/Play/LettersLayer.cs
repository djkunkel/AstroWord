using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AstroWordGame.Engine;
using Raylib_cs;

namespace AstroWordGame.Scenes.Play
{
    internal class LettersLayer : Layer
    {

        public record class LetterItem
        {
            public Vector2 Position = new(0, 0);
            public string Letter = "A";
            public bool Active = false;

            public LetterItem(Vector2 position, string letter)
            {
                Position = position;
                Letter = letter;
                Active = false;
            }
        }

        List<LetterItem> letters;
        float letterSpeed = 100;
        int letterSize = 40;
        int letterFreqency = 1500;

        Stopwatch letterTimer = new Stopwatch();


        public LettersLayer(Rectangle drawArea) : base(drawArea)
        {
            Reset();
        }

        [MemberNotNull(nameof(letters))]
        private void Reset()
        {
            letters = new List<LetterItem>(50);
            for(int i = 0; i <= 50; i++)
            {
                letters.Add(new LetterItem(new(0, 0), "B"));
            }
        }

        public IEnumerable<LetterItem> ActiveLetters
        {
            get
            {
                foreach (var letter in letters)
                {
                    if (letter.Active)
                        yield return letter;
                }
            }
        }

        internal void DestroyLetter(LetterItem letter)
        {
            letter.Active = false;

            //start an explosion?

        }


        private static char GetRandomCapitalLetter()
        {
            // ASCII range for 'A' to 'Z' is 65 to 90
            int randomAscii = Raylib.GetRandomValue(65, 90);

            // Convert the ASCII value to a character
            return (char)randomAscii;
        }

        public override void Update(float frameTime)
        {
            if (!letterTimer.IsRunning)
            {
                letterTimer.Start();
            }

            //move all letters
            foreach (var letter in letters)
            {
                if (letter.Active)
                {
                    letter.Position.Y = letter.Position.Y + letterSpeed * frameTime;
                }
                if (letter.Position.Y > DrawArea.Height)
                {
                    letter.Position.Y = 0;
                    letter.Active = false;
                }
            }


            //throw a letter out?
            if (letterTimer.ElapsedMilliseconds > letterFreqency)
            {
                letterTimer.Restart();

                //find the first inactive letter and start it up
                foreach (var letter in letters)
                {
                    if (!letter.Active)
                    {
                        letter.Active = true;
                        letter.Letter = $"{GetRandomCapitalLetter()}";
                        letter.Position.Y = 1;
                        letter.Position.X = Raylib.GetRandomValue(letterSize, (int)DrawArea.Width - letterSize);
                        break;
                    }
                }
            }

            base.Update(frameTime);
        }

        public override void Draw()
        {
            foreach (var letter in ActiveLetters)
            {
                Raylib.DrawText(letter.Letter, (int)letter.Position.X, (int)letter.Position.Y, letterSize, Color.Gold);
            }

            base.Draw();
        }

       
    }
}
