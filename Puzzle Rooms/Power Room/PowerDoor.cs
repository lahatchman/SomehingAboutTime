using UnityEngine;

public class PowerDoor : MonoBehaviour
{
    #region variables
    [SerializeField] private Lever[] levers;
    [SerializeField] private GameObject door;
    [SerializeField] private Light light;
    [SerializeField] private bool canOpen;
    #endregion

    void Update()
    {
        canOpen = CanOpenDoor();

        if (canOpen)
        {
            light.color = Color.green;
        }
        else
        {
            light.color = Color.red;
        }
    }

    private bool CanOpenDoor()
    {
        if (levers[0].on && levers[1].on && levers[2].on)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && CanOpenDoor())
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && CanOpenDoor())
        {
            door.SetActive(true);
        }
    }
}
