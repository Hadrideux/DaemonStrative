using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoaderPersistent : MonoBehaviour
{
    [SerializeField] private Image _LoadingProgress = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _LoadingProgress.fillAmount += Time.deltaTime/5;

        if (_LoadingProgress.fillAmount >= 1)
        {
            SceneManager.LoadScene("WitchScene");
        }
    }
}
