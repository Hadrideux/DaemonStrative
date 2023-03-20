using Engine.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderManager : Singleton<GameLoaderManager>
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("TestScene");
    }

    public void LoadWitchScene()
    {
        SceneManager.LoadScene("WitchScene", LoadSceneMode.Single);
    }

    public void LoadGameScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);        
    }
}
