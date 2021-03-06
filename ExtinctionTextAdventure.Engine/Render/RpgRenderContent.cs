using ExtinctionTextAdventure.Core.Render.Builders;
using ExtinctionTextAdventure.Core.Render.Interfaces;

namespace ExtinctionTextAdventure.Core.Render
{
    public abstract class RpgRenderContent
    {
        private readonly RpgRenderContentBuilder contentBuilder = new();

        internal async Task BuildRenderContentAsync()
        {
            await OnStartAsync(contentBuilder);
            await contentBuilder.FinalConfiguration();

            RpgRenderContentResult renderResult = await contentBuilder.CompileContentAsync();
            await renderResult.ShowRenderAsync();
        }

        //======================//

        protected abstract Task OnStartAsync(IRpgRenderContentDrawn contentDrawn);
    }
}