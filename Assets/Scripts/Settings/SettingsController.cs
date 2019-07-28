using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Start()
        {
            _backButton.onClick.AddListener(BackButtonClick);
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
        }
        
        private void BackButtonClick()
        {
            LoadLevelSystem.LoadScene(LoadLevelSystem.MenuSceneName);
        }
    }
}
