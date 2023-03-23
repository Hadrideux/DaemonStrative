using UnityEngine;

public class TriggerLoadScene : MonoBehaviour
{
    [SerializeField] private bool _isGoWitchScene = false;
    [SerializeField] private bool _isGoGameScene = false;
    [SerializeField] private GameObject _blackFade = null;
    [SerializeField] private Animator _blackFadeAnimation = null;
    [SerializeField] private AnimationClip _fadeIn = null;
    [SerializeField] private RectTransform _activation = null;
    [SerializeField] private GameObject _VFXPortal = null;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _activation.gameObject.SetActive(true);
            _VFXPortal.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _activation.gameObject.SetActive(false);
        _VFXPortal.SetActive(false);
    }
    public void SwitchScene()
    {
        if (_isGoWitchScene)
        {
            _blackFade.SetActive(true);
            _blackFadeAnimation.Play("Fade In");
            GameLoaderManager.Instance.LoadWitchScene();
        }
        if (_isGoGameScene)
        {
            GameLoaderManager.Instance.LoadGameScene();
        }
    }
}

