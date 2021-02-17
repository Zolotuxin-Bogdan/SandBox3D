using Assets.Scripts;
using Assets.Scripts.Enums;
using Assets.Scripts.Tools_and_Managers;
using UnityEngine;

namespace Assets.AudioSystem
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance { get; private set; }

        public SettingsManager GameSettingsManager;

        private GameObject _musicGameObject;
        private AudioSource _musicAudioSource;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }

        }

        public void PlaySoundOnce(Sound sound, float pitch = 1f, float volume = 1f)
        {
            var volumeFromSettings = GameSettingsManager.GetSettings().sfxVolume;
            var soundGameObject = new GameObject("Sound");
            var audioSource = soundGameObject.AddComponent<AudioSource>();
            if (!pitch.Equals(1f))
            {
                audioSource.pitch = pitch;
            }
            audioSource.volume = volumeFromSettings;
            if (!volume.Equals(1f))
            {
                audioSource.volume = volume;
            }
            audioSource.PlayOneShot(GetSoundAudioClip(sound));
            Destroy(soundGameObject, audioSource.clip.length);
        }

        public void PlaySoundOnce(Sound sound, Vector3 soundPosition, float minSoundDistance, float maxSoundDistance, float pitch = 1f, float volume = 1f)
        {
            var volumeFromSettings = GameSettingsManager.GetSettings().sfxVolume;
            var soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = soundPosition;
            var audioSource = soundGameObject.AddComponent<AudioSource>();
            if (!pitch.Equals(1f))
            {
                audioSource.pitch = pitch;
            }
            audioSource.volume = volumeFromSettings;
            if (!volume.Equals(1f))
            {
                audioSource.volume = volume;
            }
            audioSource.rolloffMode = AudioRolloffMode.Linear; 
            audioSource.minDistance = minSoundDistance;
            audioSource.maxDistance = maxSoundDistance;
            audioSource.clip = GetSoundAudioClip(sound);
            audioSource.Play();
            Destroy(soundGameObject, audioSource.clip.length);
        }

        public void PlaySoundRepeat(Sound sound, float pitch = 1f, float volume = 1f)
        {
            var volumeFromSettings = GameSettingsManager.GetSettings().sfxVolume;
            var soundGameObject = new GameObject("Repeat Sound");
            var audioSource = soundGameObject.AddComponent<AudioSource>();
            if (!pitch.Equals(1f))
            {
                audioSource.pitch = pitch;
            }
            audioSource.volume = volumeFromSettings;
            if (!volume.Equals(1f))
            {
                audioSource.volume = volume;
            }
            audioSource.loop = true;
            audioSource.clip = GetSoundAudioClip(sound);
            audioSource.Play();
            //Destroy(soundGameObject, audioSource.clip.length);
        }

        public void PlaySoundRepeat(Sound sound, Vector3 soundPosition, float minSoundDistance, float maxSoundDistance, float pitch = 1f, float volume = 1f)
        {
            var volumeFromSettings = GameSettingsManager.GetSettings().sfxVolume;
            var soundGameObject = new GameObject("Repeat Sound");
            soundGameObject.transform.position = soundPosition;
            var audioSource = soundGameObject.AddComponent<AudioSource>();
            if (!pitch.Equals(1f))
            {
                audioSource.pitch = pitch;
            }
            audioSource.volume = volumeFromSettings;
            if (!volume.Equals(1f))
            {
                audioSource.volume = volume;
            }
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.minDistance = minSoundDistance;
            audioSource.maxDistance = maxSoundDistance;
            audioSource.loop = true;
            audioSource.clip = GetSoundAudioClip(sound);
            audioSource.Play();
            //Destroy(soundGameObject, audioSource.clip.length);
        }

        public void PlayMusic(Music music, float pitch = 1f, float volume = 1f)
        {
            var volumeFromSettings = GameSettingsManager.GetSettings().musicVolume;
            if (_musicGameObject == null)
            {
                _musicGameObject = new GameObject("Music");
                _musicAudioSource = _musicGameObject.AddComponent<AudioSource>();
            }
            if (!pitch.Equals(1f))
            {
                _musicAudioSource.pitch = pitch;
            }
            _musicAudioSource.volume = volumeFromSettings;
            if (!volume.Equals(1f))
            {
                _musicAudioSource.volume = volume;
            }

            _musicAudioSource.clip = GetMusicAudioClip(music);
            _musicAudioSource.Play();
        }

        private AudioClip GetSoundAudioClip(Sound sound)
        {
            foreach (var soundAudioClip in AudioClipManager.Instance.SoundAudioClips)
            {
                if (soundAudioClip.Sound == sound)
                {
                    return soundAudioClip.AudioClip;
                }
            }

            return null;
        }

        private AudioClip GetMusicAudioClip(Music music)
        {
            foreach (var musicAudioClip in AudioClipManager.Instance.MusicAudioClips)
            {
                if (musicAudioClip.Music == music)
                {
                    return musicAudioClip.AudioClip;
                }
            }

            return null;
        }
    }
}
