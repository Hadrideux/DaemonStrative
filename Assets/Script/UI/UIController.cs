using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Attributs
    #region UI Menu

    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _gameOverUI = null;

    [SerializeField] private GameObject _vignetShadowStep = null;    

    [SerializeField] private Animator _animationShadowStep = null;

    #endregion UI Menu
    #endregion Attributs

    #region Mono

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Controller = this;
        UIManager.Instance.PauseUI = _pauseUI;
        UIManager.Instance.GameOverUI = _gameOverUI;

        UIManager.Instance.ShadowStepImage.color = new Color(UIManager.Instance.ShadowStepImage.color.r, UIManager.Instance.ShadowStepImage.color.g, UIManager.Instance.ShadowStepImage.color.b, 0.5f);
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
        SceneManager.LoadScene("GameScene"); 
        Time.timeScale = 1.0f;
    }

    private void CastVignetShadowStep()
    {
        if (UIManager.Instance.IsShadowStepSkillActive == true /*&& UIManager.Instance.ShadowStepTimer <= 2f*/)
        {
            _vignetShadowStep.SetActive(true);
            _animationShadowStep.SetTrigger("FadeIn");
            _animationShadowStep.SetTrigger("FadeOut");
        }
        else
        {
            _vignetShadowStep.SetActive(false);
        }        
    }

}