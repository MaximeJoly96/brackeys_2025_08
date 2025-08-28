namespace CookieGambler
{
    public static class LevelManager
    {
        public static int CurrentLevel = 0;

        public static void IncrementLevel()
        {
            CurrentLevel++;

            if (CurrentLevel > 4)
                CurrentLevel = 4;
        }
    }
}
