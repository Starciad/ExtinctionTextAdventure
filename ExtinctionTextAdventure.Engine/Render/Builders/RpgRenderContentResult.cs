namespace ExtinctionTextAdventure.Engine.Render
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
        }

        public async Task ShowRenderAsync()
        {
            Console.CursorVisible = false;
            foreach (UIElement currentElement in uiElements)
            {
                UIElement element = await currentElement.BuildElementAsync();

                if (element.IsInvisible)
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

            //Inline true
            if (element.Style.Inline)
            {
                if (lastUIElement != null)
                    globalX += lastUIElement.Content.Size.X;
            }
            else //Inline false
            {
                globalX = 0;

                if (lastUIElement != null)
                    globalY += lastUIElement.Content.Size.Y;
            }

            //Position
            globalX += element.Style.HorizontalSpacing;
            globalY += element.Style.VerticalSpacing;
        }

        private void WriteContent(UIElement element)
        {
            int currentX = globalX;
            int currentY = globalY;

            foreach (string line in element.Content.TextContent.Split('\n'))
            {
                foreach (char letter in line.ToCharArray())
                {
                    currentX++;
                    Console.SetCursorPosition(currentX, currentY);
                    WriteContent(letter, element.Style);

                    Thread.Sleep(10);
                }

                currentX = globalX;
                currentY++;
            }
        }

        //================================//

        private void WriteContent(char letter, UIStyle style)
        {
            Console.ForegroundColor = style.Color;
            Console.Write(letter);
        }
    }
}
