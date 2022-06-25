namespace ExtinctionTextAdventure.Engine.Render
{
    public class UIElement
    {
        public static UIElement BreakLine => new UIElement(new UIStyle() { Inline = false }) { IsInvisible = true, };

        public UIElementContent Content { get; }
        public UIStyle Style { get; }
        public bool IsInvisible { get; set; }

        public UIElement()
        {
            Content = new();
            Style = new();
        }
        public UIElement(UIElement elementToCopy)
        {
            Content = new(elementToCopy.Content);
            Style = new(elementToCopy.Style);
        }
        public UIElement(UIElement elementToCopy, UIStyle styles)
        {
            Content = new(elementToCopy.Content);
            Style = new(styles);
        }
        public UIElement(UIStyle styles)
        {
            Content = new();
            Style = new(styles);
        }
        public UIElement(UIElementContent content)
        {
            Content = new(content);
            Style = new();
        }
        public UIElement(UIElementContent content, UIStyle styles)
        {
            Content = new(content);
            Style = new(styles);
        }

        public async Task<UIElement> BuildElementAsync()
        {
            return await Task.FromResult(new UIElement(this));
        }
    }
}
