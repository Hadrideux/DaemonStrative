using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
  
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float seconds = Mathf.Floor((time / 100) % 60);
        //minute
        float minutes = Mathf.Floor(seconds / 60);
        // hour
        float hours = Mathf.Floor(minutes / 60);

        Debug.Log(string.Format("Heure : {0}:{1}:{2}", hours, minutes, seconds));


    }
}
