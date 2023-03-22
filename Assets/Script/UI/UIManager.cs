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

    [SerializeField] private Image _shadowStepImage = null;
    [SerializeField] private float _shadowStepTimer = 0.0f;
    private float _activeSkill = 0;
    

    [SerializeField] private float _skillCooldownDelay = 1f;

    [SerializeField] private float _alphaShadowStepTimer = 0f;
    [SerializeField] private float _alphaBiteTimer = 0f;
    [SerializeField] private float _alphaClawTimer = 0f;

    private bool _isShadowStepActive = false;
    private bool _isBiteActive = false;
    private bool _isClawActive = false;

    [SerializeField] private Image _morsureImage = null;
    private bool _isMorsureCast = false;

    [SerializeField] private Image _griffureImage = null;
    private bool _isGriffureCast = false;

    #endregion Competence
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

    public Image ShadowStepImage
    {
        get => _shadowStepImage;
        set => _shadowStepImage = value;
    }
    public float ShadowStepTimer
    {
        get => _shadowStepTimer;
        set => _shadowStepTimer = Mathf.Clamp(value, 0, _coldDown);

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
    #endregion Properties

    public float AlphaShadowStepTimer
    {
        get => _alphaShadowStepTimer;
        set => _alphaShadowStepTimer = value;
    }
    public float AlphaBiteTimer
    {
        get => _alphaBiteTimer;
        set => _alphaBiteTimer = value;
    }
    public float AlphaClawTimer
    {
        get => _alphaClawTimer;
        set => _alphaClawTimer = value;
    }
    public bool IsShadowStepSkillActive
    {
        get => _isShadowStepActive;
        set => _isShadowStepActive = value;
    }
    public bool IsBiteSkillActive
    {
        get => _isBiteActive;
        set => _isBiteActive = value;
    }
    public bool IsClawSkillActive
    {
        get => _isClawActive;
        set => _isClawActive = value;
    }

    private void Update()
    {
        if (WitchManager.Instance.IsQuestOmbreMarche == true)
        {
            CoolDownShadowStep();
        }
        
        CooldownBiteControl();
        CooldownClawControl();
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


    public void ToggleShadowStepButton(bool isOnCd)
    {
        if (isOnCd)
        {
            ShadowStepImage.color = new Color(ShadowStepImage.color.r, ShadowStepImage.color.g, ShadowStepImage.color.b, 0.5f);
        }
        else
        {
            ShadowStepImage.color = new Color(ShadowStepImage.color.r, ShadowStepImage.color.g, ShadowStepImage.color.b, 1f);
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
            GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 0.5f);
        }
        else
        {
            GriffureImage.color = new Color(GriffureImage.color.r, GriffureImage.color.g, GriffureImage.color.b, 1f);
        }
    }

    public void CoolDownShadowStep()
    {
        if (IsShadowStepSkillActive == true)
        {
            ShadowStepTimer += Time.deltaTime;

            if (ShadowStepTimer > _activeSkill)
            {
                CharacterManager.Instance.IsCanBeSee = true;
                CharacterManager.Instance.VFXOmbremarche.SetActive(false);

                if (ShadowStepTimer >= _coldDown)
                {
                    ToggleShadowStepButton(false);
                    StopShadowStepCd();
                }
            }
            else
            {
                CharacterManager.Instance.VFXOmbremarche.SetActive(true);
            }
        }
       
    }
    public void CooldownBiteControl()
    {
        if (IsBiteSkillActive == true)
        {
            AlphaBiteTimer += Time.deltaTime;

            if (AlphaBiteTimer >= _skillCooldownDelay)
            {
                ToggleBiteSkillButton(false);
                StopBiteCd();
            }
        }
    }

    public void CooldownClawControl()
    {
        if (IsBiteSkillActive == true)
        {
            AlphaClawTimer += Time.deltaTime;

            if (AlphaClawTimer >= _skillCooldownDelay)
            {
                ToggleClawSkillButton(false);
                StopClawCd();
            }
        }
    }

    private void StopShadowStepCd()
    {
        AlphaShadowStepTimer = 0;
        IsBiteSkillActive = false;
    }
    private void StopBiteCd()
    {
        AlphaBiteTimer = 0;
        IsBiteSkillActive = false;
    }
    private void StopClawCd()
    {
        AlphaClawTimer = 0;
        IsClawSkillActive = false;
    }

    #endregion Competence
    #endregion Methode
}