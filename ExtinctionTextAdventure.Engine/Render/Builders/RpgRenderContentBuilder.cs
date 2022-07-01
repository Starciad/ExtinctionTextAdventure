using ExtinctionTextAdventure.Engine.Render.Entitys;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Areas;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Components;
using ExtinctionTextAdventure.Engine.Render.Enums;
using ExtinctionTextAdventure.Engine.Render.Interfaces;

namespace ExtinctionTextAdventure.Engine.Render.Builders
{
    internal enum CurrentAreaOpen
    {
        None,
        Horizontal,
        Vertical
    }

    internal sealed class RpgRenderContentBuilder : IRpgRenderContentDrawn
    {
        internal List<UIEntityRender> UiEntitiesToRender { get; private set; }

        //Areas
        private bool inputAreaOpen = false;

        private bool horizontalAreaOpen = false;
        private bool verticalAreaOpen = false;

        //Spacing
        private readonly List<CurrentAreaOpen> currentAreaOpens = new();

        private int horizontalSpacing = 0;
        private int verticalSpacing = 0;

        //Input
        private InputAreaType currentAreaOpenType;
        private UIInputArea? currentInputAreaOpen;

        internal RpgRenderContentBuilder()
        {
            UiEntitiesToRender = new();
        }

        internal async Task FinalConfiguration()
        {
            Spacing(0, 3);
            DrawnUIElement(new UIElementObject(new ElementContent("Input the option you want to select."), new ElementStyle() { Color = ConsoleColor.Green, HorizontalSpacing = 1 }));
            DrawnUIElement(new UIElementObject(new ElementContent("Enter input:"), new ElementStyle() { Color = ConsoleColor.Yellow, HorizontalSpacing = 2 }));
            DrawnUIElement(new UIElementObject(new ElementContent(" "), new ElementStyle() { Color = ConsoleColor.White, Inline = true }));

            await Task.CompletedTask;
        }
        internal async Task<RpgRenderContentResult> CompileContentAsync()
        {
            return await Task.FromResult(new RpgRenderContentResult(UiEntitiesToRender));
        }

        //====================//

        public UIElementObject DrawnUIElement(UIElementObject element)
        {
            UIElementObject drawnElement = CreateUIElement(element);

            AddElementToRenderCollection(drawnElement);
            return drawnElement;
        }
        public UIElementObject DrawnUIInput(UIElementObject element)
        {
            UIElementObject drawnElement = CreateUIElement(element);

            if (inputAreaOpen)
            {
                currentInputAreaOpen?.AddElement(drawnElement);
            }

            ResetInfos();
            return drawnElement;
        }

        public void OpenHorizontalArea()
        {
            horizontalAreaOpen = true;
            UiEntitiesToRender.Add(UIElementObject.BreakLine);
            currentAreaOpens.Add(CurrentAreaOpen.Horizontal);
        }
        public void CloseHorizontalArea()
        {
            ResetInfos();
            horizontalAreaOpen = false;
            currentAreaOpens.Remove(CurrentAreaOpen.Horizontal);
        }

        public void OpenVerticalArea()
        {
            verticalAreaOpen = true;
            currentAreaOpens.Add(CurrentAreaOpen.Vertical);
        }
        public void CloseVerticalArea()
        {
            ResetInfos();
            verticalAreaOpen = false;
            currentAreaOpens.Remove(CurrentAreaOpen.Vertical);
        }

        public void OpenInputArea(InputAreaType areaType)
        {
            inputAreaOpen = true;

            currentAreaOpenType = areaType;
            currentInputAreaOpen = new(areaType);

            UiEntitiesToRender.Add(currentInputAreaOpen);
        }
        public void CloseInputArea()
        {
            ResetInfos();

            inputAreaOpen = false;
            UiEntitiesToRender.Add(UIElementObject.BreakLine);

            currentInputAreaOpen = null;
        }

        public void Spacing(int horizontalSpacing, int verticalSpacing)
        {
            this.horizontalSpacing = horizontalSpacing;
            this.verticalSpacing = verticalSpacing;
        }

        //==================//
        private UIElementObject CreateUIElement(UIElementObject elementBase)
        {
            UIElementObject drawnElement = new(elementBase);

            SettingStyles(drawnElement);

            return drawnElement;
        }
        private void SettingStyles(UIElementObject element)
        {
            if (element.Style.Color == ConsoleColor.White) element.Style.Color = element.Style.Color;
            if (element.Style.HorizontalSpacing == 0) element.Style.HorizontalSpacing = horizontalSpacing;
            if (element.Style.VerticalSpacing == 0) element.Style.VerticalSpacing = verticalSpacing;

            if (currentAreaOpens.Count > 0)
            {
                element.Style.Inline = currentAreaOpens[^1] switch
                {
                    CurrentAreaOpen.None => false,
                    CurrentAreaOpen.Horizontal => true,
                    CurrentAreaOpen.Vertical => false,
                    _ => false,
                };
            }
        }

        //==========//

        private void AddElementToRenderCollection(UIElementObject element, bool resetInfos = true)
        {
            UiEntitiesToRender.Add(element);

            if (resetInfos)
                ResetInfos();
        }
        private void ResetInfos()
        {
            horizontalSpacing = 0;
            verticalSpacing = 0;
        }
    }
}