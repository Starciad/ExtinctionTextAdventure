using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine.Render
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
