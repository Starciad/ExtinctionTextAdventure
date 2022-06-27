using ExtinctionTextAdventure.Engine;

namespace ExtinctionTextAdventure
{
    public class TestMenu : RpgRenderContent
    {
        protected override async Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent("X: " + Console.WindowWidth.ToString())));
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent("Y: " + Console.WindowHeight.ToString())));

            await Task.CompletedTask;
        }
    }
}
