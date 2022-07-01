using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine
{
    public interface IRpgInputHelper
    {
        void RenderContent<T>() where T : RpgRenderContent, new();
    }
}
