using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public int smoothTime = 5;
    public float offset = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
         if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + offset, transform.position.y, transform.position.z), Time.deltaTime * smoothTime);
        }       
    }
}
