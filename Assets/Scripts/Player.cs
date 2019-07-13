using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed = 10.0f;
   public float jampSpeed = 7f;

   public int PlayerHealth;

  //  private Vector2 defaultVelocity = new Vector2(10f, 0.0f);
    private Vector2  VelocityDir = new Vector2 (1f,0f);
    void Start(){
      GetComponent<Rigidbody2D>().velocity = new Vector2(speed*VelocityDir.x, 0f);
      PlayerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
      
      var speedv = GetComponent<Rigidbody2D>().velocity;
      var newv = new Vector2(speed, speedv.y);
      
      if (Input.GetKeyDown (KeyCode.Space)&&(speedv.y==0)){
            newv = newv + new Vector2(0, jampSpeed);
        }
        GetComponent<Rigidbody2D>().velocity = newv;


    }


}
