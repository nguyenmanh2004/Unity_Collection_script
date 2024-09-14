using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } set { instance = value; } }

    public List<AudioClip> audioBackGround;
    public AudioSource audioBackgroundSource;
    public AudioSource audioEffectsSource;
    public AudioSource audioEffectsBackupSource;
    public AudioSource audioLvUpSource;
    public AudioClip audioLvUp;
    public AudioClip audioHit;
    public AudioClip audioPickupGold;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        audioBackgroundSource.clip = audioBackGround[0];
        audioBackgroundSource.Play();
        audioBackgroundSource.loop = true;
    }

    public void ChangeAudioBackground(int index)
    {
        if (index >= 0 && index < audioBackGround.Count)
        {
            audioBackgroundSource.clip = audioBackGround[index];
            audioBackgroundSource.Play();
            audioBackgroundSource.loop = true;
        }
    }
    public void SoundLevelUp()
    {
        audioLvUpSource.PlayOneShot(audioLvUp);
    }
    public void PlayAudioHit()
    {
        audioEffectsSource.PlayOneShot(audioHit);
    }

    public void PlayAudioPickupGold()
    {
        audioEffectsBackupSource.PlayOneShot(audioPickupGold);
    }
}