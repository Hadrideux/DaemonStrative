using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WitchManager.Instance.WitchController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            WitchManager.Instance.IsQuestOmbreMarche = true;
            WitchManager.Instance.QuêteOmbreMarche();
        }
    }
}
