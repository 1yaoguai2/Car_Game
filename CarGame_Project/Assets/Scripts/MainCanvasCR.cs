using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasCR : MonoBehaviour
{
    public GameObject startUI;

    [Header("Button")]
    public Button btnStart;
    public Button btnExit;
    public Button btnContinue;
    public Button btnSystem;
    void Start()
    {
        btnStart.onClick.AddListener(StartGame);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
    }

    void StartGame()
    {
        gameObject.SetActive(false);
    }
}
