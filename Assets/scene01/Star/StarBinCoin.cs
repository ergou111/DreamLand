using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBinCoin : MonoBehaviour
{
    public static int coinCurrent;
    public static int coinMax;

    private Image trashBinbar;

    // Start is called before the first frame update
    void Start()
    {
        trashBinbar = GetComponent<Image>();
        coinCurrent = 0;
        coinMax = 99;
        
    }

    // Update is called once per frame
    void Update()
    {
        trashBinbar.fillAmount = (float)coinCurrent / (float)coinMax;
    }
}
