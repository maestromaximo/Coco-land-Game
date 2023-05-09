using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    public AudioSource ambientPlayer;
    public AudioClip rainSound;
    public AudioClip wavesSound;
    public AudioClip bark;
    public AudioSource miscPlayer;

    public ParticleSystem rainSystem;

    public Sprite goodBack, darkBack;

    public SpriteRenderer backGroundRender;

    public int probabilityOfRain = 5;
    public int barkProbability = 25;
    // Start is called before the first frame update
    void Start()
    {
        
        int randomP = Random.Range(0, 100);

        if (randomP < probabilityOfRain)
        {
            ambientPlayer.clip = rainSound;
            ambientPlayer.PlayDelayed(1.2f);
            rainSystem.enableEmission = true;
            backGroundRender.sprite = darkBack;
        }
        else
        {
            ambientPlayer.clip = wavesSound;
            ambientPlayer.PlayDelayed(1.2f);
            rainSystem.enableEmission = false;
            backGroundRender.sprite = goodBack;
        }
        StartCoroutine(barkRoutine());
        miscPlayer.clip = bark;
    }

    IEnumerator barkRoutine()
    {
        int randomP = Random.Range(0, 100);
        int randomTime = Random.Range(1, 12);
        if (randomP < barkProbability)
        {
            miscPlayer.Play();

            int duoRand = Random.Range(0, 2);

            if (duoRand == 0)
            {
                Debug.Log("reached");
                yield return new WaitForSeconds(0.49f);
                miscPlayer.Play();

                int duoRand2 = Random.Range(0, 2);
                if (duoRand2 == 0)
                {
                    Debug.Log("reached2");
                    yield return new WaitForSeconds(0.5f);
                    miscPlayer.Play();
                }
            }

        }
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(barkRoutine());
    }
    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
