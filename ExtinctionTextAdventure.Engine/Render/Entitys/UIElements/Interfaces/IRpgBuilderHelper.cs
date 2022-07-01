﻿namespace ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Interfaces
{
    public interface IRpgBuilderHelper
    {
        void AddElementToRenderQueue(UIEntityRender uiEntity);
        void AddElementsToRenderQueue(IEnumerable<UIEntityRender> uiEntities);
    }
}