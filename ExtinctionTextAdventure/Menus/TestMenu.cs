using ExtinctionTextAdventure.Engine.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Menus
{
    public class TestMenu : RpgRenderContent
    {
        string square = "╔=╗\n" +
                        "╠=╣\n" +
                        "╘=╛";

        protected override async Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent("Separados")));

            await Task.CompletedTask;
        }
    }
}
