using UnityEngine.SceneManagement;

namespace Common
{
    public static class LoadLevelSystem
    {
        public const string MenuSceneName = "Menu";
        public const string SettingsSceneName = "Settings";
        public const string GameSceneName = "Game";

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
