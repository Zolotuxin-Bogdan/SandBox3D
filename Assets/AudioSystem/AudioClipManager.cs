using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    public static AudioClipManager Instance { get; private set; }

    public SoundAudioClip[] SoundAudioClips;

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
