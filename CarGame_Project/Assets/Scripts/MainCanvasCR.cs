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
    public GameObject resetWindow;

    [Header("Button")]
    public Button btnStart;
    public Button btnExit;
    public Button btnContinue;
    public Button btnSystem;
    public Button btnResetStart;
    public Button btnResetExit;
    [Header("SystemSetting")]
    public Slider audioSlider;  //声音大小控制
    public Slider cutSkyTimeSlider;    //天空盒切换速度
    public TMP_Dropdown difficultyModelDropdown; //困难模式切换
    public TextMeshProUGUI startText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    private float _score;

    [Header("组件")]
    public AudioSource audioSource;
    public AudioSource audioCrashSource;
    void Start()
    {
        btnContinue.gameObject.SetActive(false);
        btnContinue.onClick.AddListener(() => { StartGame(true); });
        btnStart.onClick.AddListener(() => { StartGame(true); });
        btnSystem.onClick.AddListener(() => { systemWindow.SetActive(true); });
        btnExit.onClick.AddListener(Exit);
        btnResetExit.onClick.AddListener(Exit);
        btnResetStart.onClick.AddListener(() => { ManagerModel.RestartGameEvent?.Invoke(); });
        audioSlider.onValueChanged.AddListener(MusicController);
        audioSource.volume = 0;
        difficultyModelDropdown.onValueChanged.AddListener(DifficultyModelCut);
        ManagerModel.RestartGameEvent += RestartGame;
        ManagerModel.EndGameEvent += EndGame;
        startWindow.SetActive(true);
        resetWindow.SetActive(false);
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

    private void FixedUpdate()
    {
        _score += Time.deltaTime;
        scoreText.text = ((int)_score).ToString();
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
        _score = 0;
        scoreText.text = "0";
        audioSource.Play();
        startWindow.SetActive(false);
        resetWindow.SetActive(false);
        plane.SetActive(false);
        Time.timeScale = 1;
    }


    void EndGame()
    {
        audioSource.Stop();
        audioCrashSource.Play();
        resetWindow.SetActive(true);
        endScoreText.text = scoreText.text;
        plane.SetActive(true);
        ManagerModel.DestoryAllCars?.Invoke();
        Time.timeScale = 0;
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
