using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioContaAzul.Models
{
    public abstract class Plataform
    {
        public abstract string Name { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public int InitialPositionX { get { return 0; } }
        public int InitialPositionY { get { return 0; } }
        public int FinalPositionX { get { return Width - 1; } }
        public int FinalPositionY { get { return Height - 1; } }
    }
}
