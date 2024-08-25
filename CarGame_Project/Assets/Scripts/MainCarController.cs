using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x >= 0)
                transform.position -= new Vector3(7, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < 7)
                transform.position += new Vector3(7, 0, 0);

        }
    }
}
