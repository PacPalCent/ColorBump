using Common;

namespace Settings.MusicButtons
{
    public class OffMusicButton : AbstractMusicButton
    {
        protected override bool IsEnable()
        {
            return !MusicController.Instance.IsEnabled;
        }

        protected override void ButtonClick()
        {
            MusicController.Instance.IsEnabled = false;
        }
    }
}