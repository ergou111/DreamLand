using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    public int addLife;

    private PlayerHealth PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            SoundManager.PlayEatClip();
            PlayerHealth.AddPlayer(addLife);
            Destroy(gameObject);
        }
    }
}
