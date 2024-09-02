using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarController : MonoBehaviour
{
    void Start()
    {
        ManagerModel.RestartGameEvent += RestartGame;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    void RestartGame()
    {
        transform.position = new Vector3(0, 0, -30f);
    }


    public void MoveLeft()
    {
        if (transform.position.x >= 0)
            transform.position -= new Vector3(7, 0, 0);
    }
    public void MoveRight()
    {
        if (transform.position.x < 7)
            transform.position += new Vector3(7, 0, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
            ManagerModel.EndGameEvent?.Invoke();
    }
}
