#pragma warning disable CS8602

using ExtinctionTextAdventure.Engine.Render.Entitys;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Components;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Helpers;
using System.Diagnostics;

namespace ExtinctionTextAdventure.Engine.Render.Builders
{
    internal sealed class RpgRenderContentResult
    {
        internal List<UIEntityRender> UiEntitiesToRender { get; }
        internal int CurrentEntityToRenderInQueue { get { return currentEntityToRenderInQueue; } }

        private UIElementObject lastUIElement;
        private int globalX = 0;
        private int globalY = 0;
        private int currentEntityToRenderInQueue = 0;

        private RpgBuilderHelper RpgBuilderHelper { get; }
        private RpgInputHelper RpgInputHelper { get; }

        internal RpgRenderContentResult(IEnumerable<UIEntityRender> elements)
        {
            RpgBuilderHelper = new(this);
            RpgInputHelper = new(this);

            UiEntitiesToRender = new(elements);
            lastUIElement = UIElementObject.BreakLine;
        }
        internal async Task ShowRenderAsync()
        {
            Console.Clear();

            globalX = 0;
            globalY = 0;

            currentEntityToRenderInQueue = 0;

            Console.CursorVisible = false;
            for (int i = 0; i < UiEntitiesToRender.Count; i++)
            {
                currentEntityToRenderInQueue = i + 1;
                UIEntityRender currentEntity = UiEntitiesToRender[i];

                //Check for the type
                Type entityType = currentEntity.GetType();
                UIElementObject? element;

                if (entityType == typeof(UIElementObject))
                {
                    element = await currentEntity.BuildElementAsync(RpgBuilderHelper);
                }
                else
                {
                    UiEntitiesToRender.Remove(currentEntity);
                    await currentEntity.BuildElementAsync(RpgBuilderHelper);
                    continue;
                }

                if (element.Style.IsInvisible)
                {
                    globalY++;
                    continue;
                }

                ApplyStyle(element);
                WriteContent(element);

                lastUIElement = element;
            }

            await StartInteractionAsync();
        }

        #region Styles

        private void ApplyStyle(UIElementObject element)
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

        #endregion Styles
        #region Writers

        private void WriteContent(UIElementObject element)
        {
            int currentX = globalX;
            int currentY = globalY;

            foreach (string line in element.Content.TextContent.Split('\n'))
            {
                foreach (char letter in line)
                {
                    Console.SetCursorPosition(currentX, currentY);
                    WriteLetter(letter, element.Style);

                    currentX++;
                    Thread.Sleep(2);
                }

                currentX = globalX;
                currentY++;
            }
        }
        private void WriteLetter(char letter, ElementStyle style)
        {
            Console.ForegroundColor = style.Color;
            Console.Write(letter);
        }

        #endregion Writers

        private async Task StartInteractionAsync()
        {
            string? result = Console.ReadLine();

            if (!string.IsNullOrEmpty(result))
            {
                UIElementObject? inputObj = UiEntitiesToRender.OfType<UIElementObject>().FirstOrDefault(x => result == x.Content.TextContent);

                if (inputObj?.Input != null)
                {
                    inputObj.Input.OnSelected?.Invoke(RpgInputHelper);
                    await Task.CompletedTask;
                }
                else
                {
                    await ShowRenderAsync();
                }
            }

            await Task.CompletedTask;
        }
    }
}