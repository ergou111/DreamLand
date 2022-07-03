using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Bilnks;
    public float time;

    private Renderer myRenderer;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        HealthThings.health = HealthThings.health - damage;
        if(HealthThings.health <= 0)
        {
            HealthThings.health =0;
        }
        HealthBar.HealthCurrent = HealthThings.health;
        if(HealthThings.health <= 0)//if health less than 0 then player die
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 1f);
            Restart();
        }
        BilnkPlayer(Bilnks, time);//if player hurt, than flicker;
    }

    public void AddPlayer(int AddPlayer)
    {
        HealthThings.health = HealthThings.health + AddPlayer;
        if(HealthThings.health >= HealthThings.MaxHealth)
        {
            HealthThings.health = HealthThings.MaxHealth;
        }
        HealthBar.HealthCurrent = HealthThings.health;
    }

    void BilnkPlayer(int numBlink, float seconds)// blink 闪烁
    {
        StartCoroutine(DoBlinks( numBlink, seconds));
    }

    IEnumerator DoBlinks(int numBlink, float seconds)//Ctrip
    {
        for(int i=0; i<numBlink*2; i++)
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HealthThings.health=HealthThings.MaxHealth;
        HealthBar.HealthCurrent = HealthThings.health;
        
    }

    public void AddHealth(int add)
    {
        HealthThings.MaxHealth = HealthThings.MaxHealth+add;
        HealthThings.health = HealthThings.MaxHealth;
        HealthBar.HealthMax = HealthThings.MaxHealth;
        HealthBar.HealthCurrent = HealthThings.health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Dieline"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
