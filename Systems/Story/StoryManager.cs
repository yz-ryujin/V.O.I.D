using Spectre.Console;

namespace Void.Systems.Story
{
    public class StoryManager
    {
        public StoryResult PlayPrologue()
        {
            var prologue = new PrologueEvent();

            return prologue.Play();
        }

        public StoryResult PlayFirstRift()
        {
            var riftEvent = new FirstRiftEvent();
            return riftEvent.Play();
        }
    }
}