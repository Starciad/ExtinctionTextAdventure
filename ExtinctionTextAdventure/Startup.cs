﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtinctionTextAdventure.Engine.Render;
using ExtinctionTextAdventure.Menus;

namespace ExtinctionTextAdventure
{
    public class Startup
    {
        public async Task Main(string[] args)
        {
            await RpgRender.RenderContentAsync<TestMenu>();

            await Task.Delay(-1);
        }
    }
}
