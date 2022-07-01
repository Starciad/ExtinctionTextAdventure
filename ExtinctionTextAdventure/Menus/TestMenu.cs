using ExtinctionTextAdventure.Engine;

namespace ExtinctionTextAdventure
{
    public class TestMenu : RpgRenderContent
    {
        protected override async Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            contentDrawn.DrawnUIElement(new UIElementObject(new ElementContent("X: " + Console.WindowWidth.ToString())));
            contentDrawn.DrawnUIElement(new UIElementObject(new ElementContent("Y: " + Console.WindowHeight.ToString())));

            await Task.CompletedTask;
        }
    }
}
