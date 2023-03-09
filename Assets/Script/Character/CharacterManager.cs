using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    private CharacterController _controller = null;

    public CharacterController Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public void Moving(Camera camera, NavMeshAgent agent)
    {
        Ray movePosition = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(movePosition, out var hitInfo))
        {
            agent.SetDestination(hitInfo.point);
        }
    }

    private void Action()
    {
        //Action exécuté par le joueur
    }
}
