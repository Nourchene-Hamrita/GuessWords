using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public GameData currentGameData;
    public TextMeshProUGUI timerText;
    private float _timeLeft;
    private float _minutes;
    private float _secondes;
    private float _oneSecondDown;
    private bool _timeOut;
    private bool _stopTimer;
    void Start()
    {
        _stopTimer = false;
        _timeOut = false;
        _timeLeft = currentGameData.selectedBoardData.timeInSeconds;
        _oneSecondDown = _timeLeft - 1f;

        GameEvents.OnBoardCompleted += StopTimer;
        GameEvents.OnUnlockNextCategory += StopTimer;
    }
    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= StopTimer;
        GameEvents.OnUnlockNextCategory -= StopTimer;
    }

    private void StopTimer()
    {
        _stopTimer = true;
    }
    private void Update()
    {
        if (_stopTimer == false)
        {
            _timeLeft -= Time.deltaTime;
        }
        if(_timeLeft <= _oneSecondDown)
        {
            _oneSecondDown = _timeLeft - 1f;
        }
    }
    void OnGUI()
    {
        if (_timeOut == false)
        {
            if(_timeLeft > 0)
            {
                 _minutes = Mathf.FloorToInt(_timeLeft / 60);
                 _secondes = Mathf.FloorToInt(_timeLeft % 60);

                timerText.text = _minutes.ToString("00") + ":" + _secondes.ToString("00");
            }
            else
            {
                _stopTimer = true;
                ActivateGameOverGUI();
            }
        }
    }
    private void ActivateGameOverGUI()
    {
        GameEvents.GameOverMethod();
        _timeOut = true;
    }
}
