using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Engine.Render.Enums;

namespace ExtinctionTextAdventure.Engine.Render.Interfaces
{
    public interface IRpgRenderContentDrawn
    {
        UIElementObject DrawnUIElement(UIElementObject element);

        UIElementObject DrawnUIInput(UIElementObject element);

        void OpenHorizontalArea();

        void CloseHorizontalArea();

        void OpenVerticalArea();

        void CloseVerticalArea();

        void OpenInputArea(InputAreaType areaType);

        void CloseInputArea();

        void Spacing(int horizontalSpacing, int verticalSpacing);
    }
}