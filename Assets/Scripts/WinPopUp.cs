using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopUp : MonoBehaviour
{
    public GameObject WinPopup;
    
    void Start()
    {
        WinPopup.SetActive(false);
    }
    private void OnEnable()
    {
        GameEvents.OnBoardCompleted += ShowWinPopup;

    }
    private void OnDisable()
    {
       GameEvents.OnBoardCompleted -= ShowWinPopup;
    }
    private void ShowWinPopup()
    {
        WinPopup.SetActive(true);
    }
    public void LoadNextLevel()
    {
        GameEvents.LoadNextLevelMethod();
    }


}
