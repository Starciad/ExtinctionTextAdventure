using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtinctionTextAdventure.Core.Render;
using ExtinctionTextAdventure.Core.Render.Entitys.UIElements;
using ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Components;
using ExtinctionTextAdventure.Core.Render.Entitys.UIElements.Interfaces;
using ExtinctionTextAdventure.Core.Render.Enums;
using ExtinctionTextAdventure.Core.Render.Interfaces;
using ExtinctionTextAdventure.Utilities;

namespace ExtinctionTextAdventure
{
    public class MainMenu : RpgRenderContent
    {
        private IRpgRenderContentDrawn? contentDrawn;

        protected override Task OnStartAsync(IRpgRenderContentDrawn contentDrawn)
        {
            this.contentDrawn = contentDrawn;

            BuildTitle();
            BuildOptions();

            return Task.CompletedTask;
        }

        private void BuildTitle()
        {
            UIElementObject titleLine = new(new ElementContent("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-"), new ElementStyle() { Color = ConsoleColor.Gray });
            UIElementObject title = new(new ElementContent("EXTINCTION TEXT ADVENTURE"), new ElementStyle() { Color = ConsoleColor.Yellow });
            UIElementObject author = new(new ElementContent("By Starciad"), new ElementStyle() { Color = ConsoleColor.DarkGreen });
            UIElementObject version = new(new ElementContent("V1.0"), new ElementStyle() { Color = ConsoleColor.DarkGreen });

            titleLine.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (titleLine.Content.Size.X / 2) - 1;
            title.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (title.Content.Size.X / 2) - 1;

            //Title Box
            contentDrawn?.Spacing(0, 2);
            contentDrawn?.DrawnUIElement(titleLine);
            contentDrawn?.Spacing(0, 1);
            contentDrawn?.DrawnUIElement(title);
            contentDrawn?.Spacing(0, 1);
            contentDrawn?.DrawnUIElement(titleLine);

            //Other infos
            contentDrawn?.OpenHorizontalArea();
                contentDrawn?.Spacing(RpgMath.GetPercentageValue(Console.BufferWidth, 50) - ((author.Content.Size.X + version.Content.Size.X) / 2) - 18, 0);
                contentDrawn?.DrawnUIElement(author);
                contentDrawn?.Spacing(34, 0);
                contentDrawn?.DrawnUIElement(version);
            contentDrawn?.CloseHorizontalArea();
        }
        private void BuildOptions()
        {
            UIElementObject playInput = new(new ElementContent("Play"), new ElementStyle(), new ElementInput() { OnSelected = PlayInput });
            UIElementObject optionsInput = new(new ElementContent("Options"), new ElementStyle(), new ElementInput() { OnSelected = OptionsInput });
            UIElementObject modsInput = new(new ElementContent("Mods"), new ElementStyle(), new ElementInput() { OnSelected = ModsInput });
            UIElementObject quitInput = new(new ElementContent("Quit"), new ElementStyle(), new ElementInput() { OnSelected = QuitInput });

            playInput.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (playInput.Content.Size.X / 2) - 1;
            optionsInput.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (optionsInput.Content.Size.X / 2) - 1;
            modsInput.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (modsInput.Content.Size.X / 2) - 1;
            quitInput.Style.HorizontalSpacing = RpgMath.GetPercentageValue(Console.BufferWidth, 50) - (quitInput.Content.Size.X / 2) - 1;

            //=======================//

            contentDrawn?.Spacing(0, 5);

            contentDrawn?.OpenInputArea(InputAreaType.Writer);
                contentDrawn?.DrawnUIInput(playInput);
                contentDrawn?.DrawnUIInput(optionsInput);
                contentDrawn?.DrawnUIInput(modsInput);
                contentDrawn?.DrawnUIInput(quitInput);
            contentDrawn?.CloseInputArea();
        }

        //===========================//
        //Input

        private void PlayInput(IRpgInputHelper inputHelper)
        {
            inputHelper.RenderContent<MainMenu>();
        }
        private void OptionsInput(IRpgInputHelper inputHelper)
        {
            inputHelper.RenderContent<MainMenu>();
        }
        private void ModsInput(IRpgInputHelper inputHelper)
        {
            inputHelper.RenderContent<MainMenu>();
        }
        private void QuitInput(IRpgInputHelper inputHelper)
        {
            Environment.Exit(0);
        }
    }
}
