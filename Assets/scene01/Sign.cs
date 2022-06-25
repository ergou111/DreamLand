using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogbox;
    public GameObject presse;
    private bool isPlayerInSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        {
            dialogbox.SetActive(true);
        } 
    }

    void OnTriggerEnter2D(Collider2D other) // in hero
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            presse.SetActive(true);
            isPlayerInSign = true;
        } 
    }

    void OnTriggerExit2D(Collider2D other) //leave hero 
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            presse.SetActive(false);
            Debug.Log("text");
            isPlayerInSign = false;
            dialogbox.SetActive(false);
        }            
    }
}
