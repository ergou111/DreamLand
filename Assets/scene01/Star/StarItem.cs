using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : MonoBehaviour
{
    public GameObject presse;

    private bool IsPlayerInStar;

    private PlayerHealth PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(IsPlayerInStar)
            {
                if(CoinUI.CurrentCoinQuantity > 0)
                {
                    SoundManager.PlayThrowCoinClip();
                    StarBinCoin.coinCurrent++;
                    CoinUI.CurrentCoinQuantity--;
                    PlayerHealth.AddHealth(1);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // in hero
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            presse.SetActive(true);
            IsPlayerInStar = true;
        } 
    }

    void OnTriggerExit2D(Collider2D other) //leave hero 
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            presse.SetActive(false);
            IsPlayerInStar = false;
        }            
    }
}
