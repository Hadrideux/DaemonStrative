using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _interactUI = null;

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Controller = this;
        UIManager.Instance.PauseUI = _pauseUI;
        UIManager.Instance.InteracUI = _interactUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIManager.Instance.pauseGame();
            //UIManager.Instance.pauseGame();
        }

    }

    #endregion Mono

    public void Resumegame()
    {
        UIManager.Instance.ResumeGame();
    }

    public void QuitGame()
    {
        UIManager.Instance.QuitGame();
    }


}