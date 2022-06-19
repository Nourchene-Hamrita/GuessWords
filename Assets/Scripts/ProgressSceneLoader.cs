using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ProgressSceneLoader : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI progressText;
    public Transform loadingBarImage;
    public float TargetAmount = 100.0f;
    public float speed = 30;

    private float currentAmount = 0.0f;

   
    

    void Start()
    {
        currentAmount = 0.0f;

    }
    void Update()
    {
        if (currentAmount < TargetAmount)
        {
            currentAmount += speed * Time.deltaTime;
            loadingBarImage.GetComponent<Image>().fillAmount = (float)currentAmount / 100.0f;

            progressText.text = (int)(currentAmount * 1f) + "%";
        }
        
    }
 
}

