using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    void Start()
    {
        ManagerModel.DestoryAllCars += DestoryCar;
    }

    void Update()
    {
        if (transform.position.z > -44)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, -44f), moveSpeed * Time.deltaTime * ManagerModel.WallMoveSpeedTimes);
            if (transform.position.z < -43f)
            {
                DestoryCar();
            }
        }
    }

    void DestoryCar()
    {
        ManagerModel.DestoryAllCars -= DestoryCar;
        Destroy(gameObject);
    }
}
