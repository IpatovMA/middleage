using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float defaultSpeed = 6.0f;
    public float accel = 0.1f;
    private float speedtoaccel = 0f;

    public float jampSpeed = 7f;
    public enum State { Run, Fall, GoAway }

    private State _state;

    private Vector2 speedv;
    private Vector2 newv;

   // private bool isJump = false;


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(defaultSpeed, 0f);
        _state = State.Run;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       /*  if (Input.touchCount > 0)
           {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            { isJump=true;
            } else {isJump=false;}
           }

          if (Input.GetKeyDown(KeyCode.Space))
            { isJump=true;
            } else {isJump=false;} */

        speedv = GetComponent<Rigidbody2D>().velocity;
        
       // _position = ;
        if (_state == State.Run)
        {

            newv = new Vector2(defaultSpeed, speedv.y);

            if (Input.GetKeyDown(KeyCode.Space) && (speedv.y == 0))
            {
                newv = newv + new Vector2(0, jampSpeed);
            }

        }

        if (_state == State.Fall)
        {
            
            newv = new Vector2(speedtoaccel, speedv.y);
            speedtoaccel += accel;
            if (speedtoaccel >= defaultSpeed)
            {
                _state = State.Run;
                speedtoaccel = 0.0f;

            }
        }

        GetComponent<Rigidbody2D>().velocity = newv;

        if (Config.PlayerHealth == 0){
            _state = State.GoAway;

        }

        if (_state == State.GoAway){
            newv = newv*0.01f;
            Invoke("SceneChanger", 2f);

        }

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Border")
        {
            Config.PlayerHealth--;
            coll.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            _state = State.Fall;
        }
        if (coll.gameObject.tag == "Door")
        {
            _state = State.GoAway;
           // Invoke("SceneChanger", 2f);
        }
    }

    void SceneChanger(){
            SceneManager.LoadScene(1);

    }


}
