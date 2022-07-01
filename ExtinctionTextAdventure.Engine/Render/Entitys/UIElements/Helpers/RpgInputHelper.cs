using ExtinctionTextAdventure.Core.Render.Builders;
using ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Helpers
{
    internal sealed class RpgInputHelper : IRpgInputHelper
    {
        internal RpgInputHelper(RpgRenderContentResult rpgRenderContentResult)
        {

        }

        public void RenderContent<T>() where T : RpgRenderContent, new()
        {
            RpgRender.RenderContentAsync<T>().GetAwaiter().GetResult();
        }
    }
}
