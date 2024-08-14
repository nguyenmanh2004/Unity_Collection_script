using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class Song
{
    public string name;
    public AudioClip audioClip;
}
public class MusicPlayer : MonoBehaviour
{
    public List<Song> songList;
    public TextMeshProUGUI songNameText;
    AudioSource audioMusic;
    private int currentIndex = 0;
    void Start()
    {
         //Khởi tạo danh sách bài hát
        songList = new List<Song>
        {
        new Song { name = "Ngáo ngơ", audioClip = Resources.Load<AudioClip>("Ngáo Ngơ") },
        new Song { name = "Ngân Nga", audioClip = Resources.Load<AudioClip>("Ngân Nga") },
        new Song { name = "Cứ để anh ta rời đi", audioClip = Resources.Load<AudioClip>("Cứ để anh ta rời đi") },
        };
        audioMusic = GetComponent<AudioSource>();
        PlaySong(0);
    }
    public void PlaySong(int index)
    {
        Song song = songList[index];
        songNameText.text = song.name;
        audioMusic.clip = song.audioClip;
        audioMusic.Play();
        audioMusic.loop = true;
    }
    public void PlayNextSong()
    {
        currentIndex = (currentIndex + 1) % songList.Count;
        PlaySong(currentIndex);
    }
    void Update()
    {
        
    }
}
