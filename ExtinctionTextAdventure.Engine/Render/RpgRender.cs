namespace ExtinctionTextAdventure.Engine
{
    public static class RpgRender
    {
        public static async Task RenderContentAsync<T>() where T : RpgRenderContent, new()
        {
            RpgRenderContent renderContent = new T();
            await renderContent.BuildRenderContentAsync();
        }
    }
}
