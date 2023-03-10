using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{

    #region Attributs

    [SerializeField] private UIController _controller = null;

    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _interactUI = null;

    #endregion Attributs

    #region Properties

    public UIController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public GameObject PauseUI
    {
        get => _pauseUI;
        set => _pauseUI = value;
    }

    public GameObject InteracUI
    {
        get => _interactUI;
        set => _interactUI = value;
    }

    #endregion Properties

    #region Methode

    //Display de l'ui d'interaction
    public void DisplayUI(bool isDisplay)
    {
        _interactUI.SetActive(isDisplay);
    }

    //Active l'UI de pause
    public void pauseGame()
    {
        _pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    //Desactive l'ui de pause
    public void ResumeGame()
    {
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    //Quit l'application
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion Methode
}
