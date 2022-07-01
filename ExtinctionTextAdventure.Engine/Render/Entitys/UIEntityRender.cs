namespace ExtinctionTextAdventure.Engine
{
    public abstract class UIEntityRender
    {
        public abstract Task<UIElementObject>? BuildElementAsync(IRpgBuilderHelper builderHelper);
    }
}