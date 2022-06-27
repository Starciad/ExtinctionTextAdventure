namespace ExtinctionTextAdventure.Engine
{
    public enum CurrentAreaOpen
    {
        None,
        Horizontal,
        Vertical
    }

    public class RpgRenderContentBuilder : IRpgRenderContentDrawn
    {
        private readonly List<UIElement> uiElements = new();

        private bool horizontalAreaOpen = false;
        private bool verticalAreaOpen = false;

        private readonly List<CurrentAreaOpen> currentAreaOpens = new();
        private int horizontalSpacing = 0;
        private int verticalSpacing = 0;

        public async Task<RpgRenderContentResult> CompileContentAsync()
        {
            return await Task.FromResult(new RpgRenderContentResult(uiElements));
        }

        //====================//

        public UIElement DrawnUIElement(UIElement element)
        {
            OverlapStyles(element);
            UIElement drawElement = new(element);

            ResetInfos();
            uiElements.Add(drawElement);
            return drawElement;
        }

        public void OpenHorizontalArea()
        {
            horizontalAreaOpen = true;
            uiElements.Add(UIElement.BreakLine);

            currentAreaOpens.Add(CurrentAreaOpen.Horizontal);
        }
        public void CloseHorizontalArea()
        {
            horizontalAreaOpen = false;
            ResetInfos();
            currentAreaOpens.Remove(CurrentAreaOpen.Horizontal);
        }

        public void OpenVerticalArea()
        {
            verticalAreaOpen = true;
            currentAreaOpens.Add(CurrentAreaOpen.Vertical);
        }
        public void CloseVerticalArea()
        {
            verticalAreaOpen = false;
            currentAreaOpens.Remove(CurrentAreaOpen.Vertical);
            ResetInfos();
        }

        public void Spacing(int horizontalSpacing, int verticalSpacing)
        {
            this.horizontalSpacing = horizontalSpacing;
            this.verticalSpacing = verticalSpacing;
        }

        //==================//
        private void OverlapStyles(UIElement element)
        {
            if (element.Style.Color == ConsoleColor.White) element.Style.Color = element.Style.Color;
            if (element.Style.HorizontalSpacing == 0) element.Style.HorizontalSpacing = horizontalSpacing;
            if (element.Style.VerticalSpacing == 0) element.Style.VerticalSpacing = verticalSpacing;

            if (currentAreaOpens.Count > 0)
                element.Style.Inline = currentAreaOpens[^1] switch
                {
                    CurrentAreaOpen.None => false,
                    CurrentAreaOpen.Horizontal => true,
                    CurrentAreaOpen.Vertical => false,
                    _ => false,
                };
        }
        private void ResetInfos()
        {
            horizontalSpacing = 0;
            verticalSpacing = 0;
        }
    }
}
