using ExtinctionTextAdventure.Engine;
using ExtinctionTextAdventure;

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
