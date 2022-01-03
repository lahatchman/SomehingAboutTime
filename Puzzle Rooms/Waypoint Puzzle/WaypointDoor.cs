using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointDoor : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject door;
    [SerializeField] private Light light;
    [SerializeField] public bool canOpen;
    #endregion

    void Update()
    {
        DoorOpen();
    }

    private void DoorOpen()
    {
        if (canOpen)
        {
            light.color = Color.green;
            door.SetActive(false);
        }
        else
        {
            light.color = Color.red;
            door.SetActive(true);
        }
    }
}
