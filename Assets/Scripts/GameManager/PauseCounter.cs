using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseCounter : MonoBehaviour
{
    private bool _isPaused = false;
    private float _currentSpeed = 1.0f;
    private int _diffLvl = 1;
    private TextMeshProUGUI _diffBtnText;

    [SerializeField] private float _easyDiffLvl = 1.0f;
    [SerializeField] private float _midDiffLvl = 1.5f;
    [SerializeField] private float _hardDiffLvl = 2.0f;

    public TextMeshProUGUI timeText;
    public Button diffBtn;
    public GameObject pausePanel; // Принимаем объект панели паузы, чтобы ее скрыть и показать

    public void PauseToggle()
    {
        if (_isPaused)
        {
            ResumeMake();
        }
        else
        {
            PauseMake();
        }
    }

    public void SpeedToggle()
    {
        if (_diffLvl == 1)
        {
            MidDiffLvl();
        }
        else if (_diffLvl == 2)
        {
            HardDiffLvl();
        }
        else if (_diffLvl == 3)
        {
            EasyDiffLvl();
        }
    }

    void Start()
    {
        //PauseMake();
        ResumeMake();
        _diffBtnText = diffBtn.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateMaker();
    }

    private void UpdateMaker()
    {
        // DisplayTime(Time.time);
        CheckPauseButton();
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // Debug.Log(minutes+""+seconds);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CheckPauseButton()
    {
        // И поменять на стандартную клавишу для разных платформ!!!
        if (Input.GetKeyDown(KeyCode.Escape))
        { // KeyCode.Y
            PauseToggle();
        }
    }

    private void ResumeMake()
    {
        pausePanel.SetActive(false);
        Time.timeScale = _currentSpeed;
        _isPaused = false;
    }

    private void PauseMake()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
        _isPaused = true;
    }

    private void EasyDiffLvl()
    {
        _currentSpeed = _easyDiffLvl;
        _diffLvl = 1;
        _diffBtnText.text = "Easy";
    }

    private void MidDiffLvl()
    {
        _currentSpeed = _midDiffLvl;
        _diffLvl = 2;
        _diffBtnText.text = "Medium";
    }

    private void HardDiffLvl()
    {
        _currentSpeed = _hardDiffLvl;
        _diffLvl = 3;
        _diffBtnText.text = "Hard";
    }
}
// https://t.me/natureModelSpb