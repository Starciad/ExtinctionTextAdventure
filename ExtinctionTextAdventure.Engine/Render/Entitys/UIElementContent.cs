using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure.Engine
{
    public class UIElementContent
    {
        public string TextContent { get; private set; }
        public Vector2 Size { get; set; }

        public UIElementContent()
        {
            TextContent = string.Empty;
            Size = new Vector2(0, 0);
        }
        public UIElementContent(UIElementContent contentToCopy)
        {
            TextContent = contentToCopy.TextContent;
            Size = GetSize();
        }
        public UIElementContent(string content)
        {
            TextContent = content;
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

        public void SetContent(string content)
        {
            TextContent = content;
            Size = GetSize();
        }
    }
}
