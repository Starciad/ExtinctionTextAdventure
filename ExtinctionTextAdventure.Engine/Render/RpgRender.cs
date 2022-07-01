namespace ExtinctionTextAdventure.Engine
{
    public static class RpgRender
    {
        public static async Task RenderContentAsync<T>() where T : RpgRenderContent, new()
        {
            Console.Clear();
            RpgRenderContent renderContent = new T();
            await renderContent.BuildRenderContentAsync();
        }
    }
}