using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctionTextAdventure.Engine.Render
{
    public class UIElementContent
    {
        public string TextContent { get; set; }
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
    }
}
