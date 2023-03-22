using Engine.Utils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

    [SerializeField] private Image _ombreMarcheImage = null;
    [SerializeField] private float _ombreMarcheTimer = 0.0f;
    private float _activeSkill = 0;

    [SerializeField] private float _alphaTimer = 0f;
    [SerializeField] private float _alphaSkill = 1f;

    [SerializeField] private Image _morsureImage = null;
    private bool _isMorsureCast = false;

    [SerializeField] private Image _griffureImage = null;
    private bool _isGriffureCast = false;

    #endregion Competence

    [SerializeField] private bool _isActive = false;
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

    public bool IsMorsureCast
    {
        get => _isMorsureCast;
        set => _isMorsureCast = value;
    }
    public bool IsGriffureCast
    {
        get => _isGriffureCast;
        set => _isGriffureCast = value;
    }
    public float AlphaTimer
    {
        get => _alphaTimer;
        set => _alphaTimer = value;
    }
    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }
    private void Update()
    {
        if (OmbreMarcheTimer <= _coldDown && WitchManager.Instance.IsQuestOmbreMarche == true)
        {
            OmbreMarcheTime();
        }

        AlphaSkills();
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
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("TestScene");
       
        Time.timeScale = 1;
    }
    #endregion UI System

    #region Competence

    public void OmbreMarcheTime()
    {
        OmbreMarcheTimer += Time.deltaTime;
        OmbreMarcheImage.color = new Color(OmbreMarcheImage.color.r, OmbreMarcheImage.color.g, OmbreMarcheImage.color.b, 0.5f);

        if (OmbreMarcheTimer > _activeSkill)
        {
            CharacterManager.Instance.IsCanBeSee = true;
            CharacterManager.Instance.VFXOmbremarche.SetActive(false);

            if (OmbreMarcheTimer >= _coldDown)
            {
                OmbreMarcheTimer = 0;

                IsCast = false;
                OmbreMarcheImage.color = new Color(OmbreMarcheImage.color.r, OmbreMarcheImage.color.g, OmbreMarcheImage.color.b, 1f);
            }
        }
        else
        {
            CharacterManager.Instance.VFXOmbremarche.SetActive(true);
        }
    }

    public void ToggleBiteSkillButton(bool isOnCd)
    {
        if (isOnCd)
        {
            MorsureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 0.5f);
        }
        else
        {
            MorsureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 1f);
        }
    }

    public void ToggleClawSkillButton(bool isOnCd)
    {
        if (isOnCd)
        {
            GriffureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 0.5f);
        }
        else
        {
            GriffureImage.color = new Color(MorsureImage.color.r, MorsureImage.color.g, MorsureImage.color.b, 1f);
        }
    }

    public void CooldownBiteControl()
    {
        if (IsBiteSkillActive == true)
        {
            AlphaBiteTimer += Time.deltaTime;


            if (AlphaBiteTimer >= _biteCooldownDelay)
            {
                ToggleBiteSkillButton(false);
                StopCd();
            }
        }
    }

    public void CooldownClawControl()
    {
        if (IsBiteSkillActive == true)
        {
            AlphaClawTimer += Time.deltaTime;


            if (AlphaClawTimer >= _clawCooldownDelay)
            {
                ToggleClawSkillButton(false);
                StopCd();
            }
        }
    }
    /*
    switch (IsGriffureCast)
    {
        case true:
            GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 0.5f);
            break;
        case false:
            if (AlphaTimer > _alphaSkill)
            {
                GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 1f);
                ActiveAlpha();
            }
            break;
    }
}*/

    private void StopCd()
    {
        AlphaTimer = 0;
        IsActive = false;
    }

    private void StopCd()
    {
        AlphaTimer = 0;
        IsActive = false;
    }
    #endregion Competence
    #endregion Methode
}