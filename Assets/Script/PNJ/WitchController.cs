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

    }
}