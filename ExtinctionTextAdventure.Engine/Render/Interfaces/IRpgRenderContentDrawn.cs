namespace ExtinctionTextAdventure.Engine
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