using ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Interfaces;
using ExtinctionTextAdventure.Core.Render.Enums;

namespace ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Areas
{
    public sealed class UIInputArea : UIEntityRender
    {
        private InputAreaType AreaType { get; }
        private List<UIElementObject> InputElements { get; }

        public UIInputArea(InputAreaType inputAreaType)
        {
            AreaType = inputAreaType;
            InputElements = new();
        }
        public void AddElement(UIElementObject uiElement)
        {
            InputElements.Add(uiElement);
        }

        public override async Task<UIElementObject>? BuildElementAsync(IRpgBuilderHelper builderHelper)
        {
            builderHelper.AddElementsToRenderQueue(InputElements);
            return await Task.FromResult<UIElementObject>(null!);
        }
    }
}