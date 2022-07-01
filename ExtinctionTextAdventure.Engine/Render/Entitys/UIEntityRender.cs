using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Interfaces;

namespace ExtinctionTextAdventure.Engine.Render.Entitys
{
    public abstract class UIEntityRender
    {
        public abstract Task<UIElementObject>? BuildElementAsync(IRpgBuilderHelper builderHelper);
    }
}