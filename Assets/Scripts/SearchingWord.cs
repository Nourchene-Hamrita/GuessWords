using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchingWord : MonoBehaviour
{
    public TextMeshProUGUI DisplayedText;
    public Image crossLine;
    private string _word;
    private AudioSource _source;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.Stop();

    }
    private void OnEnable()
    {
        GameEvents.OnCorrectWord += CorrectWord;
    }
    private void OnDisable()
    {
        GameEvents.OnCorrectWord -= CorrectWord;
    }
    public void SetWord(string word)
    {
        _word = word;
        DisplayedText.text = word;
    }

    private void CorrectWord(string word,List<int> squareIndexes)
    {
        if (word == _word)
        {
            crossLine.gameObject.SetActive(true);
            _source.Play();
        }

    }


}
