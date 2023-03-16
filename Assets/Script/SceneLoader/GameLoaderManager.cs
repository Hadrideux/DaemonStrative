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
        //SceneManager.UnloadSceneAsync("TestScene");
        SceneManager.LoadScene("WitchScene", LoadSceneMode.Single);
    }

    public void LoadGameScene()
    {
        //SceneManager.UnloadSceneAsync("WitchScene");
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }
}
