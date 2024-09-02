using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallCR : MonoBehaviour
{
    private float oldSpeed = 1f;
    private float Speed => ManagerModel.WallMoveSpeed;

    void Start()
    {
        oldSpeed = ManagerModel.WallMoveSpeed;
        ManagerModel.RestartGameEvent += RestartGame;
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, Speed * Time.deltaTime * ManagerModel.WallMoveSpeedTimes);
        if (transform.position.z < -30)
        {
            transform.position = Vector3.zero;
            if (Speed < 60f)
            {
                ManagerModel.WallMoveSpeed += 1.2f;
                ManagerModel.WallRestEvent?.Invoke();
            }
        }
    }

    void RestartGame()
    {
        ManagerModel.WallMoveSpeed = oldSpeed;
        transform.position = Vector3.zero;
    }
}
