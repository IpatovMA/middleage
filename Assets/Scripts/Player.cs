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
    public static int _health;
    public enum State { Run, Fall, GoAway }

    private State _state;

    private Vector2 speedv;
    private Vector2 newv;


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(defaultSpeed, 0f);
        _state = State.Run;
        _health = 5;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
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
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Border")
        {
            _health--;
            coll.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            _state = State.Fall;
        }
        if (coll.gameObject.tag == "Door")
        {
            SceneManager.LoadScene(1);
           // Invoke("SceneChanger", 2f);
            Debug.Log("qweqwe");

        }
    }

    void SceneChanger(){
            SceneManager.LoadScene(1);

    }


}
