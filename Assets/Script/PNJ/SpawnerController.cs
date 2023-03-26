using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject[] _spawnerGuard = null;
    [SerializeField] private GameObject _guardPNJ = null;
    [SerializeField] private Transform _guardContainer = null;


    public GameObject[] SpawnerGuard
    {
        get => _spawnerGuard; 
        set => _spawnerGuard = value;
    }

    private void Start()
    {
        SpawnerMAnager.Instance.ControllerSpawn = this;
    }

    public void SpawnGuard()
    {
        for (int i = 0; i <= SpawnerGuard.Length - 1; i++)
        {
            Instantiate(_guardPNJ, SpawnerGuard[i].transform.position, Quaternion.identity, _guardContainer);
        }
    }
}
