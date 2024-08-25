using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCR : MonoBehaviour
{
    public float speed = 1f;
    int time = 0;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3(0,0,speed * Time.deltaTime);
        if(transform.position.z < -30)
        {
            transform.position = Vector3.zero;
            time += 1;
            if(time > 5 && speed < 60f)
            {
                time = 0;
                speed += speed * 0.1f;
            }
        }
        
    }
}
