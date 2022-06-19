using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopUp : MonoBehaviour
{
    public GameObject gameOverPopup;
    private AudioSource _audioSource;
    //public GameObject continueGameAfterAdsButton;
    void Start()
    {
        //continueGameAfterAdsButton.GetComponent<Button>().interactable = false;
        gameOverPopup.SetActive(false);

        GameEvents.OnGameOver += ShowGameOverPopup;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverPopup;

    }
    private void ShowGameOverPopup()
    {
        gameOverPopup.SetActive(true);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        //continueGameAfterAdsButton.GetComponent<Button>().interactable = false;
    }


}
