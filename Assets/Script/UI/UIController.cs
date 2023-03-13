using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _interactUI = null;
    [SerializeField] private GameObject _gameOverUI = null;

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Controller = this;
        UIManager.Instance.PauseUI = _pauseUI;
        UIManager.Instance.InteracUI = _interactUI;
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

}