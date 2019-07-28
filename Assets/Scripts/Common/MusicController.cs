using System;
using Common.Help;
using Extensions;
using UnityEngine;

namespace Common
{
    public class MusicController : Singleton<MusicController>
    {
        public bool IsEnabled
        {
            get => !this.LoadComponent(ref _audioSource).mute;
            set
            {
                this.LoadComponent(ref _audioSource).mute = !value;
                MusicEnableChanged.Call();
            }
        }
        public Action MusicEnableChanged;
        private AudioSource _audioSource;
    }
}