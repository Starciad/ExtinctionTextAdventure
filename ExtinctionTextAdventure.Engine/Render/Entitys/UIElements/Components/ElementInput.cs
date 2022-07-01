namespace ExtinctionTextAdventure.Engine
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