using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine.Render
{
    public class UIStyle
    {
        public ConsoleColor Color { get; set; }
        public bool Inline { get; set; }
        public int HorizontalSpacing { get; set; }
        public int VerticalSpacing { get; set; }
        internal Vector2 Size { get; set; }

        public UIStyle()
        {
            Color = ConsoleColor.White;
            Inline = false;
        }

        public UIStyle(UIStyle styleToCopy)
        {
            Color = styleToCopy.Color;
            Inline = styleToCopy.Inline;
        }
    }
}
