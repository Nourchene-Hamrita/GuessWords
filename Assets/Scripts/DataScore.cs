using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DataScore : MonoBehaviour
    
{
    [SerializeField] TextMeshProUGUI points;
    void Start()
    {
        GameObject quizManager = GameObject.Find("QuizManager");
        QuizManager quizManagerScript = quizManager.GetComponent<QuizManager>();
        int receivedScore = quizManagerScript.GetScore()+300 ;
        points.text = "Your score is "+receivedScore.ToString();


    }
}
