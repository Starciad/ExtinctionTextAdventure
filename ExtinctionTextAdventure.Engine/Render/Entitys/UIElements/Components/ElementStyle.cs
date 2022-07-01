using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure.Engine
{
    public sealed class ElementStyle : ElementComponentBase
    {
        public ConsoleColor Color { get; set; }
        public bool Inline { get; set; }
        public int HorizontalSpacing { get; set; }
        public int VerticalSpacing { get; set; }
        public bool IsInvisible { get; set; }
        public bool DisplayInputNameHelpers { get; set; }

        public ElementStyle()
        {
            Color = ConsoleColor.White;
            Inline = false;
            DisplayInputNameHelpers = false;

            HorizontalSpacing = 0;
            VerticalSpacing = 0;
        }

        public ElementStyle(ElementStyle styleToCopy)
        {
            Color = styleToCopy.Color;
            Inline = styleToCopy.Inline;
            DisplayInputNameHelpers = styleToCopy.DisplayInputNameHelpers;

            if (HorizontalSpacing == 0) HorizontalSpacing = styleToCopy.HorizontalSpacing;
            if (VerticalSpacing == 0) VerticalSpacing = styleToCopy.VerticalSpacing;
        }
    }
}