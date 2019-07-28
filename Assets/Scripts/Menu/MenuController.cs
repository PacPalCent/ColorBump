using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        private void Start()
        {
            _playButton.onClick.AddListener(PlayButtonClick);
            _settingsButton.onClick.AddListener(SettingsButtonClick);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
        }

        private void PlayButtonClick()
        {
            LoadLevelSystem.LoadScene(LoadLevelSystem.GameSceneName);
        }

        private void SettingsButtonClick()
        {
            LoadLevelSystem.LoadScene(LoadLevelSystem.SettingsSceneName);
        }
    }
}
