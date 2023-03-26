using UnityEngine;

public class CharacterMovement : MonoBehaviour
{ 
    [SerializeField] private CharacterConrtoller _characterController = null;

    [SerializeField] private GameObject _navPointVFX = null;

    private void Update()
    {
        EndMovement();
    }

    #region Methode

    public void MovingAction()
    {
        if (!DialogueManager.Instance.IsDialogueActive == true && _characterController.Agent.isStopped == false)
        {
            Ray movePosition = _characterController.Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                _characterController.Agent.isStopped = false;
                _characterController.Agent.SetDestination(hitInfo.point);

                _navPointVFX.transform.position = new Vector3(hitInfo.point.x, 0.5f, hitInfo.point.z);
                _navPointVFX.SetActive(true);

                _characterController.AnimationCharacter.SetBool("IsWalk", true);
            }
        }
    }

    public void EndMovement()
    {
        if (_characterController.Agent.remainingDistance < 0.05f)
        {
            _navPointVFX.SetActive(false);
            _characterController.AnimationCharacter.SetBool("IsWalk", false);
        }
 
    }

    #endregion Methode
}
/*
_characterController.NavPointVFX.transform.position = new Vector3(hitInfo.point.x, 0.5f, hitInfo.point.z);
_characterController.NavPointVFX.SetActive(true);
_characterController.NavPointVFX.SetActive(false);
*/