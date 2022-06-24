using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine.Render
{
    public interface IRpgRenderContentDrawn
    {
        UIElement DrawnUIElement(UIElement element);

        void OpenHorizontalArea();
        void CloseHorizontalArea();

        void Spacing(int horizontalSpacing, int verticalSpacing);
    }
}
