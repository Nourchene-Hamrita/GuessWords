using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Chrono : MonoBehaviour
{
    public float startingTime = 90;
    public GameObject GameOverPopup;
    [SerializeField] TextMeshProUGUI countdownTimer;
    void Start()
    {
        //currentTime = startingTime;
    }

    void Update()
    {

        // countdownTimer.text = currentTime.ToString("0");
        if (startingTime > 0)
        {
            startingTime -= Time.deltaTime;
        }
        else
        {
            startingTime = 0;
        }

        DisplayTime(startingTime);
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }
        else if (timeToDisplay == 0)
        {
            GameOverPopup.SetActive(true);
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float secondes = Mathf.FloorToInt(timeToDisplay % 60);
        //float millisecondes = timeToDisplay % 1 * 1000;
        countdownTimer.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }

}
