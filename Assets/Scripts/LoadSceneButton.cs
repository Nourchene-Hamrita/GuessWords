using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneButton : MonoBehaviour
{
    public GameObject loadingScreen;
    public string sceneToLoad;
    public void StartGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneToLoad);
    }
}
