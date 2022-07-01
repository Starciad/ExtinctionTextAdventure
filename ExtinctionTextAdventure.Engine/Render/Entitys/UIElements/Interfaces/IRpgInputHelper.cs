using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Interfaces
{
    public interface IRpgInputHelper
    {
        void RenderContent<T>() where T : RpgRenderContent, new();
    }
}
