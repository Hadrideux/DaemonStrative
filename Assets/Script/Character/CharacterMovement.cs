using UnityEngine;

public class CharacterMovement : MonoBehaviour
{ 
    [SerializeField] private CharacterConrtoller _characterController = null;

    [SerializeField] private GameObject _nacPointVFX = null;

    private void Update()
    {
        EndMovement();
    }

    #region Methode

    public void Moving()
    {
        if (!DialogueManager.Instance.IsDialogueActive == true && _characterController.Agent.isStopped == false)
        {
            Ray movePosition = _characterController.Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                _characterController.Agent.isStopped = false;
                _characterController.Agent.SetDestination(hitInfo.point);

                _nacPointVFX.transform.position = new Vector3(hitInfo.point.x, 0.5f, hitInfo.point.z);
                _nacPointVFX.SetActive(true);
            }
        }
    }

    public void EndMovement()
    {
        if (_characterController.Agent.remainingDistance < 0.05f)
        {
            _nacPointVFX.SetActive(false);
        }
 
    }

    #endregion Methode
}
/*
_characterController.NavPointVFX.transform.position = new Vector3(hitInfo.point.x, 0.5f, hitInfo.point.z);
_characterController.NavPointVFX.SetActive(true);
_characterController.NavPointVFX.SetActive(false);
*/