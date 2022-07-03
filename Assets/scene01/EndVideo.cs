using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{
    public VideoPlayer video;
    public new GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        if(!video.isPlaying)
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
