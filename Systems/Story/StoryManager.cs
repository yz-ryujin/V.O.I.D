using Spectre.Console;

namespace Void.Systems.Story
{
    public class StoryManager
    {
        public StoryResult StartStory()
        {
            var prologue = new PrologueEvent();
            StoryResult prologueResult = prologue.Play();

            return prologueResult;
        }
    }
}