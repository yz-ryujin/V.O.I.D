using System;
using System.Threading;
using Spectre.Console;


namespace Void.Utils
{
    public static class Storyteller
    {
        public static void Narrate(string text, int delayAfter = 15000)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);

                    AnsiConsole.Markup(Markup.Escape(text.Substring(i)));
                    break;
                }

                AnsiConsole.Markup(Markup.Escape(text[i].ToString()));
                Thread.Sleep(1000);
            }
            Console.WriteLine();


            while (Console.KeyAvailable) { Console.ReadKey(true); }

            Thread.Sleep(delayAfter);
        }
    }
}
