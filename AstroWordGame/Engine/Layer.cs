using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace AstroWordGame.Engine
{
    public class Layer : IDisposable
    {
        protected readonly Rectangle DrawArea;


        public List<Layer> Children { get; init; } = new List<Layer>();


        protected L AddChild<L>(L layer) where L : Layer
        {
            Children.Add(layer);
            return layer;
        }

        public Layer(Rectangle drawArea)
        {
            this.DrawArea = drawArea;
        }


        public virtual IEnumerable<Layer> ActiveLayers
        {
            get
            {
                return Children;
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

        public virtual void Dispose()
        {

        }


        public static readonly Layer Empty = new(new Rectangle(0, 0, 0, 0));
    }
}
