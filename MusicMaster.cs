using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMaster : MonoBehaviour
{

    public List<AudioClip> backgroundMusicTracks;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, backgroundMusicTracks.Count);
        AudioClip randomTrack = backgroundMusicTracks[randomIndex];

        // Assign the track to the Audio Source and play it
        backgroundMusic.clip = randomTrack;
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
