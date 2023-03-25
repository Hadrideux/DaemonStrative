using Engine.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderManager : Singleton<GameLoaderManager>
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("PersistentScene");
    }

    public void LoadWitchScene()
    {
        SceneManager.LoadScene("WitchScene");
    }

    public void LoadGameScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");        
    }
}
