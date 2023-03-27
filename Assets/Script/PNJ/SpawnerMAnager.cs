using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMAnager : Singleton<SpawnerMAnager>
{
    [SerializeField] private SpawnerController _controllerSpawn = null;

    public SpawnerController ControllerSpawn
    {
        get => _controllerSpawn;
        set => _controllerSpawn = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (WitchManager.Instance.IsQuestOmbreMarche == true) 
        {
            ControllerSpawn.SpawnGuard();
        }   
    }
}
