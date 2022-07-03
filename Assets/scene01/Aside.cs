using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aside : MonoBehaviour
{
    public GameObject asideBox;
    public GameObject trig;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void deletAside()
    {
        asideBox.SetActive(false);
        trig.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) // in hero
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            asideBox.SetActive(true);
        } 
    }

    void OnTriggerExit2D(Collider2D other) //leave hero 
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            animator.SetBool("out",true);
            Invoke("deletAside",1f);
            
            
        }            
    }
}
