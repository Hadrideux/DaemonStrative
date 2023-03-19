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

    [SerializeField] private float _alphaTimer = 0f;
    [SerializeField] private float _alphaColdDown = 0.5f;

    [SerializeField] private Image _ombreMarcheImage = null;
    [SerializeField] private float _ombreMarcheTimer = 0.0f;

    [SerializeField] private Image _morsureImage = null;

    [SerializeField] private Image _griffureImage = null;

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
    //Desactive l'UI de pause
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
    //Active L'UI de Defaite
    public void GameOver()
    {
        _gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("TestScene");
        PNJDetection.Instance.DetectionFeedBack = 0;
        Time.timeScale = 1;
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

    public void AlphaMorsure()
    {
        _alphaTimer += Time.deltaTime;
        MorsureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 0.5f);

        if (_alphaTimer > _alphaColdDown)
        {
            _alphaTimer = 0;
            MorsureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 1f);
        }
    }
    public void AlphaGriffure()
    {
        _alphaTimer += Time.deltaTime;
        GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 0.5f);

        if (_alphaTimer > _alphaColdDown)
        {
            _alphaTimer = 0;
            GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 1f);
        }
    }

    #endregion Competence
    #endregion Methode
}
