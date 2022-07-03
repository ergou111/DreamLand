using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    public GameObject hideSpikeBox;
    public float time;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //PlayerHealth.DamagePlayer(damage);
            StartCoroutine(SpikeAttack());
        }
    }

    IEnumerator SpikeAttack() //Ctrip 携程
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("attack");
        Instantiate(hideSpikeBox,transform.position, Quaternion.identity);
    }
}
