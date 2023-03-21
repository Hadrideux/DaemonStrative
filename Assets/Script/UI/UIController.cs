using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Attributs
    #region UI Menu

    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _gameOverUI = null;

    #endregion UI Menu
    #endregion Attributs

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Controller = this;
        UIManager.Instance.PauseUI = _pauseUI;
        UIManager.Instance.GameOverUI = _gameOverUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIManager.Instance.pauseGame();
        }
    }

    #endregion Mono

    public void ResumegameInstance()
    {
        UIManager.Instance.ResumeGame();
    }

    public void QuitGameInstance()
    {
        UIManager.Instance.QuitGame();
    }

    public void ReloadScceneInstance()
    {
        UIManager.Instance.ReloadScene();
    }
}