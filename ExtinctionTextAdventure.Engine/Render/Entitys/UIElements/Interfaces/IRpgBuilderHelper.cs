namespace ExtinctionTextAdventure.Engine
{
    public interface IRpgBuilderHelper
    {
        void AddElementToRenderQueue(UIEntityRender uiEntity);

        void AddElementsToRenderQueue(IEnumerable<UIEntityRender> uiEntities);
    }
}