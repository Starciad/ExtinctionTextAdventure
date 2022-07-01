#pragma warning disable CS8618

using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Components;
using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Interfaces;

namespace ExtinctionTextAdventure.Engine.Render.Entitys.UIElements
{
    public sealed class UIElementObject : UIEntityRender
    {
        public static UIElementObject BreakLine => new(null, new ElementStyle() { IsInvisible = true, Inline = false });

        public ElementContent Content => content;
        public ElementStyle Style => style;
        public ElementInput Input => input;

        private ElementContent content;
        private ElementStyle style;
        private ElementInput input;

        public UIElementObject()
        {
            StartupElementObject(null, null, null);
        }
        public UIElementObject(ElementContent? content = null, ElementStyle? style = null, ElementInput? input = null)
        {
            StartupElementObject(content, style, input);
        }
        public UIElementObject(UIElementObject elementToCopy)
        {
            StartupElementObject(elementToCopy.content, elementToCopy.style, elementToCopy.input);
        }

        private void StartupElementObject(ElementContent? content, ElementStyle? style, ElementInput? input)
        {
            UIElementObject uIElementObject = this;

            //Content
            if (content == null) uIElementObject.content = new();
            else uIElementObject.content = new(content);

            //Style
            if (style == null) uIElementObject.style = new();
            else uIElementObject.style = new(style);

            //Input
            if (input == null) uIElementObject.input = new();
            else uIElementObject.input = new(input);
        }
        public override async Task<UIElementObject>? BuildElementAsync(IRpgBuilderHelper builderHelper)
        {
            return await Task.FromResult(new UIElementObject(this));
        }
    }
}