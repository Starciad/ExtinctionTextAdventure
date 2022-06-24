using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine.Render
{
    public class RpgRenderContentBuilder : IRpgRenderContentDrawn
    {
        private List<UIElement> uiElements = new();
        private bool horizontalAreaOpen = false;
        private int horizontalSpacing = 0;
        private int verticalSpacing = 0;

        public async Task<RpgRenderContentResult> CompileContentAsync()
        {
            return await Task.FromResult(new RpgRenderContentResult(uiElements));
        }

        //====================//

        public UIElement DrawnUIElement(UIElement element)
        {
            UIElement drawElement = new(element, new UIStyle()
            {
                Color = element.Style.Color,
                Inline = horizontalAreaOpen,

                HorizontalSpacing = horizontalSpacing,
                VerticalSpacing = verticalSpacing,
            });

            uiElements.Add(drawElement);
            return drawElement;
        }

        public void OpenHorizontalArea()
        {
            horizontalAreaOpen = true;
        }

        public void CloseHorizontalArea()
        {
            horizontalAreaOpen = false;
        }

        public void Spacing(int horizontalSpacing, int verticalSpacing)
        {

        }
    }
}
