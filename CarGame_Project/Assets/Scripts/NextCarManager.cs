using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCarManager : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    private int index = 0;
    private int carPos = 0;
    private int carPosX = 0;

    private float time = 0;
    private float createTime = 3f;
    public float carMoveSpeed = 2f;

    private void Start()
    {
        ManagerModel.WallRestEvent += CreateNewCar;
    }

    void FixedUpdate()
    {
        //if (time > createTime)
        //{
        //    time = 0;
        //    CreateNewCar();
        //    createTime = Random.Range(3f, 5f);
        //}
        //time += Time.deltaTime;
    }

    void CreateNewCar()
    {
        carPos = Random.Range(45, 50);
        carPosX = Random.Range(0, 2);
        index = Random.Range(0, cars.Count);
        var newCar1 = Instantiate(cars[index], new Vector3(carPosX == 0 ? -7f : 0f, 0, carPos), Quaternion.Euler(new Vector3(0, 180, 0)));
        newCar1.GetComponent<CarController>().moveSpeed = ManagerModel.WallMoveSpeed * Random.Range(1f, 1.2f);
        index = Random.Range(0, cars.Count);
        var newCar2 = Instantiate(cars[index], new Vector3(carPosX == 1 ? 7f : 0f, 0, carPos + 20), Quaternion.Euler(new Vector3(0, 180, 0)));
        newCar2.GetComponent<CarController>().moveSpeed = ManagerModel.WallMoveSpeed * Random.Range(1.1f, 1.2f);
    }
}
