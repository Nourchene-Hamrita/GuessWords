using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SelectPuzzleButton : MonoBehaviour
{
    public GameData gameData;
    public GameLevelData levelData;
    public TextMeshProUGUI categoryText;
    public Image progressBarFilling;
    public Image lockImage;
    public Image unlockImage;

    private string gameSceneName="GameScene";
    private bool _levelLocked;
    void Start()
    {
        _levelLocked = false;
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        UpdateButtonInformation();
        if (_levelLocked)
        {
            button.interactable = false;
            lockImage.enabled = true;
            unlockImage.enabled = false;
        }
        else
        {
            button.interactable = true;
            lockImage.enabled = false;
            unlockImage.enabled = true;
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateButtonInformation()
    {
        var currentIndex = -1;
        var totalBoards = 0;
        foreach( var data in levelData.data)
        {
            if (data.categoryName == gameObject.name)
            {
                currentIndex = DataSaver.ReadCategoryCurrentIndexValues(gameObject.name);
                totalBoards = data.boardData.Count;

                if(levelData.data[0].categoryName==gameObject.name && currentIndex < 0)
                {
                    DataSaver.SaveCategoryData(levelData.data[0].categoryName, 0);
                    currentIndex = DataSaver.ReadCategoryCurrentIndexValues(gameObject.name);
                    totalBoards = data.boardData.Count;
                }
            }
        }
        if (currentIndex == -1)
        
            _levelLocked = true;


        categoryText.text = _levelLocked ? string.Empty : (currentIndex.ToString() + "/" + totalBoards.ToString());
        progressBarFilling.fillAmount = (currentIndex > 0 && totalBoards > 0) ? ((float)currentIndex / (float)totalBoards) : 0f;
        
    }
    private void OnButtonClick()
    {
        gameData.selectedCategoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);
    }
}
