using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect
{
    PlayerShoot,
    EnemyShoot,
    PlayerDeath,
    ShieldGain,
    ShieldLose,
    ItemPickup
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (SoundManager.Instance != null)
        {
            Destroy(SoundManager.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [Header("SFX Effect")]
    [SerializeField] List<SoundAudioClip> soundAudioClipLst;

    [Header("Reference")]
    [SerializeField] AudioSource audioSource;

    public void PlaySound(SoundEffect soundEffect)
    {
        audioSource.PlayOneShot(GetAudioClip(soundEffect));
    }

    private AudioClip GetAudioClip(SoundEffect soundEffect)
    {
        foreach (SoundAudioClip soundAudioClip in soundAudioClipLst)
        {
            if (soundAudioClip.soundEffect == soundEffect)
            {
                return soundAudioClip.audioClip;
            }
        }

        return null;
    }
}
