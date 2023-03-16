using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderManager : Singleton<GameLoaderManager>
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void LoadWitchScene()
    {
        SceneManager.UnloadSceneAsync("TestScene");
        SceneManager.LoadScene("WitchScene");
    }

    public void LoadGameScene()
    {
        SceneManager.UnloadSceneAsync("WitchScene");
        SceneManager.LoadScene("TestScene");
    }
}
