using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine
{
    public class RpgInputHelper : IRpgInputHelper
    {
        public RpgInputHelper(RpgRenderContentResult rpgRenderContentResult)
        {

        }

        public void RenderContent<T>() where T : RpgRenderContent, new()
        {
            RpgRender.RenderContentAsync<T>().GetAwaiter().GetResult();
        }
    }
}
