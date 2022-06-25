using ExtinctionTextAdventure.Engine.Render;

namespace ExtinctionTextAdventure.Menus
{
    public class TestMenu : RpgRenderContent
    {
        private string square = "╔=╗\n" +
                        "╠=╣\n" +
                        "╘=╛";

        protected override async Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent("Separados")));

            await Task.CompletedTask;
        }
    }
}
