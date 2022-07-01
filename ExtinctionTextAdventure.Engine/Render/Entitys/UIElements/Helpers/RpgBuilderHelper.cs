using ExtinctionTextAdventure.Engine.Render.Builders;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Interfaces;

namespace ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Helpers
{
    internal sealed class RpgBuilderHelper : IRpgBuilderHelper
    {
        private readonly RpgRenderContentResult rpgRenderBuilder;

        internal RpgBuilderHelper(RpgRenderContentResult rpgRenderBuilder)
        {
            this.rpgRenderBuilder = rpgRenderBuilder;
        }

        public void AddElementToRenderQueue(UIEntityRender uiEntity)
        {
            rpgRenderBuilder.UiEntitiesToRender.Insert(rpgRenderBuilder.CurrentEntityToRenderInQueue, uiEntity);
        }
        public void AddElementsToRenderQueue(IEnumerable<UIEntityRender> uiEntities)
        {
            rpgRenderBuilder.UiEntitiesToRender.InsertRange(rpgRenderBuilder.CurrentEntityToRenderInQueue, uiEntities);
        }
    }
}