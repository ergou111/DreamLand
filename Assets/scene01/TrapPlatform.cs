using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D box2d;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) //if player stand on it, then trigger this anim 如果玩家触碰到平台，则触发动画 
    {
        if(other.gameObject.CompareTag("Player")&& other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            anim.SetTrigger("collapse");
        }
    }

    void DisableBoxCollider2D()//delet it 删除触碰
    {
        box2d.enabled = false;
    }

    void DestroyTrapPlatform()//destroy this item 删除item
    {
        Destroy(gameObject);
    }
}
