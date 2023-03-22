using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Attributs
    #region UI Menu

    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _gameOverUI = null;
    [SerializeField] private GameObject _vignetShadowStep = null;

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

    private void Update()
    {
        CastVignetShadowStep();
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

    private void CastVignetShadowStep()
    {
        if (UIManager.Instance.IsShadowStepSkillActive == true && UIManager.Instance.ShadowStepTimer <= 2f)
        {
            _vignetShadowStep.SetActive(true);
        }
        else
        {
            _vignetShadowStep.SetActive(false);
        }
        
    }
}