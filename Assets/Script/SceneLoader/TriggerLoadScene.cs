using UnityEngine;

public class TriggerLoadScene : MonoBehaviour
{
    [SerializeField] private bool _isGoWitchScene = false;
    [SerializeField] private bool _isGoGameScene = false;
    [SerializeField] private GameObject _blackFade = null;
    [SerializeField] private Animator _blackFadeAnimation = null;
    [SerializeField] private AnimationClip _fadeIn = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
}
