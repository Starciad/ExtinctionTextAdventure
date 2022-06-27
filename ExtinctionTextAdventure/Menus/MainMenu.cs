using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtinctionTextAdventure.Engine;
using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure
{
    public class MainMenu : RpgRenderContent
    {
        private IRpgRenderContentDrawn? contentDrawn;

        protected override Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            this.contentDrawn = contentDrawn;

            BuildTitle();
            BuildOptions();

            return Task.CompletedTask;
        }

        private void BuildTitle()
        {
            UIElement titleLine = new(new UIElementContent(new string('=', 80)), new UIStyle() { Color = ConsoleColor.Gray });
            UIElement title = new(new UIElementContent("EXTINCTION TEXT ADVENTURE"), new UIStyle() { Color = ConsoleColor.Yellow });

            titleLine.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (titleLine.Content.Size.X / 2) - 1;
            title.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (title.Content.Size.X / 2) - 1;

            contentDrawn?.Spacing(0, 2);
            contentDrawn?.DrawnUIElement(titleLine);
            contentDrawn?.DrawnUIElement(title);
            contentDrawn?.DrawnUIElement(titleLine);
            contentDrawn?.Spacing(0, 2);
        }
        private void BuildOptions()
        {

        }
    }
}
