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

    #region UI Menu

    [SerializeField] private UIController _controller = null;

    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _interactUI = null;
    [SerializeField] private GameObject _gameOverUI = null;
    #endregion UI Menu

    #region Competence

    [SerializeField] private float _coldDown = 0f;
    //[SerializeField] private float _morsureTimer = 0.0f;
    //[SerializeField] private float _griffureTimer = 0.0f;
    [SerializeField] private float _ombreMarcheTimer = 0.0f;

    #endregion Competence

    #region Blood

    

    #endregion Blood
    #endregion Attributs

    #region Properties

    #region UI Menu
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

    public GameObject GameOverUI
    {
        get => _gameOverUI;
        set => _gameOverUI = value;
    }
    #endregion UI Menu

    #region UI Competence
    /*
    public float MorsureTimer
    {
        get => _morsureTimer;
        set => _morsureTimer = Mathf.Clamp(value, 0, _coldDown);
    }

    public float GriffeTimer
    {
        get => _griffureTimer;
        set => _griffureTimer = Mathf.Clamp(value, 0, _coldDown);
    }
    */
    public float OmbreMarcheTimer
    {
        get => _ombreMarcheTimer;
        set => _ombreMarcheTimer = Mathf.Clamp(value, 0, _coldDown);

    }
    #endregion UI Competence

    #endregion Properties

    private void Start()
    {
        
    }
    private void Update()
    {
        
        /*if (MorsureTimer <= _coldDown)
        {
            MorsureTime();
        }*/
    }

    #region Methode

    #region UI System

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

    public void GameOver()
    {
        _gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    #endregion UI System

    #region Competence
    /*
    public void MorsureTime()
    {
        MorsureTimer += Time.deltaTime;
        Debug.Log(MorsureTimer);

        if (MorsureTimer >= _coldDown)
        {
            MorsureTimer = 0;
        }
    }

    public void GriffeTime()
    {
        GriffeTimer += Time.deltaTime;
        Debug.Log(GriffeTimer);

        if (GriffeTimer >= _coldDown)
        {
            GriffeTimer = 0;
        }
    }
    */

    public void OmbreMarcheTime()
    {
        OmbreMarcheTimer += Time.deltaTime;
        Debug.Log(OmbreMarcheTimer);

        if (OmbreMarcheTimer >= _coldDown)
        {
            OmbreMarcheTimer = 0;
        }
    }

    #endregion Competence

    #endregion Methode
}
