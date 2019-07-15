/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    //public Text Health;


public class HealthCounter : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Health = "HEALTH: " + Player.PlayerHealth;
        GetComponent<Text>().text = "HEALTH: " + Config.PlayerHealth; 
    }
}
