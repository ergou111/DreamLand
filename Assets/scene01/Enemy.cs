using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    private PlayerHealth PlayerHealth;


    public int damage;
    public int health;
    public float flashtime;

    public GameObject BloodEffect;
    public GameObject dropCoin;

    // Start is called before the first frame update
    public void Start()
    {
        PlayerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Instantiate(dropCoin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int Damage)
    {
        SoundManager.HitEnemyClip();
        health = health - Damage;
        FlashColor(flashtime);
        Instantiate(BloodEffect, transform.position, Quaternion.identity);
        GameController.CameraShake.Shake();
    }

    //if hurt change color to red
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor",time);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")//if hurt player and get the capsule
        {
            if(PlayerHealth != null)
            {
                PlayerHealth.DamagePlayer(damage);
            }
        } 
    }
}
