using Assets.Scripts.Data_Models;
using UnityEngine;

namespace Assets.AudioSystem
{
    public class AudioClipManager : MonoBehaviour
    {
        public static AudioClipManager Instance { get; private set; }

        public SoundAudioClip[] SoundAudioClips;
        public MusicAudioClip[] MusicAudioClips;

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
    }
}
