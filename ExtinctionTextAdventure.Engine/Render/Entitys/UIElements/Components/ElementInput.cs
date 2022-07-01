using ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Interfaces;

namespace ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Components
{
    public sealed class ElementInput : ElementComponentBase
    {
        public Action<IRpgInputHelper>? OnSelected { get; set; }

        public ElementInput() { }
        public ElementInput(ElementInput input)
        {
            OnSelected = input.OnSelected;
        }
    }
}