using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevelPopUp : MonoBehaviour
{   
   [System.Serializable]
   public struct CateroryName
    {
        public string name;
        public Sprite sprite;
    };
    public GameData currentGameData;
    public List<CateroryName> cateroryNames;
    public GameObject UnlockPopUp;
    public Image categoryNameImage;
    void Start()
    {
        UnlockPopUp.SetActive(false);

        GameEvents.OnLoadNextLevel += OnLoadNextLevel;
    }
    private void OnDisable()
    {
        GameEvents.OnLoadNextLevel -= OnLoadNextLevel;
    }
    private void OnLoadNextLevel()
    {
        bool captureNext = false;

        foreach(var writing in cateroryNames)
        {
            if (captureNext)
            {
                categoryNameImage.sprite = writing.sprite;
                captureNext = false;
                //break;
            }
            if (writing.name == currentGameData.selectedCategoryName)
            {
                captureNext = true;
            }
            
        }
        UnlockPopUp.SetActive(true);
    }


}
