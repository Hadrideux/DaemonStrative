using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadScene : MonoBehaviour
{
    [SerializeField] private bool _isGoWitchScene = false;
    [SerializeField] private bool _isGoGameScene = false;

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
        if (_isGoWitchScene == true && _isGoGameScene == false)
        {
            SceneManager.LoadScene("WitchScene");
            Debug.Log("WitchSceneLoaded");
        }
        if (_isGoGameScene == true && _isGoWitchScene == false)
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log("GameSceneLoaded");
        }
    }
}

