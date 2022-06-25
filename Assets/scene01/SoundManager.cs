using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip pickCoin;
    public static AudioClip bottle;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        bottle = Resources.Load<AudioClip>("eat");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPickCoinClip()
    {
        audioSrc.PlayOneShot(pickCoin);
    }

    public static void PlayEatClip()
    {
        audioSrc.PlayOneShot(bottle);
    }
}
