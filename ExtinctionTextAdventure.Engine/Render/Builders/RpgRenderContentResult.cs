using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure.Engine
{
    public class RpgRenderContentResult
    {
        private readonly IEnumerable<UIElement> uiElements;
        private UIElement lastUIElement;
        private int globalX = 0;
        private int globalY = 0;

        public RpgRenderContentResult(IEnumerable<UIElement> elements)
        {
            uiElements = elements;
            lastUIElement = new(new UIStyle() { IsInvisible = true, Inline = false });
        }
        public async Task ShowRenderAsync()
        {
            Console.CursorVisible = false;
            foreach (UIElement currentElement in uiElements)
            {
                UIElement element = await currentElement.BuildElementAsync();

                if (element.Style.IsInvisible)
                {
                    globalY++;
                    continue;
                }

                ApplyStyle(element);
                WriteContent(element);

                lastUIElement = element;
            }
        }

        //=====================//
        #region Styles
        private void ApplyStyle(UIElement element)
        {
            //Spacing
            for (int y = 0; y < element.Style.VerticalSpacing; y++)
            {
                Console.Write('\n');
            }
            for (int x = 0; x < element.Style.HorizontalSpacing; x++)
            {
                Console.Write(' ');
            }

            //Inline
            if (element.Style.Inline)
            {
                if (lastUIElement != null)
                    globalX += lastUIElement.Content.Size.X;
            }
            else
            {
                globalX = 0;

                if (lastUIElement != null)
                    globalY += lastUIElement.Content.Size.Y;
            }

            //Position
            globalX += element.Style.HorizontalSpacing;
            globalY += element.Style.VerticalSpacing;
        }

        #endregion

        #region Writers
        private void WriteContent(UIElement element)
        {
            int currentX = globalX;
            int currentY = globalY;

            foreach (string line in element.Content.TextContent.Split('\n'))
            {
                foreach (char letter in line.ToCharArray())
                {
                    Console.SetCursorPosition(currentX, currentY);
                    WriteLetter(letter, element.Style);

                    currentX++;
                    Thread.Sleep(5);
                }

                currentX = globalX;
                currentY++;
            }
        }
        private void WriteLetter(char letter, UIStyle style)
        {
            Console.ForegroundColor = style.Color;
            Console.Write(letter);
        }
        #endregion
    }
}
