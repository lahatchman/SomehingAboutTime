using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Reset reset;

    public void PlayerDies(Transform resetPoint)
    {
        controller.enabled = false;
        reset.ResetFunction();
        player.transform.position = resetPoint.transform.position;
        controller.enabled = true;
    }
}