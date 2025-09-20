using Void.Entities.Characters;
using Spectre.Console;
using System;
using System.Threading;

namespace Void.Systems.Story
{
    public class FirstRiftEvent : IStoryEvent
    {
        public StoryResult Play()
        {
            AnsiConsole.MarkupLine("[grey]Começando o evento da Primeira Fenda...[/]");
            Thread.Sleep(2000);

            return new StoryResult();
        }

        public void Narrate(string text, int delayAfter = 1500)
        {
            AnsiConsole.MarkupLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}