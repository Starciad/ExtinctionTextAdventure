using ExtinctionTextAdventure.Core.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Core.Render.Enums;

namespace ExtinctionTextAdventure.Core.Render.Interfaces
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