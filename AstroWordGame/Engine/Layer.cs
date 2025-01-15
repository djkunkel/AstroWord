using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace AstroWordGame.Engine
{
    internal abstract class Layer : IDisposable
    {
        protected readonly Rectangle DrawArea;
        private readonly List<Layer> children = new List<Layer>();


        public ReadOnlyCollection<Layer> Children { 
            get { return children.AsReadOnly(); }
        }
        protected Layer Parent { get; private set; } = EmptyLayer.Empty;

        public Layer(Rectangle drawArea)
        {
            this.DrawArea = drawArea;
        }


        protected void SetParent(Layer layer)
        {
            Parent = layer;
        }

        protected Layer AddChild(Layer layer)
        {
            children.Add(layer);
            layer.Parent = this;
            return layer;
        }

        public virtual IEnumerable<Layer> ActiveLayers
        {
            get
            {
                return children;
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
    }
}
