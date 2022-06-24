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
        protected override async Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            contentDrawn.OpenHorizontalArea();
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent("=============="), new UIStyle()));
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent(" EXTUBCTION RPG "), new UIStyle()));
            contentDrawn.DrawnUIElement(new UIElement(new UIElementContent("=============="), new UIStyle()));
            contentDrawn.CloseHorizontalArea();

            await Task.CompletedTask;
        }
    }
}
