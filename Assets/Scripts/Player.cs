using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int power = 70;
  //  public float speed = 10.0f;
    public int jumpPower = 1000;
    public bool isFalling = false;

    // Update is called once per frame
    void Update()
    {
     GetComponent<Rigidbody2D>().AddForce(Vector2.right*power);
    //  GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);

        if(Input.GetKey(KeyCode.Space)&&(!isFalling)){
          GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpPower);

          isFalling = true;
        }

    //    if

    }

    void OnCollisionStay2D(Collision2D coll){
      if(coll.gameObject.tag == "Ground"){
        isFalling=false;
      }
    }


}
