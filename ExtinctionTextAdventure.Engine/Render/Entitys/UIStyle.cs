namespace ExtinctionTextAdventure.Engine.Render
{
    public class UIStyle
    {
        public ConsoleColor Color { get; set; }
        public bool Inline { get; set; }
        public int HorizontalSpacing { get; set; }
        public int VerticalSpacing { get; set; }

        public UIStyle()
        {
            Color = ConsoleColor.White;
            Inline = false;

            HorizontalSpacing = 0;
            VerticalSpacing = 0;
        }

        public UIStyle(UIStyle styleToCopy)
        {
            Color = styleToCopy.Color;
            Inline = styleToCopy.Inline;

            if (HorizontalSpacing == 0) HorizontalSpacing = styleToCopy.HorizontalSpacing;
            if (VerticalSpacing == 0) VerticalSpacing = styleToCopy.VerticalSpacing;
        }
    }
}
