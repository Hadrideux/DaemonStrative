using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoadScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Load Witch");
            GameLoaderManager.Instance.LoadWitchScene();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Load Game");
            GameLoaderManager.Instance.LoadGameScene();
        }
    }
}
