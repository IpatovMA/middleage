using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultipiler = 2.5f;
    public float lowJampMultipiler = 1f;
    Rigidbody2D rb;
    void Awake()
    {
     rb = GetComponent<Rigidbody2D>();   
    }
    void Update(){
        if (rb.velocity.y < 0){
             rb.velocity += Vector2.up*Physics2D.gravity.y*(fallMultipiler - 1)*Time.deltaTime;
    }else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)){
            rb.velocity += Vector2.up*Physics2D.gravity.y*(lowJampMultipiler - 1)*Time.deltaTime;
    }
    }
}
