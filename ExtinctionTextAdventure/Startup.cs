using ExtinctionTextAdventure;
using ExtinctionTextAdventure.Core.Render;

namespace ExtinctionTextAdventure
{
    public class Startup
    {
        public async Task Main()
        {
            await RpgRender.RenderContentAsync<MainMenu>();

            await Task.Delay(-1);
        }
    }
}
