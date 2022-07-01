using ExtinctionTextAdventure.Core.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Interfaces;

namespace ExtinctionTextAdventure.Core.Render.Entitys
{
    public abstract class UIEntityRender
    {
        public abstract Task<UIElementObject>? BuildElementAsync(IRpgBuilderHelper builderHelper);
    }
}