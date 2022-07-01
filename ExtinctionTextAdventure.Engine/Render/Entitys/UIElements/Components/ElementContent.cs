#pragma warning disable CS8618

using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure.Engine.Render.Entitys.UIElements.Components
{
    public sealed class ElementContent : ElementComponentBase
    {
        public string TextContent => textContent;
        public Vector2 Size => size;

        private string textContent = string.Empty;
        private Vector2 size = new(0, 0);

        public ElementContent()
        {
            StartupContent(string.Empty);
        }
        public ElementContent(ElementContent contentToCopy)
        {
            StartupContent(contentToCopy.TextContent);
        }
        public ElementContent(string content)
        {
            StartupContent(content);
        }

        private void StartupContent(string textContent)
        {
            this.textContent = textContent;
            size = GetSize();
        }
        private Vector2 GetSize()
        {
            string[] lines = TextContent.Split('\n');

            var bigString = lines.Select((val, ix) => new { len = val.Length, ix }).OrderByDescending(x => x.len).FirstOrDefault();

            int x = bigString != null ? bigString.len : 0;
            int y = lines.Length;

            return new Vector2(x, y);
        }

        //================//

        public void SetContent(string content)
        {
            textContent = content;
            size = GetSize();
        }
    }
}
