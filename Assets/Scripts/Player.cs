using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed = 10.0f;
   public float jampSpeed = 7f;
    public int power = 70;
    public int jumpPower = 1000;
    public bool isFalling = false;
    public float gravFactor = 0.2f;

  //  private Vector2 defaultVelocity = new Vector2(10f, 0.0f);
    private Vector2  VelocityDir = new Vector2 (1f,0f);


    // Update is called once per frame
    void Update()
    {
    }

        void FixedUpdate()
        {
      /*  if (!isFalling){
        GetComponent<Rigidbody2D>().AddForce(Vector2.right*power);
          } else {
          
          }*/ 
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right*power);
        //скорость по направлению velocitydir
         GetComponent<Rigidbody2D>().velocity = new Vector2(speed*VelocityDir.x, jampSpeed*VelocityDir.y);


            if(Input.GetKey(KeyCode.Space)&&(!isFalling)){
             //GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpPower);
              VelocityDir += new Vector2(0f,1f);
              //VelocityDir = VelocityDir;
              isFalling = true;
        }
          if(isFalling){
              VelocityDir += new Vector2(0f,-gravFactor);
          }else {
            VelocityDir = new Vector2(VelocityDir.x,0f);
          }
        }

    void OnCollisionStay2D(Collision2D coll){
      if(coll.gameObject.tag == "Ground"){
        isFalling=false;
      }
    }

    void GetVelocityDir(){
     // VelocityDir =
    }

}
