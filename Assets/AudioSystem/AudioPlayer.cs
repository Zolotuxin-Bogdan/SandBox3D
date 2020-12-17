using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    private static GameObject _oneShotGameObject;
    private static AudioSource _oneShotAudioSource;

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

    public void PlaySoundOnce(Sound sound)
    {
        if (_oneShotGameObject == null)
        {
            _oneShotGameObject = new GameObject("One Shot Sound");
            _oneShotAudioSource = _oneShotGameObject.AddComponent<AudioSource>();
        }

        _oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
    }

    public void PlaySoundOnce(Sound sound, float pitch)
    {
        var soundGameObject = new GameObject("One Shot Sound");
        var audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(GetAudioClip(sound));
        Destroy(soundGameObject, audioSource.clip.length);
    }

    public void PlaySoundOnce(Sound sound, Vector3 soundPosition, float minSoundDistance, float maxSoundDistance)
    {
        var soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = soundPosition;
        var audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.minDistance = minSoundDistance;
        audioSource.maxDistance = maxSoundDistance;
        audioSource.Play();
        Destroy(soundGameObject, audioSource.clip.length);
    }

    public void PlaySoundOnce(Sound sound, Vector3 soundPosition, float pitch, float minSoundDistance, float maxSoundDistance)
    {
        var soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = soundPosition;
        var audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.pitch = pitch;
        audioSource.minDistance = minSoundDistance;
        audioSource.maxDistance = maxSoundDistance;
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
        Destroy(soundGameObject, audioSource.clip.length);
    }

    private AudioClip GetAudioClip(Sound sound)
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
}
