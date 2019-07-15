using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static int PlayerHealth = 5;
    public static float scale1;
    public static float scale2;
    public static float scale3;
    public static bool isDead;

    
  //  public static enum currentScene {}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDead = (PlayerHealth<=0);


    }
}
