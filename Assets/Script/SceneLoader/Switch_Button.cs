using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Switch_Button : MonoBehaviour
{
    [SerializeField] private bool _isGoWitchScene = false;
    [SerializeField] private bool _isGoGameScene = false;
    [SerializeField] private GameObject _blackFade = null;
    [SerializeField] private Animator _blackFadeAnimation = null;
    [SerializeField] private AnimationClip _fadeIn = null;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene()
    {
        if (_isGoWitchScene == true && _isGoGameScene == false)
        {
            SceneManager.LoadScene("WitchScene");            
        }
        if (_isGoGameScene == true && _isGoWitchScene == false)
        {
            SceneManager.LoadScene("GameScene");            
        }
    }
}
