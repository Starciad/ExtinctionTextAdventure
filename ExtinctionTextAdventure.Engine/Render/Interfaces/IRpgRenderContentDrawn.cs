namespace ExtinctionTextAdventure.Engine
{
    public interface IRpgRenderContentDrawn
    {
        UIElement DrawnUIElement(UIElement element);

        void OpenHorizontalArea();
        void CloseHorizontalArea();

        void OpenVerticalArea();
        void CloseVerticalArea();

        void Spacing(int horizontalSpacing, int verticalSpacing);
    }
}
