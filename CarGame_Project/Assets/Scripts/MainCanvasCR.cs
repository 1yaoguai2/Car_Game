using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasCR : MonoBehaviour
{
    public GameObject plane;
    public GameObject startWindow;
    public GameObject systemWindow;

    [Header("Button")]
    public Button btnStart;
    public Button btnExit;
    public Button btnContinue;
    public Button btnSystem;
    [Header("SystemSetting")]
    public Slider audioSlider;  //声音大小控制
    public Slider cutSkyTimeSlider;    //天空盒切换速度
    public TMP_Dropdown difficultyModelDropdown; //困难模式切换
    public TextMeshProUGUI startText;

    [Header("组件")]
    public AudioSource audioSource;
    void Start()
    {
        btnContinue.gameObject.SetActive(false);
        btnContinue.onClick.AddListener(() => { StartGame(true); });
        btnStart.onClick.AddListener(() => { StartGame(true); });
        btnSystem.onClick.AddListener(() => { systemWindow.SetActive(true); });
        btnExit.onClick.AddListener(Exit);
        audioSlider.onValueChanged.AddListener(MusicController);
        audioSource.volume = 0;
        difficultyModelDropdown.onValueChanged.AddListener(DifficultyModelCut);
        ManagerModel.RestartGameEvent += RestartGame;
        Time.timeScale = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (systemWindow.activeInHierarchy)
            {
                systemWindow.SetActive(false);
                startWindow.SetActive(true);
            }
            else
                StartGame(false);
        }
    }

    void StartGame(bool startB)
    {
        if (startB)
        {
            startWindow.SetActive(false);
            plane.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            startWindow.SetActive(true);
            btnContinue.gameObject.SetActive(true);
            startText.text = "重新开始";
            btnStart.onClick.RemoveAllListeners();
            btnStart.onClick.AddListener(() => { ManagerModel.RestartGameEvent?.Invoke(); });
            plane.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void MusicController(float value)
    {
        audioSource.volume = value;
    }
    private void DifficultyModelCut(int arg0)
    {
        if (arg0 == 0)
        {
            ManagerModel.WallMoveSpeedTimes = 1;
        }
        else if (arg0 == 1)
        {
            ManagerModel.WallMoveSpeedTimes = 1.2f;
        }
        else
        {
            ManagerModel.WallMoveSpeedTimes = 1.5f;
        }
    }


    void RestartGame()
    {
        startWindow.SetActive(false);
        plane.SetActive(false);
        Time.timeScale = 1;
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
