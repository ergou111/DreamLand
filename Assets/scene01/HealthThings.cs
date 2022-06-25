using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthThings : MonoBehaviour
{
    public static int health;
    public static int MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        MaxHealth = 20;
        HealthBar.HealthMax = MaxHealth;
        HealthBar.HealthCurrent = health;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
