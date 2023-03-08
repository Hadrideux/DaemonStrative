using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI = null;
    [SerializeField] private GameObject _interactUI = null;

    /*
    public GameObject PauseUI
    {
        get { return _pauseUI; }
        set { _pauseUI = value; }
    }
    */

    #region Mono

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
            //UIManager.Instance.pauseGame();
        }

    }

    #endregion Mono

    #region Methode

    //Active l'UI de pause
    private void pauseGame()
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

    #endregion Methode

}