using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPopUp : MonoBehaviour
{
    public GameObject ConfirmPopup;
    private AudioSource _audioSource;

    void Start()
    {
        
        ConfirmPopup.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();

    }
 
    public void ShowConfirmPopup()
    {
        ConfirmPopup.SetActive(true);
        
        _audioSource.Play();

    }

}

