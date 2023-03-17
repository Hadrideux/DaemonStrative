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
    [SerializeField] private GameObject _gameOverUI = null;
    #endregion UI Menu

    #region Competence
    
    [SerializeField] private float _coldDown = 5f;
    [SerializeField] private float _alphaColdDown = 1f;

    [SerializeField] private Image _ombreMarcheImage = null;
    [SerializeField] private float _ombreMarcheTimer = 0.0f;

    [SerializeField] private Image _morsureImage = null;
    [SerializeField] private float _alphaMorsureTimer = 0;

    [SerializeField] private Image _griffureImage = null;
    [SerializeField] private float _alphaGriffureTimer = 0;

    #endregion Competence

    [SerializeField] private bool _isCast = false;

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

    public GameObject GameOverUI
    {
        get => _gameOverUI;
        set => _gameOverUI = value;
    }
    #endregion UI Menu

    #region UI Competence

    public Image OmbreMarcheImage
    {
        get => _ombreMarcheImage;
        set => _ombreMarcheImage = value;
    }
    public float OmbreMarcheTimer
    {
        get => _ombreMarcheTimer;
        set => _ombreMarcheTimer = Mathf.Clamp(value, 0, _coldDown);

    }
    public float ColdDown
    {
        get => _coldDown;
    }

    #endregion UI Competence

    public Image MorsureImage
    {
        get => _morsureImage;
        set => _morsureImage = value;
    }

    public Image GriffureImage
    {
        get => _griffureImage;
        set => _griffureImage = value;
    }

    public bool IsCast
    {
        get => _isCast;
        set => _isCast = value;
    }

    #endregion Properties

    private void Update()
    {
        if (OmbreMarcheTimer <= _coldDown && WitchManager.Instance.IsQuestOmbreMarche == true)
        {
            OmbreMarcheTime();
            Debug.Log(OmbreMarcheTimer);
        }
        if (_alphaMorsureTimer <= _alphaColdDown)
        {
            AlphaMorsure(true);
            Debug.Log(_alphaMorsureTimer);
        }

        if (_alphaGriffureTimer <= _alphaColdDown)
        {
            AlphaGriffure(true);
            Debug.Log(_alphaGriffureTimer);
        }
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

    public void ReloadScene()
    {
        SceneManager.LoadScene("TestScene");
        Time.timeScale = 1;
        PNJDetection.Instance.DetectionFeedBack = 0;
    }
    #endregion UI System

    #region Competence

    public void OmbreMarcheTime()
    {
        OmbreMarcheTimer += Time.deltaTime;
        OmbreMarcheImage.color = new Color(OmbreMarcheImage.color.r, OmbreMarcheImage.color.g, OmbreMarcheImage.color.b, 0.5f);

        if (OmbreMarcheTimer >= _coldDown)
        {
            OmbreMarcheTimer = 0;
            CharacterManager.Instance.IsCanBeSee = true;

            IsCast = false;
            OmbreMarcheImage.color = new Color(OmbreMarcheImage.color.r, OmbreMarcheImage.color.g, OmbreMarcheImage.color.b, 1f);

            CharacterManager.Instance.VFXOmbremarche.SetActive(false);
        }
        else
        {
            CharacterManager.Instance.VFXOmbremarche.SetActive(true);
        }
    }

    public void AlphaMorsure(bool isCast)
    {
        if (isCast == true)
        {
            _alphaMorsureTimer += Time.deltaTime;
            MorsureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 0.5f);

            if (_alphaMorsureTimer >= _alphaColdDown)
            {
                MorsureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 1f);
            }
            else
            {
                isCast = false;
            }
        }
    }
    public void AlphaGriffure(bool isCast)
    {
        if (isCast == true)
        {
            _alphaGriffureTimer += Time.deltaTime;
            GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 0.5f);

            if (_alphaGriffureTimer >= _alphaColdDown)
            {
                GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 1f);
            }
            else
            {
                isCast = false;
            }
        }
               
    }

    #endregion Competence
    #endregion Methode
}
