namespace ExtinctionTextAdventure.Engine
{
    public class RpgBuilderHelper : IRpgBuilderHelper
    {
        private readonly RpgRenderContentResult rpgRenderBuilder;

        public RpgBuilderHelper(RpgRenderContentResult rpgRenderBuilder)
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