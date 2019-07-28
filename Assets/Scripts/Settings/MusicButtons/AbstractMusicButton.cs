using Common;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Settings.MusicButtons
{
    public abstract class AbstractMusicButton : MonoBehaviour
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private Image _buttonImage;

        private Button _button;

        protected abstract bool IsEnable();
        protected abstract void ButtonClick();

        private void Start()
        {
            MusicController.Instance.MusicEnableChanged += OnMusicEnableChanged;
            this.LoadComponent(ref _button).onClick.AddListener(ButtonClick);
            OnMusicEnableChanged();
        }

        private void OnDestroy()
        {
            MusicController.Instance.MusicEnableChanged -= OnMusicEnableChanged;
            this.LoadComponent(ref _button).onClick.RemoveAllListeners();
        }

        private void OnMusicEnableChanged()
        {
            _buttonImage.sprite = IsEnable() ? _enableSprite : _disableSprite;
        }
    }
}