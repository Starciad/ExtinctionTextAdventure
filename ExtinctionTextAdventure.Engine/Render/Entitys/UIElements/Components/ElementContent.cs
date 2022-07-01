#pragma warning disable CS8618

using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure.Engine
{
    public sealed class ElementContent : ElementComponentBase
    {
        public string TextContent { get; private set; }
        public Vector2 Size { get; set; }

        public ElementContent()
        {
            StartupContent(string.Empty);
            Size = new Vector2(0, 0);
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
            TextContent = textContent;
            Size = GetSize();
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
            TextContent = content;
            Size = GetSize();
        }
    }
}
