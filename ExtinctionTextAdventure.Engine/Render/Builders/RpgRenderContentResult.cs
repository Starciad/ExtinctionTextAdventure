using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine.Render
{
    public class RpgRenderContentResult
    {
        private readonly IEnumerable<UIElement> uiElements;
        private UIElement lastUIElement;

        int globalX = 0;
        int globalY = 0;

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

                for (int x = 0; x < element.Style.HorizontalSpacing; x++)
                {
                    Console.Write(' ');
                }
            }

            //Inline
            if (!element.Style.Inline)
            {
                Console.Write(Console.Out.NewLine);

                globalX = 0;
                globalY++;
            }
            else if(element.Style.Inline && lastUIElement != null)
            {
                globalX += lastUIElement.Content.Size.X + element.Style.HorizontalSpacing;
            }
            else
            {
                globalX += element.Style.HorizontalSpacing;
            }
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
